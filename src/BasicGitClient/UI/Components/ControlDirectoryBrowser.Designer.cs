﻿namespace BasicGitClient
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvDirectoryList = new System.Windows.Forms.TreeView();
            this.lbFileList = new System.Windows.Forms.ListBox();
            this.ctxMnuDirBrowser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ctxMnuDirBrowser.SuspendLayout();
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
            this.tvDirectoryList.Location = new System.Drawing.Point(3, 3);
            this.tvDirectoryList.Name = "tvDirectoryList";
            this.tvDirectoryList.Size = new System.Drawing.Size(68, 144);
            this.tvDirectoryList.TabIndex = 0;
            this.tvDirectoryList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDirectoryList_AfterSelect);
            this.tvDirectoryList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDirectoryList_NodeMouseClick);
            this.tvDirectoryList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvDirectoryList_KeyDown);
            // 
            // lbFileList
            // 
            this.lbFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFileList.FormattingEnabled = true;
            this.lbFileList.Location = new System.Drawing.Point(3, 3);
            this.lbFileList.Name = "lbFileList";
            this.lbFileList.Size = new System.Drawing.Size(66, 147);
            this.lbFileList.TabIndex = 0;
            // 
            // ctxMnuDirBrowser
            // 
            this.ctxMnuDirBrowser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDirectoryToolStripMenuItem,
            this.renameDirectoryToolStripMenuItem,
            this.deleteDirectoryToolStripMenuItem});
            this.ctxMnuDirBrowser.Name = "ctxMnuDirBrowser";
            this.ctxMnuDirBrowser.Size = new System.Drawing.Size(172, 92);
            // 
            // newDirectoryToolStripMenuItem
            // 
            this.newDirectoryToolStripMenuItem.Name = "newDirectoryToolStripMenuItem";
            this.newDirectoryToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.newDirectoryToolStripMenuItem.Text = "New Directory";
            this.newDirectoryToolStripMenuItem.Click += new System.EventHandler(this.newDirectoryToolStripMenuItem_Click);
            // 
            // renameDirectoryToolStripMenuItem
            // 
            this.renameDirectoryToolStripMenuItem.Name = "renameDirectoryToolStripMenuItem";
            this.renameDirectoryToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.renameDirectoryToolStripMenuItem.Text = "Rename Directory";
            this.renameDirectoryToolStripMenuItem.Click += new System.EventHandler(this.renameDirectoryToolStripMenuItem_Click);
            // 
            // deleteDirectoryToolStripMenuItem
            // 
            this.deleteDirectoryToolStripMenuItem.Name = "deleteDirectoryToolStripMenuItem";
            this.deleteDirectoryToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.deleteDirectoryToolStripMenuItem.Text = "Delete Directory";
            this.deleteDirectoryToolStripMenuItem.Click += new System.EventHandler(this.deleteDirectoryToolStripMenuItem_Click);
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
    }
}