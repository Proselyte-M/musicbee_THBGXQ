using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using THBAlbums.Models;

namespace THBAlbums
{
    /// <summary>
    /// 当未找到匹配的专辑时抛出的异常
    /// </summary>
    public class AlbumNotFoundException : Exception
    {
        public AlbumNotFoundException(string albumName) 
            : base($" {albumName}")
        {
        }
    }

    /// <summary>
    /// 当未找到匹配的社团时抛出的异常
    /// </summary>
    public class ArtistNotFoundException : Exception
    {
        public ArtistNotFoundException(string artistName) 
            : base($" {artistName}")
        {
        }
    }

    /// <summary>
    /// 当获取专辑信息失败时抛出的异常
    /// </summary>
    public class AlbumInfoFetchException : Exception
    {
        public AlbumInfoFetchException(string message) 
            : base($" {message}")
        {
        }
    }

    /// <summary>
    /// 当获取专辑封面失败时抛出的异常
    /// </summary>
    public class AlbumCoverFetchException : Exception
    {
        public AlbumCoverFetchException(string message) 
            : base($" {message}")
        {
        }
    }

    /// <summary>
    /// THBWiki API 封装类，用于获取东方Project专辑信息
    /// </summary>
    public class THBWiki
    {
        private readonly THBAPIQuery _query;

        /// <summary>
        /// 初始化 THBWiki 实例
        /// </summary>
        public THBWiki()
        {
            _query = new THBAPIQuery();
        }

        /// <summary>
        /// 异步获取专辑信息
        /// </summary>
        /// <param name="albumName">专辑名称</param>
        /// <param name="albumArtist">专辑艺术家/社团名称</param>
        /// <returns>包含专辑详细信息的 GetAlbumResult 对象</returns>
        /// <exception cref="ArgumentNullException">当 albumName 为 null 或空时抛出</exception>
        /// <exception cref="AlbumNotFoundException">当未找到匹配的专辑时抛出</exception>
        /// <exception cref="ArtistNotFoundException">当未找到匹配的社团时抛出</exception>
        /// <exception cref="AlbumInfoFetchException">当获取专辑信息失败时抛出</exception>
        /// <remarks>
        /// 此方法会执行以下步骤：
        /// 1. 搜索专辑获取候选列表
        /// 2. 根据艺术家名称找到最匹配的专辑
        /// 3. 使用 SMWID 获取完整的专辑信息
        /// </remarks>
        public async Task<GetAlbumResult> GetAlbumInfoAsync(string albumName, string albumArtist)
        {
            if (string.IsNullOrWhiteSpace(albumName))
            {
                throw new ArgumentNullException(nameof(albumName), "专辑名称不能为空");
            }

            try
            {
                // 1. 搜索专辑获取候选列表
                var searchResults = _query.SearchAlbum(albumName);
                if (searchResults == null || !searchResults.Any())
                {
                    throw new AlbumNotFoundException(albumName);
                }

                // 2. 找到最匹配的专辑
                var bestMatch = FindBestMatch(searchResults, albumArtist);
                if (bestMatch == null)
                {
                    throw new ArtistNotFoundException(albumArtist);
                }

                // 3. 使用SMWID获取完整专辑信息
                var result = await _query.GetAlbumAsync(ID: bestMatch.SMWID.ToString());
                if (result.ErrorCode != QueryError.NO_ERROR)
                {
                    throw new AlbumInfoFetchException(result.ErrorMsg);
                }

                return result;
            }
            catch (AlbumNotFoundException)
            {
                throw; // 重新抛出自定义异常
            }
            catch (ArtistNotFoundException)
            {
                throw; // 重新抛出自定义异常
            }
            catch (AlbumInfoFetchException)
            {
                throw; // 重新抛出自定义异常
            }
            catch (Exception ex)
            {
                throw new AlbumInfoFetchException($"获取专辑信息时发生错误: {ex.Message}");
            }
        }

        /// <summary>
        /// 异步获取专辑封面图片
        /// </summary>
        /// <param name="smwid">专辑的 SMWID</param>
        /// <returns>专辑封面的字节数组</returns>
        /// <exception cref="ArgumentNullException">当 smwid 为 null 或空时抛出</exception>
        /// <exception cref="AlbumCoverFetchException">当获取封面失败时抛出</exception>
        /// <remarks>
        /// 此方法会从 THBWiki 获取指定专辑的封面图片数据
        /// </remarks>
        public async Task<byte[]> GetAlbumCoverAsync(string smwid)
        {
            if (string.IsNullOrWhiteSpace(smwid))
            {
                throw new ArgumentNullException(nameof(smwid), "SMWID 不能为空");
            }

            try
            {
                var coverData = await _query.GetAlbumCoverAsync(smwid);
                if (coverData == null || coverData.Length == 0)
                {
                    throw new AlbumCoverFetchException($"SMWID={smwid}");
                }
                return coverData;
            }
            catch (AlbumCoverFetchException)
            {
                throw; // 重新抛出自定义异常
            }
            catch (Exception ex)
            {
                throw new AlbumCoverFetchException($"获取专辑封面时发生错误: {ex.Message}");
            }
        }

        /// <summary>
        /// 从搜索结果中找到最匹配的专辑
        /// </summary>
        /// <param name="searchResults">专辑搜索结果列表</param>
        /// <param name="albumArtist">目标艺术家/社团名称</param>
        /// <returns>最匹配的专辑结果，如果没有匹配项则返回 null</returns>
        /// <remarks>
        /// 匹配算法：
        /// 1. 如果没有提供艺术家信息，返回第一个结果
        /// 2. 否则，计算每个结果与目标艺术家名称的相似度
        /// 3. 返回相似度最高的结果
        /// </remarks>
        private SearchAlbumResult FindBestMatch(List<SearchAlbumResult> searchResults, string albumArtist)
        {
            if (string.IsNullOrEmpty(albumArtist))
            {
                // 如果没有提供艺术家信息，返回第一个结果
                return searchResults.FirstOrDefault();
            }

            // 计算每个结果与目标艺术家名称的相似度
            var matches = searchResults.Select(result => new
            {
                Result = result,
                Similarity = CalculateSimilarity(result.Circle, albumArtist)
            }).OrderByDescending(x => x.Similarity);

            // 返回相似度最高的结果
            return matches.FirstOrDefault()?.Result;
        }

        /// <summary>
        /// 计算两个字符串的相似度
        /// </summary>
        /// <param name="str1">第一个字符串</param>
        /// <param name="str2">第二个字符串</param>
        /// <returns>相似度值（0-1之间），值越大表示越相似</returns>
        /// <remarks>
        /// 相似度计算规则：
        /// 1. 完全匹配返回 1.0
        /// 2. 包含关系返回 0.8
        /// 3. 其他情况使用编辑距离计算相似度
        /// </remarks>
        private double CalculateSimilarity(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
                return 0;

            // 将字符串转换为小写进行比较
            str1 = str1.ToLowerInvariant();
            str2 = str2.ToLowerInvariant();

            // 完全匹配
            if (str1 == str2)
                return 1.0;

            // 包含关系
            if (str1.Contains(str2) || str2.Contains(str1))
                return 0.8;

            // 计算编辑距离
            int distance = ComputeLevenshteinDistance(str1, str2);
            int maxLength = Math.Max(str1.Length, str2.Length);
            
            // 返回基于编辑距离的相似度（0-1之间）
            return 1.0 - ((double)distance / maxLength);
        }

        /// <summary>
        /// 计算两个字符串的 Levenshtein 编辑距离
        /// </summary>
        /// <param name="str1">第一个字符串</param>
        /// <param name="str2">第二个字符串</param>
        /// <returns>编辑距离值，值越小表示字符串越相似</returns>
        /// <remarks>
        /// Levenshtein 距离是指将一个字符串转换为另一个字符串所需的最少编辑操作次数
        /// 编辑操作包括：插入、删除、替换
        /// </remarks>
        private int ComputeLevenshteinDistance(string str1, string str2)
        {
            int[,] distance = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
                distance[i, 0] = i;
            for (int j = 0; j <= str2.Length; j++)
                distance[0, j] = j;

            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    int cost = (str1[i - 1] == str2[j - 1]) ? 0 : 1;
                    distance[i, j] = Math.Min(
                        Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1),
                        distance[i - 1, j - 1] + cost);
                }
            }

            return distance[str1.Length, str2.Length];
        }
    }
}