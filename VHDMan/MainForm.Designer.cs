namespace VHDMan
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.clbVhdFiles = new System.Windows.Forms.CheckedListBox();
            this.mnuVhdFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFromDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unmountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateVDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mountSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unmountSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuVhdFiles.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbVhdFiles
            // 
            this.clbVhdFiles.ContextMenuStrip = this.mnuVhdFiles;
            this.clbVhdFiles.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbVhdFiles.FormattingEnabled = true;
            this.clbVhdFiles.HorizontalScrollbar = true;
            this.clbVhdFiles.Location = new System.Drawing.Point(12, 27);
            this.clbVhdFiles.Name = "clbVhdFiles";
            this.clbVhdFiles.Size = new System.Drawing.Size(413, 228);
            this.clbVhdFiles.TabIndex = 2;
            this.clbVhdFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clbVhdFiles_MouseClick);
            // 
            // mnuVhdFiles
            // 
            this.mnuVhdFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.deleteFromDiskToolStripMenuItem,
            this.readOnlyToolStripMenuItem,
            this.mountToolStripMenuItem,
            this.unmountToolStripMenuItem});
            this.mnuVhdFiles.Name = "mnuVhdFiles";
            this.mnuVhdFiles.Size = new System.Drawing.Size(149, 114);
            this.mnuVhdFiles.Opening += new System.ComponentModel.CancelEventHandler(this.mnuVhdFiles_Opening);
            this.mnuVhdFiles.Opened += new System.EventHandler(this.mnuVhdFiles_Opened);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.removeToolStripMenuItem.Text = "移出列表";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // deleteFromDiskToolStripMenuItem
            // 
            this.deleteFromDiskToolStripMenuItem.Name = "deleteFromDiskToolStripMenuItem";
            this.deleteFromDiskToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.deleteFromDiskToolStripMenuItem.Text = "从磁盘中删除";
            this.deleteFromDiskToolStripMenuItem.Click += new System.EventHandler(this.deleteFromDiskToolStripMenuItem_Click);
            // 
            // readOnlyToolStripMenuItem
            // 
            this.readOnlyToolStripMenuItem.Checked = true;
            this.readOnlyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.readOnlyToolStripMenuItem.Name = "readOnlyToolStripMenuItem";
            this.readOnlyToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.readOnlyToolStripMenuItem.Text = "只读模式";
            this.readOnlyToolStripMenuItem.Click += new System.EventHandler(this.readOnlyToolStripMenuItem_Click);
            // 
            // mountToolStripMenuItem
            // 
            this.mountToolStripMenuItem.Name = "mountToolStripMenuItem";
            this.mountToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.mountToolStripMenuItem.Text = "挂载";
            this.mountToolStripMenuItem.Click += new System.EventHandler(this.mountToolStripMenuItem_Click);
            // 
            // unmountToolStripMenuItem
            // 
            this.unmountToolStripMenuItem.Name = "unmountToolStripMenuItem";
            this.unmountToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.unmountToolStripMenuItem.Text = "卸载";
            this.unmountToolStripMenuItem.Click += new System.EventHandler(this.unmountToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "vhd";
            this.openFileDialog.Filter = "VHD files|*.vhd|All files|*.*";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Select VHD Files";
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(437, 25);
            this.mnuMain.TabIndex = 3;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateVDiskToolStripMenuItem,
            this.addToolStripMenuItem,
            this.mountSelectedToolStripMenuItem,
            this.unmountSelectedToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.fileToolStripMenuItem.Text = "文件";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // CreateVDiskToolStripMenuItem
            // 
            this.CreateVDiskToolStripMenuItem.Name = "CreateVDiskToolStripMenuItem";
            this.CreateVDiskToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.CreateVDiskToolStripMenuItem.Text = "创建虚拟磁盘";
            this.CreateVDiskToolStripMenuItem.Click += new System.EventHandler(this.CreateVDiskToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.addToolStripMenuItem.Text = "添加VHD";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // mountSelectedToolStripMenuItem
            // 
            this.mountSelectedToolStripMenuItem.Name = "mountSelectedToolStripMenuItem";
            this.mountSelectedToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.mountSelectedToolStripMenuItem.Text = "挂载选中的VHDs";
            this.mountSelectedToolStripMenuItem.Click += new System.EventHandler(this.mountSelectedToolStripMenuItem_Click);
            // 
            // unmountSelectedToolStripMenuItem
            // 
            this.unmountSelectedToolStripMenuItem.Name = "unmountSelectedToolStripMenuItem";
            this.unmountSelectedToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.unmountSelectedToolStripMenuItem.Text = "卸载选中的VHDs";
            this.unmountSelectedToolStripMenuItem.Click += new System.EventHandler(this.unmountSelectedToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "退出";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.helpToolStripMenuItem.Text = "帮助";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "关于";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 260);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(437, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(32, 17);
            this.lblStatus.Text = "就绪";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 282);
            this.Controls.Add(this.clbVhdFiles);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VHD管理器 2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mnuVhdFiles.ResumeLayout(false);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbVhdFiles;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mountSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unmountSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mnuVhdFiles;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unmountToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFromDiskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateVDiskToolStripMenuItem;
    }
}

