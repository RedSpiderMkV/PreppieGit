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
            this.ctxMnuDirBrowser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListDirectory = new System.Windows.Forms.ImageList(this.components);
            this.tvDirectoryList = new System.Windows.Forms.TreeView();
            this.lblDirectoryList = new System.Windows.Forms.Label();
            this.ctxMnuDirBrowser.SuspendLayout();
            this.SuspendLayout();
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
            // tvDirectoryList
            // 
            this.tvDirectoryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvDirectoryList.ContextMenuStrip = this.ctxMnuDirBrowser;
            this.tvDirectoryList.ImageIndex = 0;
            this.tvDirectoryList.ImageList = this.imageListDirectory;
            this.tvDirectoryList.Location = new System.Drawing.Point(0, 19);
            this.tvDirectoryList.Name = "tvDirectoryList";
            this.tvDirectoryList.SelectedImageIndex = 0;
            this.tvDirectoryList.Size = new System.Drawing.Size(150, 131);
            this.tvDirectoryList.TabIndex = 3;
            this.tvDirectoryList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDirectoryList_NodeMouseClick);
            // 
            // lblDirectoryList
            // 
            this.lblDirectoryList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDirectoryList.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblDirectoryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirectoryList.Location = new System.Drawing.Point(0, 0);
            this.lblDirectoryList.Name = "lblDirectoryList";
            this.lblDirectoryList.Size = new System.Drawing.Size(150, 19);
            this.lblDirectoryList.TabIndex = 4;
            this.lblDirectoryList.Text = "Directory";
            // 
            // DirectoryBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvDirectoryList);
            this.Controls.Add(this.lblDirectoryList);
            this.Name = "DirectoryBrowser";
            this.Resize += new System.EventHandler(this.ControlDirectoryBrowser_Resize);
            this.ctxMnuDirBrowser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ctxMnuDirBrowser;
        private System.Windows.Forms.ToolStripMenuItem newDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameDirectoryToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListDirectory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openInExplorerToolStripMenuItem;
        private System.Windows.Forms.TreeView tvDirectoryList;
        private System.Windows.Forms.Label lblDirectoryList;
    }
}
