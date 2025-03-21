using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static MusicBeePlugin.Plugin;

namespace MusicBeePlugin
{
    public class SettingsManager
    {
        private readonly MusicBeeApiInterface mbApiInterface;
        private readonly PluginSettings settings;

        public class PluginSettings
        {
            public int CardHeight { get; set; } = 200;
            public bool ShowYear { get; set; } = true;
            public bool ShowMetadata { get; set; } = true;
        }

        public PluginSettings Settings => settings;

        public SettingsManager(MusicBeeApiInterface apiInterface)
        {
            mbApiInterface = apiInterface;
            settings = LoadSettings();
        }

        public bool Configure(IntPtr panelHandle)
        {
            if (panelHandle == IntPtr.Zero) return false;

            using (Form configForm = new Form())
            using (Panel panel = new Panel { Dock = DockStyle.Fill })
            using (NumericUpDown heightInput = new NumericUpDown { Location = new Point(10, 10), Minimum = 150, Maximum = 400, Value = settings.CardHeight })
            using (CheckBox showYearCheck = new CheckBox { Location = new Point(10, 40), Text = "显示年份", Checked = settings.ShowYear })
            using (Button saveButton = new Button { Location = new Point(10, 70), Text = "保存" })
            {
                configForm.Size = new Size(300, 150);
                configForm.Text = "专辑标签面板设置";
                configForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                configForm.MaximizeBox = false;
                configForm.MinimizeBox = false;
                configForm.StartPosition = FormStartPosition.CenterParent;

                panel.Controls.Add(heightInput);
                panel.Controls.Add(showYearCheck);
                panel.Controls.Add(saveButton);
                configForm.Controls.Add(panel);

                saveButton.Click += (s, e) =>
                {
                    settings.CardHeight = (int)heightInput.Value;
                    settings.ShowYear = showYearCheck.Checked;
                    SaveSettings();
                    configForm.Close();
                };

                configForm.ShowDialog();
            }
            return true;
        }

        private PluginSettings LoadSettings()
        {
            string configPath = Path.Combine(mbApiInterface.Setting_GetPersistentStoragePath(), "AlbumTagPanelSettings.ini");
            var loadedSettings = new PluginSettings();

            if (File.Exists(configPath))
            {
                string[] lines = File.ReadAllLines(configPath);
                foreach (string line in lines)
                {
                    var parts = line.Split('=');
                    if (parts.Length != 2) continue;
                    switch (parts[0].Trim())
                    {
                        case "CardHeight":
                            if (int.TryParse(parts[1].Trim(), out int height))
                                loadedSettings.CardHeight = height;
                            break;
                        case "ShowYear":
                            loadedSettings.ShowYear = parts[1].Trim().ToLower() == "true";
                            break;
                        case "ShowMetadata":
                            loadedSettings.ShowMetadata = parts[1].Trim().ToLower() == "true";
                            break;
                    }
                }
            }
            return loadedSettings;
        }

        public void SaveSettings()
        {
            string configPath = Path.Combine(mbApiInterface.Setting_GetPersistentStoragePath(), "AlbumTagPanelSettings.ini");
            using (StreamWriter writer = new StreamWriter(configPath))
            {
                writer.WriteLine($"CardHeight={settings.CardHeight}");
                writer.WriteLine($"ShowYear={settings.ShowYear}");
                writer.WriteLine($"ShowMetadata={settings.ShowMetadata}");
            }
        }
    }
}