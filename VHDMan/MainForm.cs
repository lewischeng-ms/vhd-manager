using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VHDMan
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// List file. Indicates a list of vhd file to be loaded at startup.
        /// </summary>
        private readonly string listFile = "lst.txt";

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create an object for the vhd file and add it to the list box.
        /// </summary>
        /// <param name="fileName">...</param>
        /// <param name="readOnly">...</param>
        /// <param name="selected">...</param>
        private void AddVHDFile(string fileName, bool readOnly, bool selected)
        {
            VHDFile vhdFile = new VHDFile(fileName, readOnly);
            if (!clbVhdFiles.Items.Contains(vhdFile))
            {
                clbVhdFiles.Items.Add(vhdFile);
                clbVhdFiles.SetItemChecked(clbVhdFiles.Items.IndexOf(vhdFile), selected);
            }
        }

        /// <summary>
        /// Return a record string to be written to the list file.
        /// </summary>
        /// <param name="vhdFile">...</param>
        /// <returns>record string</returns>
        private string RecordStringOfVHDFile(VHDFile vhdFile)
        {
            if (vhdFile == null)
                return "";
            string result;
            if (clbVhdFiles.GetItemChecked(clbVhdFiles.Items.IndexOf(vhdFile)))
                result = "*";
            else
                result = "";
            result += vhdFile.Path;
            if (vhdFile.ReadOnly)
                result += "*";
            return result;
        }

        /// <summary>
        /// Mount vhd file and update status label.
        /// </summary>
        /// <param name="vhdFile">...</param>
        private void MountVHDFile(VHDFile vhdFile)
        {
            if (vhdFile == null)
                return;
            if (vhdFile.Mount())
            {
                lblStatus.Text = vhdFile.Path + "已挂载";
                if (vhdFile.ReadOnly)
                    lblStatus.Text += "[只读模式]！";
                else
                    lblStatus.Text += "！";
            }
            else
            {
                lblStatus.Text = vhdFile.Path + "挂载失败！";
            }
        }

        /// <summary>
        /// Unmount vhd file and update status label.
        /// </summary>
        /// <param name="vhdFile">...</param>
        private void UnmountVHDFile(VHDFile vhdFile)
        {
            if (vhdFile == null)
                return;
            if (vhdFile.Unmount())
            {
                lblStatus.Text = vhdFile.Path + "已卸载！";
            }
            else
            {
                lblStatus.Text = vhdFile.Path + "卸载失败！";
            }
        }

        /// <summary>
        /// Load list file.
        /// </summary>
        private void LoadListFile()
        {
            StreamReader strmReader = null;
            try
            {
                strmReader = new StreamReader(listFile, Encoding.ASCII);
            }
            catch (FileNotFoundException)
            {
                // If the list file doesn't exist, then create and return(no need to read).
                FileInfo fi = new FileInfo(listFile);
                FileStream fs = fi.Create();
                fs.Close();
                return;
            }
            catch (IOException)
            {
                MessageBox.Show("无法打开列表文件" + listFile + "！", "错误");
                Application.Exit();
                return;
            }
            clbVhdFiles.Items.Clear();
            while (!strmReader.EndOfStream)
            {
                string text = strmReader.ReadLine();

                // Blank line, ignore it.
                if (text.Length < 1)
                    continue;

                // The leading asterisk indicates the vhd file is default selected.
                bool selected = false;
                if (text[0].Equals('*'))
                {
                    selected = true;
                    text = text.Substring(1);
                }

                // The trailing asterisk indicates mounting the vhd file as read only.
                int len = text.IndexOf('*');
                if (len == -1)
                    AddVHDFile(text, false, selected);
                else
                    AddVHDFile(text.Substring(0, len), true, selected);
            }
            strmReader.Close();
        }

        /// <summary>
        /// Save to list file.
        /// </summary>
        private void SaveListFile()
        {
            StreamWriter strmWriter = null;
            try
            {
                strmWriter = new StreamWriter(listFile);
            }
            catch (FileNotFoundException)
            {
                // If list file doesn't exist, then create and write to it.
                FileInfo fi = new FileInfo(listFile);
                strmWriter = fi.CreateText();
            }
            catch (IOException)
            {
                MessageBox.Show("无法保存列表文件" + listFile + "！", "错误");
                Application.Exit();
                return;
            }
            foreach (VHDFile vhdFile in clbVhdFiles.Items)
                strmWriter.WriteLine(RecordStringOfVHDFile(vhdFile));
            strmWriter.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Only Vista+ supports vhd.
            if (Environment.OSVersion.Platform != PlatformID.Win32NT || Environment.OSVersion.Version.Major < 6)
            {
                MessageBox.Show("VHD管理器只支持Vista以上系统！", "错误");
                Application.Exit();
            }
            LoadListFile();
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length >= 2 && args[1].Equals("/autostart"))
            {
                foreach (VHDFile vhdFile in clbVhdFiles.CheckedItems)
                    MountVHDFile(vhdFile);
                Application.Exit();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            foreach (string fileName in openFileDialog.FileNames)
            {
                // First make sure the file exists.
                FileInfo fi = new FileInfo(fileName);
                if (!fi.Exists)
                {
                    MessageBox.Show("文件" + fileName + "不存在！", "错误");
                    continue;
                }
                AddVHDFile(fileName, false, true);
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clbVhdFiles.Items.Remove(clbVhdFiles.SelectedItem);
        }

        private void mnuVhdFiles_Opened(object sender, EventArgs e)
        {
            VHDFile vhdFile = clbVhdFiles.SelectedItem as VHDFile;
            if (vhdFile != null)
                readOnlyToolStripMenuItem.Checked = vhdFile.ReadOnly;
        }

        private void readOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            readOnlyToolStripMenuItem.Checked = !readOnlyToolStripMenuItem.Checked;
            VHDFile vhdFile = clbVhdFiles.SelectedItem as VHDFile;
            if (vhdFile != null)
            {
                vhdFile.ReadOnly = readOnlyToolStripMenuItem.Checked;
                clbVhdFiles.Refresh();
            }
        }

        private void mountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VHDFile vhdFile = clbVhdFiles.SelectedItem as VHDFile;
            MountVHDFile(vhdFile);
        }

        private void unmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VHDFile vhdFile = clbVhdFiles.SelectedItem as VHDFile;
            UnmountVHDFile(vhdFile);
        }

        private void mountSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (VHDFile vhdFile in clbVhdFiles.CheckedItems)
                MountVHDFile(vhdFile);
        }

        private void unmountSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (VHDFile vhdFile in clbVhdFiles.CheckedItems)
                UnmountVHDFile(vhdFile);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("VHD管理器 2.0 作者：成立 日期：2011/5/21", "关于");
        }

        private void deleteFromDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VHDFile vhdFile = clbVhdFiles.SelectedItem as VHDFile;
            if (vhdFile != null)
            {
                // Make user to confirm twice before deleting.
                if (MessageBox.Show("你确实从磁盘上要删除VHD文件 " + vhdFile.Path + " 吗？",
                                    "确认删除",
                                    MessageBoxButtons.YesNo)
                                    == System.Windows.Forms.DialogResult.No)
                    return;
                if (MessageBox.Show("你真的要删除该VHD文件吗？该虚拟磁盘内容讲永久丢失！",
                    "再次确认",
                    MessageBoxButtons.YesNo)
                    == System.Windows.Forms.DialogResult.No)
                    return;
                if (vhdFile.DeleteFromDisk())
                {
                    clbVhdFiles.Items.Remove(vhdFile);
                    lblStatus.Text = vhdFile.Path + "删除成功！";
                }
                else
                {
                    lblStatus.Text = vhdFile.Path + "删除失败！";
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveListFile();
        }

        private void CreateVDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateVDiskForm dlg = new CreateVDiskForm();
            dlg.ShowDialog();

            VHDFile vhdFile = dlg.VhdFile;
            if (dlg.VhdCreated)
            {
                AddVHDFile(dlg.VhdFile.Path, false, true);
                lblStatus.Text = vhdFile.Path + "已创建！";
            }
            else if (vhdFile == null)
            {
                lblStatus.Text = "未创建虚拟磁盘！";
            }
            else
            {
                lblStatus.Text = vhdFile.Path + "创建失败！";
            }
        }

        private void mnuVhdFiles_Opening(object sender, CancelEventArgs e)
        {
            if (clbVhdFiles.SelectedItems.Count < 1)
                e.Cancel = true;
        }

        private void clbVhdFiles_MouseClick(object sender, MouseEventArgs e)
        {
            lblStatus.Text = "就绪";
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "就绪";
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "就绪";
        }
    }
}
