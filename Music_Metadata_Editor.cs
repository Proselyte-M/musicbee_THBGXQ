using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MusicBeePlugin.Plugin;

namespace MusicBeePlugin
{
    /// <summary>
    /// 音乐标签编辑器窗体类
    /// </summary>
    public partial class Music_Metadata_Editor : Form
    {
        private readonly MusicBeeApiInterface mbApiInterface;
        private const int PageSize = 100; // 每页显示的行数
        private int currentPage = 1; // 当前页码
        private int totalPages = 1; // 总页数
        private readonly List<string> allFiles = new List<string>(); // 存储所有文件路径
        private readonly Dictionary<int, (int start, int end)> pageRanges = new Dictionary<int, (int start, int end)>(); // 存储每页的文件范围
        private readonly string album; // 当前专辑名
        private string currentQueryType = ""; // 默认搜索类型

        /// <summary>
        /// 初始化音乐标签编辑器窗体
        /// </summary>
        /// <param name="apiInterface">MusicBee API接口</param>
        /// <param name="album">当前专辑名</param>
        public Music_Metadata_Editor(MusicBeeApiInterface apiInterface, string album)
        {
            InitializeComponent();
            mbApiInterface = apiInterface;
            this.album = album;
        }

        /// <summary>
        /// 窗体加载事件处理
        /// </summary>
        private void Music_Metadata_Editor_Load(object sender, EventArgs e)
        {
            comboBoxSearchTitle.SelectedItem = 0;
            try
            {
                Log("开始初始化标签编辑器窗口");
                AddDataGridViewColumns();
                LoadAlbumFiles();
                Log("标签编辑器窗口初始化完成");
            }
            catch (Exception ex)
            {
                Log($"加载音乐标签时发生错误：{ex.Message}\n堆栈跟踪：{ex.StackTrace}");
                MessageBox.Show($"加载音乐标签时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 添加DataGridView的列定义
        /// </summary>
        private void AddDataGridViewColumns()
        {
            Log("开始添加DataGridView列");
            poisonDataGridView1.Columns.Add("FileName", "文件名");
            poisonDataGridView1.Columns.Add("Title", "标题");
            poisonDataGridView1.Columns.Add("Artist", "艺术家");
            poisonDataGridView1.Columns.Add("Album", "专辑");
            poisonDataGridView1.Columns.Add("AlbumArtist", "专辑艺术家");
            poisonDataGridView1.Columns.Add("Year", "年份");
            poisonDataGridView1.Columns.Add("Genre", "流派");
            poisonDataGridView1.Columns.Add("Composer", "作曲");
            poisonDataGridView1.Columns.Add("Comment", "注释");
            poisonDataGridView1.Columns.Add("Rating", "评分");
            Log($"DataGridView列添加完成，共{poisonDataGridView1.Columns.Count}列");
        }

        /// <summary>
        /// 搜索类型下拉框选择变更事件处理
        /// </summary>
        private void ComboBoxSearchTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentQueryType = comboBoxSearchTitle.SelectedIndex switch
            {
                1 => "TrackTitle",    // 标题
                2 => "Album",         // 专辑
                3 => "AlbumArtist",   // 专辑艺术家
                4 => "Artist",        // 歌手
                5 => "Year",          // 年份
                _ => ""     // 默认值
            };
            Log($"搜索类型已更改为：{currentQueryType}");
            
            // 根据选择的索引启用或禁用搜索框
            textBox1.Enabled = comboBoxSearchTitle.SelectedIndex != 0;
            if (!textBox1.Enabled)
            {
                textBox1.Text = string.Empty;
            }
        }

        /// <summary>
        /// 加载专辑文件列表
        /// </summary>
        private void LoadAlbumFiles()
        {
            try
            {
                Log("开始查询音乐文件");
                bool queryResult = mbApiInterface.Library_QueryFiles($"Album={album}");
                if (!queryResult)
                {
                    Log("未找到音乐文件");
                    return;
                }
                Log("音乐文件查询成功");

                LoadAllFiles();
                LoadCurrentPage();
            }
            catch (Exception ex)
            {
                Log($"加载专辑文件时发生错误：{ex.Message}");
                MessageBox.Show($"加载专辑文件时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 加载所有文件路径
        /// </summary>
        private void LoadAllFiles()
        {
            Log("开始获取所有文件路径");
            string file;
            while ((file = mbApiInterface.Library_QueryGetNextFile()) != null)
            {
                allFiles.Add(file);
            }
            Log($"文件路径获取完成，共{allFiles.Count}个文件");
            
            CalculatePageRanges();
        }

        /// <summary>
        /// 计算分页范围
        /// </summary>
        private void CalculatePageRanges()
        {
            pageRanges.Clear();
            int currentStart = 0;
            int currentPage = 1;

            while (currentStart < allFiles.Count)
            {
                int currentEnd = Math.Min(currentStart + PageSize, allFiles.Count);
                string currentAlbum = mbApiInterface.Library_GetFileTag(allFiles[currentEnd - 1], MetaDataType.Album);

                while (currentEnd < allFiles.Count)
                {
                    string nextAlbum = mbApiInterface.Library_GetFileTag(allFiles[currentEnd], MetaDataType.Album);
                    if (nextAlbum != currentAlbum)
                    {
                        break;
                    }
                    currentEnd++;
                }

                pageRanges[currentPage] = (currentStart, currentEnd);
                currentStart = currentEnd;
                currentPage++;
            }

            totalPages = currentPage - 1;
            Log($"页面范围计算完成，共{totalPages}页");
            UpdatePageComboBox();
        }

        /// <summary>
        /// 更新页码选择下拉框
        /// </summary>
        private void UpdatePageComboBox()
        {
            try
            {
                int currentSelection = comboBoxSelectPage.SelectedIndex + 1;
                comboBoxSelectPage.Items.Clear();

                for (int i = 1; i <= totalPages; i++)
                {
                    comboBoxSelectPage.Items.Add($"{i}");
                }

                comboBoxSelectPage.SelectedIndex = (currentSelection > 0 && currentSelection <= totalPages) ? currentSelection - 1 : 0;
                comboBoxSelectPage.DropDownStyle = ComboBoxStyle.DropDown;
            }
            catch (Exception ex)
            {
                Log($"更新页码选择下拉框时发生错误：{ex.Message}");
            }
        }

        /// <summary>
        /// 加载当前页数据
        /// </summary>
        private void LoadCurrentPage()
        {
            try
            {
                Log($"开始加载第{currentPage}页数据");
                poisonDataGridView1.Rows.Clear();

                if (!pageRanges.ContainsKey(currentPage))
                {
                    Log($"页码{currentPage}超出范围");
                    return;
                }

                var (startIndex, endIndex) = pageRanges[currentPage];

                for (int i = startIndex; i < endIndex; i++)
                {
                    string file = allFiles[i];
                    var row = new List<string>
                    {
                        System.IO.Path.GetFileName(file),
                        mbApiInterface.Library_GetFileTag(file, MetaDataType.TrackTitle),
                        mbApiInterface.Library_GetFileTag(file, MetaDataType.Artist),
                        mbApiInterface.Library_GetFileTag(file, MetaDataType.Album),
                        mbApiInterface.Library_GetFileTag(file, MetaDataType.AlbumArtist),
                        mbApiInterface.Library_GetFileTag(file, MetaDataType.Year),
                        mbApiInterface.Library_GetFileTag(file, MetaDataType.Genre),
                        mbApiInterface.Library_GetFileTag(file, MetaDataType.Composer),
                        mbApiInterface.Library_GetFileTag(file, MetaDataType.Comment),
                        mbApiInterface.Library_GetFileTag(file, MetaDataType.Rating)
                    };

                    poisonDataGridView1.Rows.Add(row.ToArray());
                }

                UpdatePaginationButtons();
                UpdateComboBoxSelection();

                Log($"第{currentPage}页数据加载完成，显示{endIndex - startIndex}个文件");
            }
            catch (Exception ex)
            {
                Log($"加载第{currentPage}页数据时发生错误：{ex.Message}");
                MessageBox.Show($"加载数据时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 更新分页按钮状态
        /// </summary>
        private void UpdatePaginationButtons()
        {
            buttonUpPage.Enabled = currentPage > 1;
            buttonNextPage.Enabled = currentPage < totalPages;
        }

        /// <summary>
        /// 更新页码选择下拉框的选择状态
        /// </summary>
        private void UpdateComboBoxSelection()
        {
            if (comboBoxSelectPage.Items.Count >= currentPage)
            {
                comboBoxSelectPage.SelectedIndex = currentPage - 1;
            }
        }

        /// <summary>
        /// 页码选择下拉框选择变更事件处理
        /// </summary>
        private void comboBoxSelectPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSelectPage.SelectedIndex >= 0)
                {
                    int selectedPage = comboBoxSelectPage.SelectedIndex + 1;
                    if (selectedPage != currentPage)
                    {
                        currentPage = selectedPage;
                        LoadCurrentPage();
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"选择页码时发生错误：{ex.Message}");
                MessageBox.Show($"选择页码时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 页码选择下拉框按键事件处理
        /// </summary>
        private void comboBoxSelectPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }

                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                    if (int.TryParse(comboBoxSelectPage.Text, out int pageNumber))
                    {
                        if (pageNumber > 0 && pageNumber <= totalPages)
                        {
                            currentPage = pageNumber;
                            LoadCurrentPage();
                        }
                        else
                        {
                            MessageBox.Show($"请输入1到{totalPages}之间的页码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入有效的页码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"处理页码输入时发生错误：{ex.Message}");
                MessageBox.Show($"处理页码输入时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 下一页按钮点击事件处理
        /// </summary>
        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadCurrentPage();
            }
        }

        /// <summary>
        /// 上一页按钮点击事件处理
        /// </summary>
        private void buttonUpPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadCurrentPage();
            }
        }

        /// <summary>
        /// 搜索按钮点击事件处理
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 清空现有数据
                allFiles.Clear();
                poisonDataGridView1.Rows.Clear();
                pageRanges.Clear();
                currentPage = 1;
                comboBoxSelectPage.Items.Clear(); // 清空页码选择下拉框
                string query;
                if (currentQueryType == "")
                    query = "";
                else
                    query = $"{currentQueryType}={textBox1.Text}";
                // 执行新的查询
                bool queryResult = mbApiInterface.Library_QueryFiles(query);
                if (!queryResult)
                {
                    Log("未找到音乐文件");
                    MessageBox.Show("未找到音乐文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Log("音乐文件查询成功");

                // 重新加载所有文件
                LoadAllFiles();
                LoadCurrentPage();
            }
            catch (Exception ex)
            {
                Log($"搜索时发生错误：{ex.Message}");
                MessageBox.Show($"搜索时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 记录日志信息
        /// </summary>
        /// <param name="message">日志消息</param>
        private void Log(string message)
        {
            try
            {
                if (!ReferenceEquals(mbApiInterface, null))
                {
                    mbApiInterface.MB_Trace($"[tag窗口] {message}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[tag窗口] API接口未初始化: {message}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[tag窗口] 日志记录失败: {ex.Message}");
            }
        }
    }
}



