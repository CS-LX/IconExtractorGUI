using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.IconLib;
using System.IO;
using System.Windows.Forms;
using IconLib;

namespace IconExtractorGUI {
    public partial class MainForm : Form {
        private string selectedFilePath;
        private List<(Bitmap bmp, string name)> extractedIcons = new();
        private ImageList imageList;

        public MainForm() {
            InitializeComponent();

            selectButton.Click += SelectFile_Click;
            exportButton.Click += ExportSelected_Click;

            imageList = new ImageList { ImageSize = new Size(64, 64), ColorDepth = ColorDepth.Depth32Bit };

            listView.LargeImageList = imageList;
        }

        private void SelectFile_Click(object sender, EventArgs e) {
            var ofd = new OpenFileDialog();
            ofd.Filter = "可执行文件 (*.exe;*.dll)|*.exe;*.dll";

            if (ofd.ShowDialog() == DialogResult.OK) {
                selectedFilePath = ofd.FileName;
                statusLabel.Text = $"已选择文件：{Path.GetFileName(selectedFilePath)}";
                LoadIcons();
            }
        }

        private void LoadIcons() {
            listView.Items.Clear();
            imageList.Images.Clear();
            extractedIcons.Clear();

            try {
                var mi = new MultiIcon();
                mi.Load(selectedFilePath);

                int index = 0;
                foreach (SingleIcon icon in mi) {
                    foreach (IconImage img in icon) {
                        Bitmap bmp = img.Icon.ToBitmap();
                        string name = $"icon_{index}_{img.Size.Width}x{img.Size.Height}";
                        imageList.Images.Add(name, new Bitmap(bmp, 64, 64));
                        listView.Items.Add(new ListViewItem {
                            Text = name,
                            ImageKey = name,
                            Checked = true
                        });
                        extractedIcons.Add((bmp, name));
                        index++;
                    }
                }

                statusLabel.Text += $"  共提取 {extractedIcons.Count} 个图标";
            }
            catch (Exception ex) {
                MessageBox.Show("图标提取失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportSelected_Click(object sender, EventArgs e) {
            if (extractedIcons.Count == 0) {
                MessageBox.Show("请先选择文件并提取图标！");
                return;
            }

            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() != DialogResult.OK)
                return;

            string folder = fbd.SelectedPath;

            int saved = 0;
            for (int i = 0; i < listView.Items.Count; i++) {
                if (listView.Items[i].Checked) {
                    var (bmp, name) = extractedIcons[i];
                    string path = Path.Combine(folder, name + ".png");
                    bmp.Save(path);
                    saved++;
                }
            }

            MessageBox.Show($"导出完成：已保存 {saved} 个图标。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
