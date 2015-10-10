namespace BasicGitClient
{
    partial class DirectoryBrowser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryBrowser));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvDirectoryList = new System.Windows.Forms.TreeView();
            this.ctxMnuDirBrowser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListDirectory = new System.Windows.Forms.ImageList(this.components);
            this.lbFileList = new System.Windows.Forms.ListBox();
            this.ctxMnuFileBrowser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openInExplorerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDirectoryList = new System.Windows.Forms.Label();
            this.lblFileList = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ctxMnuDirBrowser.SuspendLayout();
            this.ctxMnuFileBrowser.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 19);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvDirectoryList);
            this.splitContainer1.Panel1.Resize += new System.EventHandler(this.splitContainer1_Panel1_Resize);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbFileList);
            this.splitContainer1.Size = new System.Drawing.Size(150, 131);
            this.splitContainer1.SplitterDistance = 74;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvDirectoryList
            // 
            this.tvDirectoryList.ContextMenuStrip = this.ctxMnuDirBrowser;
            this.tvDirectoryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDirectoryList.ImageIndex = 0;
            this.tvDirectoryList.ImageList = this.imageListDirectory;
            this.tvDirectoryList.Location = new System.Drawing.Point(0, 0);
            this.tvDirectoryList.Name = "tvDirectoryList";
            this.tvDirectoryList.SelectedImageIndex = 0;
            this.tvDirectoryList.Size = new System.Drawing.Size(74, 131);
            this.tvDirectoryList.TabIndex = 0;
            this.tvDirectoryList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDirectoryList_AfterSelect);
            this.tvDirectoryList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDirectoryList_NodeMouseClick);
            this.tvDirectoryList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDirectoryList_NodeMouseClick);
            this.tvDirectoryList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvDirectoryList_KeyDown);
            // 
            // ctxMnuDirBrowser
            // 
            this.ctxMnuDirBrowser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDirectoryToolStripMenuItem,
            this.renameDirectoryToolStripMenuItem,
            this.deleteDirectoryToolStripMenuItem,
            this.toolStripSeparator1,
            this.openInExplorerToolStripMenuItem});
            this.ctxMnuDirBrowser.Name = "ctxMnuDirBrowser";
            this.ctxMnuDirBrowser.Size = new System.Drawing.Size(172, 98);
            // 
            // newDirectoryToolStripMenuItem
            // 
            this.newDirectoryToolStripMenuItem.Name = "newDirectoryToolStripMenuItem";
            this.newDirectoryToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.newDirectoryToolStripMenuItem.Tag = "0";
            this.newDirectoryToolStripMenuItem.Text = "New Directory";
            this.newDirectoryToolStripMenuItem.Click += new System.EventHandler(this.toolStripDirectoryMenuItem_Click);
            // 
            // renameDirectoryToolStripMenuItem
            // 
            this.renameDirectoryToolStripMenuItem.Name = "renameDirectoryToolStripMenuItem";
            this.renameDirectoryToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.renameDirectoryToolStripMenuItem.Tag = "2";
            this.renameDirectoryToolStripMenuItem.Text = "Rename Directory";
            this.renameDirectoryToolStripMenuItem.Click += new System.EventHandler(this.toolStripDirectoryMenuItem_Click);
            // 
            // deleteDirectoryToolStripMenuItem
            // 
            this.deleteDirectoryToolStripMenuItem.Name = "deleteDirectoryToolStripMenuItem";
            this.deleteDirectoryToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.deleteDirectoryToolStripMenuItem.Tag = "3";
            this.deleteDirectoryToolStripMenuItem.Text = "Delete Directory";
            this.deleteDirectoryToolStripMenuItem.Click += new System.EventHandler(this.toolStripDirectoryMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // openInExplorerToolStripMenuItem
            // 
            this.openInExplorerToolStripMenuItem.Name = "openInExplorerToolStripMenuItem";
            this.openInExplorerToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.openInExplorerToolStripMenuItem.Tag = "4";
            this.openInExplorerToolStripMenuItem.Text = "Open In Explorer";
            this.openInExplorerToolStripMenuItem.Click += new System.EventHandler(this.toolStripDirectoryMenuItem_Click);
            // 
            // imageListDirectory
            // 
            this.imageListDirectory.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListDirectory.ImageStream")));
            this.imageListDirectory.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListDirectory.Images.SetKeyName(0, "closedFolder.png");
            this.imageListDirectory.Images.SetKeyName(1, "openFolder.png");
            // 
            // lbFileList
            // 
            this.lbFileList.ContextMenuStrip = this.ctxMnuFileBrowser;
            this.lbFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFileList.FormattingEnabled = true;
            this.lbFileList.IntegralHeight = false;
            this.lbFileList.Location = new System.Drawing.Point(0, 0);
            this.lbFileList.Name = "lbFileList";
            this.lbFileList.Size = new System.Drawing.Size(72, 131);
            this.lbFileList.TabIndex = 0;
            this.lbFileList.Resize += new System.EventHandler(this.lbFileList_Resize);
            // 
            // ctxMnuFileBrowser
            // 
            this.ctxMnuFileBrowser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileToolStripMenuItem,
            this.toolStripMenuItem2,
            this.openFileToolStripMenuItem,
            this.renameFileToolStripMenuItem,
            this.deleteFileToolStripMenuItem,
            this.toolStripSeparator2,
            this.openInExplorerToolStripMenuItem1});
            this.ctxMnuFileBrowser.Name = "ctxMnuFileBrowser";
            this.ctxMnuFileBrowser.Size = new System.Drawing.Size(168, 148);
            this.ctxMnuFileBrowser.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMnuFileBrowser_Opening);
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.newFileToolStripMenuItem.Tag = "0";
            this.newFileToolStripMenuItem.Text = "New File";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.toolStripFileMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(164, 6);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.openFileToolStripMenuItem.Tag = "1";
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.toolStripFileMenuItem_Click);
            // 
            // renameFileToolStripMenuItem
            // 
            this.renameFileToolStripMenuItem.Name = "renameFileToolStripMenuItem";
            this.renameFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.renameFileToolStripMenuItem.Tag = "2";
            this.renameFileToolStripMenuItem.Text = "Rename File";
            this.renameFileToolStripMenuItem.Click += new System.EventHandler(this.toolStripFileMenuItem_Click);
            // 
            // deleteFileToolStripMenuItem
            // 
            this.deleteFileToolStripMenuItem.Name = "deleteFileToolStripMenuItem";
            this.deleteFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.deleteFileToolStripMenuItem.Tag = "3";
            this.deleteFileToolStripMenuItem.Text = "Delete File";
            this.deleteFileToolStripMenuItem.Click += new System.EventHandler(this.toolStripFileMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
            // 
            // openInExplorerToolStripMenuItem1
            // 
            this.openInExplorerToolStripMenuItem1.Name = "openInExplorerToolStripMenuItem1";
            this.openInExplorerToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.openInExplorerToolStripMenuItem1.Tag = "4";
            this.openInExplorerToolStripMenuItem1.Text = "Open In Explorer";
            this.openInExplorerToolStripMenuItem1.Click += new System.EventHandler(this.toolStripFileMenuItem_Click);
            // 
            // lblDirectoryList
            // 
            this.lblDirectoryList.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblDirectoryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirectoryList.Location = new System.Drawing.Point(0, 0);
            this.lblDirectoryList.Name = "lblDirectoryList";
            this.lblDirectoryList.Size = new System.Drawing.Size(74, 19);
            this.lblDirectoryList.TabIndex = 2;
            this.lblDirectoryList.Text = "Directory";
            // 
            // lblFileList
            // 
            this.lblFileList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFileList.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblFileList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileList.Location = new System.Drawing.Point(78, 0);
            this.lblFileList.Name = "lblFileList";
            this.lblFileList.Size = new System.Drawing.Size(72, 19);
            this.lblFileList.TabIndex = 3;
            this.lblFileList.Text = "File List";
            // 
            // DirectoryBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFileList);
            this.Controls.Add(this.lblDirectoryList);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DirectoryBrowser";
            this.Resize += new System.EventHandler(this.ControlDirectoryBrowser_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ctxMnuDirBrowser.ResumeLayout(false);
            this.ctxMnuFileBrowser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvDirectoryList;
        private System.Windows.Forms.ListBox lbFileList;
        private System.Windows.Forms.ContextMenuStrip ctxMnuDirBrowser;
        private System.Windows.Forms.ToolStripMenuItem newDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameDirectoryToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxMnuFileBrowser;
        private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ImageList imageListDirectory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openInExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem openInExplorerToolStripMenuItem1;
        private System.Windows.Forms.Label lblDirectoryList;
        private System.Windows.Forms.Label lblFileList;
    }
}
