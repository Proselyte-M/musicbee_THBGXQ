using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using THBAlbums.Models;

namespace THBAlbums
{
    public class THBWiki
    {
        private readonly THBAPIQuery _query;

        public THBWiki()
        {
            _query = new THBAPIQuery();
        }

        public async Task<GetAlbumResult> GetAlbumInfoAsync(string albumName, string albumArtist)
        {
            try
            {
                // 1. 搜索专辑获取候选列表
                var searchResults = _query.SearchAlbum(albumName);
                if (searchResults == null || !searchResults.Any())
                {
                    throw new Exception($"未找到匹配的专辑: {albumName}");
                }

                // 2. 找到最匹配的专辑
                var bestMatch = FindBestMatch(searchResults, albumArtist);
                if (bestMatch == null)
                {
                    throw new Exception($"未找到匹配的社团: {albumArtist}");
                }

                // 3. 使用SMWID获取完整专辑信息
                var result = await _query.GetAlbumAsync(ID: bestMatch.SMWID.ToString());
                if (result.ErrorCode != QueryError.NO_ERROR)
                {
                    throw new Exception($"获取专辑信息失败: {result.ErrorMsg}");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"获取专辑信息时发生错误: {ex.Message}", ex);
            }
        }

        public async Task<byte[]> GetAlbumCoverAsync(string smwid)
        {
            try
            {
                var coverData = await _query.GetAlbumCoverAsync(smwid);
                if (coverData == null || coverData.Length == 0)
                {
                    throw new Exception($"获取专辑封面失败: SMWID={smwid}");
                }
                return coverData;
            }
            catch (Exception ex)
            {
                throw new Exception($"获取专辑封面时发生错误: {ex.Message}", ex);
            }
        }

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