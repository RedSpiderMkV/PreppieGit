namespace BasicGitClient
{
    partial class ControlDirectoryBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlDirectoryBrowser));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvDirectoryList = new System.Windows.Forms.TreeView();
            this.ctxMnuDirBrowser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListDirectory = new System.Windows.Forms.ImageList(this.components);
            this.lbFileList = new System.Windows.Forms.ListBox();
            this.ctxMnuFileBrowser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvDirectoryList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbFileList);
            this.splitContainer1.Size = new System.Drawing.Size(150, 150);
            this.splitContainer1.SplitterDistance = 74;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvDirectoryList
            // 
            this.tvDirectoryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvDirectoryList.ContextMenuStrip = this.ctxMnuDirBrowser;
            this.tvDirectoryList.ImageIndex = 0;
            this.tvDirectoryList.ImageList = this.imageListDirectory;
            this.tvDirectoryList.Location = new System.Drawing.Point(3, 3);
            this.tvDirectoryList.Name = "tvDirectoryList";
            this.tvDirectoryList.SelectedImageIndex = 0;
            this.tvDirectoryList.Size = new System.Drawing.Size(68, 144);
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
            this.deleteDirectoryToolStripMenuItem});
            this.ctxMnuDirBrowser.Name = "ctxMnuDirBrowser";
            this.ctxMnuDirBrowser.Size = new System.Drawing.Size(172, 70);
            // 
            // newDirectoryToolStripMenuItem
            // 
            this.newDirectoryToolStripMenuItem.Name = "newDirectoryToolStripMenuItem";
            this.newDirectoryToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.newDirectoryToolStripMenuItem.Text = "New Directory";
            this.newDirectoryToolStripMenuItem.Click += new System.EventHandler(this.toolStripDirectoryMenuItem_Click);
            // 
            // renameDirectoryToolStripMenuItem
            // 
            this.renameDirectoryToolStripMenuItem.Name = "renameDirectoryToolStripMenuItem";
            this.renameDirectoryToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.renameDirectoryToolStripMenuItem.Text = "Rename Directory";
            this.renameDirectoryToolStripMenuItem.Click += new System.EventHandler(this.toolStripDirectoryMenuItem_Click);
            // 
            // deleteDirectoryToolStripMenuItem
            // 
            this.deleteDirectoryToolStripMenuItem.Name = "deleteDirectoryToolStripMenuItem";
            this.deleteDirectoryToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.deleteDirectoryToolStripMenuItem.Text = "Delete Directory";
            this.deleteDirectoryToolStripMenuItem.Click += new System.EventHandler(this.toolStripDirectoryMenuItem_Click);
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
            this.lbFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFileList.ContextMenuStrip = this.ctxMnuFileBrowser;
            this.lbFileList.FormattingEnabled = true;
            this.lbFileList.Location = new System.Drawing.Point(3, 3);
            this.lbFileList.Name = "lbFileList";
            this.lbFileList.Size = new System.Drawing.Size(66, 147);
            this.lbFileList.TabIndex = 0;
            // 
            // ctxMnuFileBrowser
            // 
            this.ctxMnuFileBrowser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileToolStripMenuItem,
            this.toolStripMenuItem2,
            this.openFileToolStripMenuItem,
            this.renameFileToolStripMenuItem,
            this.deleteFileToolStripMenuItem});
            this.ctxMnuFileBrowser.Name = "ctxMnuFileBrowser";
            this.ctxMnuFileBrowser.Size = new System.Drawing.Size(153, 120);
            this.ctxMnuFileBrowser.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMnuFileBrowser_Opening);
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newFileToolStripMenuItem.Tag = "0";
            this.newFileToolStripMenuItem.Text = "New File";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.toolStripFileMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openFileToolStripMenuItem.Tag = "1";
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.toolStripFileMenuItem_Click);
            // 
            // renameFileToolStripMenuItem
            // 
            this.renameFileToolStripMenuItem.Name = "renameFileToolStripMenuItem";
            this.renameFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.renameFileToolStripMenuItem.Tag = "2";
            this.renameFileToolStripMenuItem.Text = "Rename File";
            this.renameFileToolStripMenuItem.Click += new System.EventHandler(this.toolStripFileMenuItem_Click);
            // 
            // deleteFileToolStripMenuItem
            // 
            this.deleteFileToolStripMenuItem.Name = "deleteFileToolStripMenuItem";
            this.deleteFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteFileToolStripMenuItem.Tag = "3";
            this.deleteFileToolStripMenuItem.Text = "Delete File";
            this.deleteFileToolStripMenuItem.Click += new System.EventHandler(this.toolStripFileMenuItem_Click);
            // 
            // ControlDirectoryBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ControlDirectoryBrowser";
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
    }
}
