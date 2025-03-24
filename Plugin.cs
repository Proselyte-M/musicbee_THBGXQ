using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace MusicBeePlugin
{


    public partial class Plugin
    {

        private MusicBeeApiInterface mbApiInterface;
        private PluginInfo about = new PluginInfo();
        private DataManager dataManager;
        private SettingsManager settingsManager;
        private FlowLayoutPanel albumPanelContainer;
        private Control panelControl;
        private DateTime lastUpdateTime = DateTime.MinValue;
        private const int MIN_UPDATE_INTERVAL_SECONDS = 1;
        private MainPage mainForm;

        public PluginInfo Initialise(IntPtr apiInterfacePtr)
        {
            mbApiInterface = new MusicBeeApiInterface();
            mbApiInterface.Initialise(apiInterfacePtr);
            about.PluginInfoVersion = PluginInfoVersion;
            about.Name = "THB刮削器";
            about.Description = "按专辑合并显示歌曲标签和封面";
            about.Author = "Author";
            about.TargetApplication = "THB刮削器面板";
            about.Type = PluginType.PanelView;
            about.VersionMajor = 1;
            about.VersionMinor = 0;
            about.Revision = 1;
            about.MinInterfaceVersion = MinInterfaceVersion;
            about.MinApiRevision = MinApiRevision;
            about.ReceiveNotifications = ReceiveNotificationFlags.PlayerEvents | ReceiveNotificationFlags.TagEvents | ReceiveNotificationFlags.DataStreamEvents;
            about.ConfigurationPanelHeight = 0;

            settingsManager = new SettingsManager(mbApiInterface);
            dataManager = new DataManager(mbApiInterface);

            Log("插件初始化完成###############################################################################");
            return about;
        }

        public bool Configure(IntPtr panelHandle)
        {
            return settingsManager.Configure(panelHandle);
        }

        public void SaveSettings()
        {
            settingsManager.SaveSettings();
        }

        public void Close(PluginCloseReason reason)
        {
            Log("插件已关闭");
        }

        public void Uninstall()
        {
            SaveSettings();
            Close(PluginCloseReason.UserDisabled);
            string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string thbAlbumsPath = Path.Combine(localAppDataPath, "THBAlbums");
            if (Directory.Exists(thbAlbumsPath))
            {
                try
                {
                    // 删除文件夹及其所有内容
                    Directory.Delete(thbAlbumsPath, true);
                    Log("THBAlbums文件夹及其内容已成功删除。");
                }
                catch (Exception ex)
                {
                    Log("删除文件夹时出错: " + ex.Message);
                }
            }
            else
            {
                Log("THBAlbums文件夹不存在。");

            }

        }

        public void ReceiveNotification(string sourceFileUrl, NotificationType type)
        {
            try
            {
                Log($"收到通知: {type}");


                // 检查更新间隔
                if ((DateTime.Now - lastUpdateTime).TotalSeconds < MIN_UPDATE_INTERVAL_SECONDS)
                {
                    Log("短时间内重复更新已阻止");
                    return;
                }

                switch (type)
                {
                    case NotificationType.TrackChanged:
                    case NotificationType.PlayingTracksChanged:
                        UpdateCurrentAlbumName();
                        break;
                }
            }
            catch (Exception ex)
            {
                Log($"处理通知时发生错误：{ex.Message}\n堆栈跟踪：{ex.StackTrace}");
            }
        }

        public int OnDockablePanelCreated(Control panel)
        {
            try
            {
                if (panel.InvokeRequired)
                {
                    return (int)panel.Invoke(new Func<Control, int>(OnDockablePanelCreated), panel);
                }

                Log("开始创建可停靠面板");
                
                // 保存面板引用
                panelControl = panel;
                
                // 创建Form1实例
                MainPage form = new MainPage(mbApiInterface);
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.AutoScroll = true;
                
                // 保存Form1引用
                mainForm = form;
                
                // 将Form添加到面板
                panel.Controls.Add(form);
                form.Show();

                Log("可停靠面板创建完成");

                // 计算DPI缩放
                float dpiScaling = 1.0f;
                using (Graphics g = panel.CreateGraphics())
                {
                    dpiScaling = g.DpiY / 96f;  // 使用标准DPI缩放因子
                }

                // 返回面板高度，使用DPI缩放
                return Convert.ToInt32(800 * dpiScaling);
            }
            catch (Exception ex)
            {
                Log($"创建可停靠面板时发生错误: {ex.Message}\n堆栈跟踪：{ex.StackTrace}");
                return 0;
            }
        }


        public void DestroyPanel()
        {
            try
            {
                if (albumPanelContainer != null)
                {
                    albumPanelContainer.Controls.Clear();
                    albumPanelContainer.Dispose();
                    albumPanelContainer = null;
                }
                panelControl = null;
                Log("面板已销毁");
            }
            catch (Exception ex)
            {
                Log($"销毁面板时发生错误：{ex.Message}\n堆栈跟踪：{ex.StackTrace}");
            }
        }

        private void Log(string message)
        {
            try
            {
                if (!ReferenceEquals(mbApiInterface, null))
                {
                    mbApiInterface.MB_Trace($"[插件主程序] {message}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[插件主程序] API接口未初始化: {message}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[插件主程序] 日志记录失败: {ex.Message}");
            }
        }

        private void UpdateCurrentAlbumName()
        {
            try
            {
                if (mainForm != null)
                {
                    string albumName = mbApiInterface.NowPlaying_GetFileTag(MetaDataType.Album) ?? "未知专辑";
                    string albumArtist = mbApiInterface.NowPlaying_GetFileTag(MetaDataType.AlbumArtist) ?? "未知艺术家";
                    mainForm.StartWork(albumName, albumArtist);
                
                }
            }
            catch (Exception ex)
            {
                Log($"更新专辑名称时发生错误：{ex.Message}");
            }
        }
    }
}