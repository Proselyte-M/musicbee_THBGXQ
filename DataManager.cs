using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MusicBeePlugin.Plugin;

namespace MusicBeePlugin
{
    public class DataManager
    {
        private readonly MusicBeeApiInterface mbApiInterface;
        private readonly List<(string File, Dictionary<string, string> Tags)> allSongs;

        public DataManager(MusicBeeApiInterface apiInterface)
        {
            mbApiInterface = apiInterface;
            allSongs = new List<(string File, Dictionary<string, string> Tags)>();
        }

        public async Task UpdateTagInfoAsync(Func<List<(string File, Dictionary<string, string> Tags)>, Task> callback)
        {
            if (mbApiInterface.InterfaceVersion == 0)
            {
                return;
            }

            try
            {
                // 首先尝试获取选中的文件
                bool querySuccess = mbApiInterface.Library_QueryFilesEx("domain=SelectedFiles", out string[] selectedFiles);
                string debugMsg = $"QueryEx: {querySuccess}, Files: {(selectedFiles == null ? "null" : selectedFiles.Length.ToString())}";

                if (!querySuccess || selectedFiles == null || selectedFiles.Length == 0)
                {
                    // 如果没有选中文件，尝试获取当前播放的文件
                    string nowPlaying = mbApiInterface.NowPlaying_GetFileUrl();
                    if (!string.IsNullOrEmpty(nowPlaying))
                    {
                        selectedFiles = new[] { nowPlaying };
                        debugMsg += ", Using NowPlaying";
                    }
                    else
                    {
                        // 如果也没有正在播放的文件，尝试获取播放列表中的文件
                        List<string> playlistFiles = new List<string>();
                        if (mbApiInterface.Library_QueryFiles("domain=NowPlayingList"))
                        {
                            string file;
                            while ((file = mbApiInterface.Library_QueryGetNextFile()) != null)
                            {
                                playlistFiles.Add(file);
                            }
                        }
                        if (playlistFiles.Count > 0)
                        {
                            selectedFiles = playlistFiles.ToArray();
                            debugMsg += $", Using NowPlayingList: {playlistFiles.Count}";
                        }
                        else
                        {
                            // 如果还是没有文件，返回空列表
                            await callback(new List<(string File, Dictionary<string, string> Tags)>());
                            return;
                        }
                    }
                }

                // 获取文件标签
                allSongs.Clear();
                var tagFields = Enum.GetValues(typeof(MetaDataType)).Cast<MetaDataType>().ToArray();

                await Task.Run(() =>
                {
                    foreach (string file in selectedFiles)
                    {
                        var tags = new Dictionary<string, string>();
                        foreach (var field in tagFields)
                        {
                            string value = mbApiInterface.Library_GetFileTag(file, field);
                            if (!string.IsNullOrEmpty(value))
                            {
                                tags[field.ToString()] = value;
                            }
                        }
                        lock (allSongs)
                        {
                            allSongs.Add((file, tags));
                        }
                    }
                });

                await callback(allSongs);
            }
            catch (Exception ex)
            {
                mbApiInterface.MB_Trace($"[DataManager] 更新标签信息时发生错误：{ex.Message}");
                await callback(new List<(string File, Dictionary<string, string> Tags)>());
            }
        }
    }
}