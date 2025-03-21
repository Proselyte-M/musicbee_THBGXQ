using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THBAlbums;
using THBAlbums.Models;
using static MusicBeePlugin.Plugin;
using ReaLTaiizor;

namespace MusicBeePlugin
{
    public partial class MainPage: Form
    {
        private MusicBeeApiInterface mbApiInterface;
        private float dpiScaleFactor = 1.0f;

        public MainPage(MusicBeeApiInterface apiInterface)
        {
            InitializeComponent();
            mbApiInterface = apiInterface;
            
            // 设置DPI感知
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            // 获取当前DPI缩放因子
            using (Graphics g = CreateGraphics())
            {
                dpiScaleFactor = g.DpiX / 96f;
            }

            // 调整窗体大小以适应DPI缩放
            if (dpiScaleFactor != 1.0f)
            {
                this.Width = (int)(this.Width * dpiScaleFactor);
                this.Height = (int)(this.Height * dpiScaleFactor);
            }
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            // 使用默认的DPI缩放行为
            base.ScaleControl(factor, specified);
        }

        

        public async void StartWork(string albumName, string albumArtist)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string, string>(StartWork), new object[] { albumName, albumArtist });
                return;
            }

            try
            {
                ClearAllControls();

                Log($"开始获取专辑信息：{albumName}，艺术家：{albumArtist}");
                var thbWiki = new THBWiki();
                var result = await thbWiki.GetAlbumInfoAsync(albumName, albumArtist);
                GetTHBWikiInfo(result);
            }
            catch (Exception ex)
            {
                Log($"获取专辑信息时发生错误：{ex.Message}");
            }
        }
        #region 控件控制
        private void ClearAllControls()
        {
            // 清空所有文本框
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    UpdateTextBoxSafe(textBox, string.Empty);
                }
            }

            // 清空DataGridView
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new Action(() => {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                }));
            }
            else
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
            }

            // 清空PictureBox
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(new Action(() => {
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = null;
                }));
            }
            else
            {
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = null;
            }
        }
        private void UpdateTextBoxSafe(TextBox textBox, string value)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new Action<TextBox, string>(UpdateTextBoxSafe), new object[] { textBox, value });
                return;
            }
            textBox.Text = value;
        }
        
        private async Task UpdatePictureBoxSafe(PictureBox pictureBox, byte[] imageData)
        {
            try
            {
                if (imageData == null || imageData.Length == 0)
                {
                    Log("图片数据为空");
                    return;
                }

                Log("开始加载图片");
                using (var ms = new System.IO.MemoryStream(imageData))
                {
                    var image = await Task.Run(() => Image.FromStream(ms));
                    if (pictureBox.InvokeRequired)
                    {
                        await Task.Run(() => pictureBox.Invoke(new Action(() => {
                            pictureBox.Image?.Dispose();
                            pictureBox.Image = image;
                        })));
                    }
                    else
                    {
                        pictureBox.Image?.Dispose();
                        pictureBox.Image = image;
                    }
                }
                Log("图片加载完成");
            }
            catch (Exception ex)
            {
                Log($"加载图片时发生错误：{ex.Message}");
            }
        }
        
        private void UpdateDataGridViewSafe(DataGridView dataGridView, IEnumerable<GetTrackResult> tracks)
        {
            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(new Action<DataGridView, IEnumerable<GetTrackResult>>(UpdateDataGridViewSafe),
                    new object[] { dataGridView, tracks });
                return;
            }

            var tracksList = tracks.ToList();
            if (!tracksList.Any()) return;

            // 保存tracks列表到Tag属性中，用于点击事件处理
            dataGridView.Tag = tracksList;

            // 移除现有的事件处理器（如果存在）
            dataGridView.CellContentClick -= DataGridView_CellContentClick;
            // 添加事件处理器
            dataGridView.CellContentClick += DataGridView_CellContentClick;

            // 清除现有数据
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            // 定义所有可能的列及其标题
            var possibleColumns = new Dictionary<string, (string Header, Func<GetTrackResult, object> ValueGetter, bool IsLink)>
            {
                { "DiscTrack", ("音轨号", t => $"Disc {t.DiscNo}-{t.TrackNo:D2}", false) },
                { "Name", ("曲目名称", t => t.Name, false) },
                { "Artist", ("演唱者", t => t.Artist, false) },
                { "OGMusic", ("原曲", t => t.OGMusic, false) },
                { "OGWork", ("原曲出处", t => t.OGWork, false) },
                { "Type", ("类型", t => t.Type, false) },
                { "Time", ("时长", t => t.Time > 0 ? $"{t.Time / 60:D2}:{t.Time % 60:D2}" : "", false) }
            };

            // 检查每列是否有数据，只添加有数据的列
            foreach (var col in possibleColumns)
            {
                bool hasData = tracksList.Any(track => 
                {
                    var value = col.Value.ValueGetter(track);
                    return value != null && 
                           value.ToString() != "" && 
                           value.ToString() != "0" &&
                           value.ToString() != "Disc 0-00";
                });

                if (hasData)
                {
                    DataGridViewColumn column;
                    if (col.Value.IsLink)
                    {
                        column = new DataGridViewLinkColumn
                        {
                            Name = col.Key,
                            HeaderText = col.Value.Header,
                            UseColumnTextForLinkValue = false,
                            TrackVisitedState = false,
                            LinkColor = Color.FromArgb(0, 102, 204),
                            ActiveLinkColor = Color.FromArgb(0, 102, 204),
                            VisitedLinkColor = Color.FromArgb(0, 102, 204)
                        };
                    }
                    else
                    {
                        column = new DataGridViewTextBoxColumn
                        {
                            Name = col.Key,
                            HeaderText = col.Value.Header
                        };
                    }
                    
                    dataGridView.Columns.Add(column);
                }
            }

            // 添加数据行
            foreach (var track in tracksList)
            {
                var rowValues = new List<object>();
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    rowValues.Add(possibleColumns[column.Name].ValueGetter(track));
                }
                dataGridView.Rows.Add(rowValues.ToArray());
            }

            // 设置列的显示属性
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.ToolTipText = column.HeaderText;
                
                // 根据列类型设置不同的样式
                switch (column.Name)
                {
                    case "DiscTrack":
                        column.Width = 80;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    case "Name":
                        column.Width = 300;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    case "Artist":
                        column.Width = 150;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    case "OGMusic":
                        column.Width = 200;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    case "OGWork":
                        column.Width = 150;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    case "Type":
                        column.Width = 100;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    case "Time":
                        column.Width = 60;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    default:
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                }
            }

            // 设置滚动条

            // 设置列的排序方式
            if (dataGridView.Columns.Contains("Time"))
                dataGridView.Columns["Time"].ValueType = typeof(string);
            if (dataGridView.Columns.Contains("DiscTrack"))
                dataGridView.Sort(dataGridView.Columns["DiscTrack"], ListSortDirection.Ascending);

            // 添加鼠标悬停效果
            dataGridView.CellMouseEnter += (sender, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(229, 243, 255);
                }
            };

            dataGridView.CellMouseLeave += (sender, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = 
                        e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(247, 247, 247);
                }
            };
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            if (e.RowIndex < 0) return;

            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                var track = ((List<GetTrackResult>)dataGridView.Tag)[e.RowIndex];
                var clickedText = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();

                string url = null;
                switch (clickedText)
                {
                    case "原文":
                        url = track.Lrc;
                        break;
                    case "译文":
                        url = track.TranLrc;
                        break;
                    case "对照":
                        url = track.AllLrc;
                        break;
                }

                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(url);
                    }
                    catch (Exception ex)
                    {
                        Log($"打开歌词链接时发生错误：{ex.Message}");
                    }
                }
            }
        }
        static string FormatTime(string time)
        {
            if (int.TryParse(time, out int seconds))
            {
                // 如果成功解析为整数，则转换为MM:SS格式
                int minutes = seconds / 60;
                int remainingSeconds = seconds % 60;
                return $"{minutes:D2}:{remainingSeconds:D2}";
            }
            else
            {
                // 如果无法解析为整数，则保持原样
                return time;
            }
        }
        #endregion
        private async void GetTHBWikiInfo(GetAlbumResult result)
        {
            try
            {
                UpdateTextBoxSafe(dreamTextBox_AlName, result.AlName);
                UpdateTextBoxSafe(dreamTextBox_Circle, result.Circle);
                UpdateTextBoxSafe(dreamTextBox_Date, result.Date);
                UpdateTextBoxSafe(dreamTextBox_Year, result.Year);
                UpdateTextBoxSafe(dreamTextBox_Event, result.Event);
                UpdateTextBoxSafe(dreamTextBox_EventPage, result.EventPage);
                UpdateTextBoxSafe(dreamTextBox_Rate, result.Rate);
                UpdateTextBoxSafe(dreamTextBox_Number, result.Number);
                UpdateTextBoxSafe(dreamTextBox_Disc, result.Disc.ToString());
                UpdateTextBoxSafe(dreamTextBox_Track, result.Track.ToString());
                UpdateTextBoxSafe(dreamTextBox_Time, FormatTime(result.time));
                UpdateTextBoxSafe(dreamTextBox_Property, result.Property);
                UpdateTextBoxSafe(dreamTextBox_Style, result.Style);
                UpdateTextBoxSafe(dreamTextBox_Only, result.Only);
                UpdateTextBoxSafe(dreamTextBox_Price, result.Price);
                UpdateTextBoxSafe(dreamTextBox_EventPrice, result.EventPrice);
                UpdateTextBoxSafe(dreamTextBox_ShopPrice, result.ShopPrice);
                UpdateTextBoxSafe(dreamTextBox_Note, result.Note);
                UpdateTextBoxSafe(dreamTextBox_Official, result.Official);
                UpdateTextBoxSafe(dreamTextBox_CoverChar, result.CoverChar);

                // 更新曲目列表
                UpdateDataGridViewSafe(dataGridView1, result.Tracks);

                // 获取并更新专辑封面
                try
                {
                    var thbWiki = new THBWiki();
                    var coverData = await thbWiki.GetAlbumCoverAsync(result.SMWID.ToString());
                    await UpdatePictureBoxSafe(pictureBox1, coverData);
                }
                catch (Exception ex)
                {
                    Log($"获取专辑封面时发生错误：{ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Log($"更新界面时发生错误：{ex.Message}\n堆栈跟踪：{ex.StackTrace}");
            }
        }

        private void Log(string message)
        {
            try
            {
                if (!ReferenceEquals(mbApiInterface, null))
                {
                    mbApiInterface.MB_Trace($"[窗口] {message}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[窗口] API接口未初始化: {message}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[窗口] 日志记录失败: {ex.Message}");
            }
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void airButton_SaveTag_Click(object sender, EventArgs e)
        {
            Log("点击保存tag按钮");
            try
            {
                // 获取当前播放的文件
                string currentFile = mbApiInterface.NowPlaying_GetFileUrl();
                if (string.IsNullOrEmpty(currentFile))
                {
                    Log("没有正在播放的文件");
                    return;
                }

                // 获取当前播放文件的专辑名称和艺术家
                string currentAlbum = mbApiInterface.Library_GetFileTag(currentFile, MetaDataType.Album);
                string currentArtist = mbApiInterface.Library_GetFileTag(currentFile, MetaDataType.AlbumArtist);

                Log($"当前专辑：{currentAlbum}");
                Log($"当前艺术家：{currentArtist}");

                if (string.IsNullOrEmpty(currentAlbum) || string.IsNullOrEmpty(currentArtist))
                {
                    Log("无法获取当前专辑信息");
                    return;
                }

                // 查询相同专辑的所有文件
                string query = $"Artist = '{currentArtist}' AND Album = '{currentAlbum}'";
                Log($"执行查询：{query}");
                
                bool queryResult = mbApiInterface.Library_QueryFiles(query);
                Log($"查询结果：{queryResult}");

                if (!queryResult)
                {
                    Log("未找到专辑中的其他文件");
                    return;
                }

                int successCount = 0;
                int failCount = 0;

                // 遍历专辑中的所有文件
                string file;
                Log("开始获取文件列表...");
                file = mbApiInterface.Library_QueryGetNextFile();
                Log($"第一个文件：{(file ?? "null")}");
                
                if (file != null)
                {
                    try
                    {
                        Log($"正在处理文件：{file}");
                        // 保存专辑信息
                        mbApiInterface.Library_SetFileTag(file, MetaDataType.Album, dreamTextBox_AlName.Text);
                        mbApiInterface.Library_SetFileTag(file, MetaDataType.AlbumArtist, dreamTextBox_Circle.Text);
                        mbApiInterface.Library_SetFileTag(file, MetaDataType.Year, dreamTextBox_Year.Text);
                        mbApiInterface.Library_SetFileTag(file, MetaDataType.Comment, dreamTextBox_Note.Text);

                        // 提交更改到文件
                        if (mbApiInterface.Library_CommitTagsToFile(file))
                        {
                            successCount++;
                            Log($"成功保存文件标签：{file}");
                        }
                        else
                        {
                            failCount++;
                            Log($"保存文件标签失败：{file}");
                        }
                    }
                    catch (Exception ex)
                    {
                        failCount++;
                        Log($"处理文件时发生错误：{file}, 错误：{ex.Message}");
                    }
                }
                
                while ((file = mbApiInterface.Library_QueryGetNextFile()) != null)
                {
                    try
                    {
                        Log($"正在处理文件：{file}");
                        // 保存专辑信息
                        mbApiInterface.Library_SetFileTag(file, MetaDataType.Album, dreamTextBox_AlName.Text);
                        mbApiInterface.Library_SetFileTag(file, MetaDataType.AlbumArtist, dreamTextBox_Circle.Text);
                        mbApiInterface.Library_SetFileTag(file, MetaDataType.Year, dreamTextBox_Year.Text);
                        mbApiInterface.Library_SetFileTag(file, MetaDataType.Comment, dreamTextBox_Note.Text);

                        // 提交更改到文件
                        if (mbApiInterface.Library_CommitTagsToFile(file))
                        {
                            successCount++;
                            Log($"成功保存文件标签：{file}");
                        }
                        else
                        {
                            failCount++;
                            Log($"保存文件标签失败：{file}");
                        }
                    }
                    catch (Exception ex)
                    {
                        failCount++;
                        Log($"处理文件时发生错误：{file}, 错误：{ex.Message}");
                    }
                }

                Log($"标签保存完成。成功：{successCount}，失败：{failCount}");
            }
            catch (Exception ex)
            {
                Log($"保存标签时发生错误：{ex.Message}");
            }
        }
    }


}
