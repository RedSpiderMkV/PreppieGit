namespace BasicGitClient
{
    partial class ClientMainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientMainWindow));
            this.tbDirectory = new System.Windows.Forms.TextBox();
            this.btnPull = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnPush = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.mnuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setCredentialsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.configureRepoUsernameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.configureEmailAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setOriginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToHeadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initialiseNewRepoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOriginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pushAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revertLastChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commitChangesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.updategitignoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeRepoUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.cMenuOutputBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMenuOutputBox_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.tvDirectoryList = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbFileList = new System.Windows.Forms.ListBox();
            this.cMnuFileViewer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.mnuStrip.SuspendLayout();
            this.cMenuOutputBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cMnuFileViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDirectory
            // 
            this.tbDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDirectory.Location = new System.Drawing.Point(10, 62);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.Size = new System.Drawing.Size(399, 20);
            this.tbDirectory.TabIndex = 0;
            // 
            // btnPull
            // 
            this.btnPull.Location = new System.Drawing.Point(253, 88);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(75, 23);
            this.btnPull.TabIndex = 3;
            this.btnPull.Text = "Pull";
            this.btnPull.UseVisualStyleBackColor = true;
            this.btnPull.Click += new System.EventHandler(this.btnPull_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(91, 88);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 23);
            this.btnCommit.TabIndex = 4;
            this.btnCommit.Text = "Commit";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnPush
            // 
            this.btnPush.Location = new System.Drawing.Point(172, 88);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(75, 23);
            this.btnPush.TabIndex = 5;
            this.btnPush.Text = "Push";
            this.btnPush.UseVisualStyleBackColor = true;
            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(334, 88);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(75, 23);
            this.btnStatus.TabIndex = 7;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(10, 88);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // mnuStrip
            // 
            this.mnuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.mnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.connectionToolStripMenuItem,
            this.advancedToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mnuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuStrip.Name = "mnuStrip";
            this.mnuStrip.Size = new System.Drawing.Size(423, 24);
            this.mnuStrip.TabIndex = 11;
            this.mnuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(148, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setCredentialsToolStripMenuItem1,
            this.configureRepoUsernameToolStripMenuItem1,
            this.configureEmailAddressToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // setCredentialsToolStripMenuItem1
            // 
            this.setCredentialsToolStripMenuItem1.Name = "setCredentialsToolStripMenuItem1";
            this.setCredentialsToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
            this.setCredentialsToolStripMenuItem1.Text = "Set Credentials";
            this.setCredentialsToolStripMenuItem1.Click += new System.EventHandler(this.configureEmailToolStripMenuItem_Click);
            // 
            // configureRepoUsernameToolStripMenuItem1
            // 
            this.configureRepoUsernameToolStripMenuItem1.Name = "configureRepoUsernameToolStripMenuItem1";
            this.configureRepoUsernameToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
            this.configureRepoUsernameToolStripMenuItem1.Text = "Configure Repo Username";
            this.configureRepoUsernameToolStripMenuItem1.Click += new System.EventHandler(this.configureRepoUsernameToolStripMenuItem_Click);
            // 
            // configureEmailAddressToolStripMenuItem
            // 
            this.configureEmailAddressToolStripMenuItem.Name = "configureEmailAddressToolStripMenuItem";
            this.configureEmailAddressToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.configureEmailAddressToolStripMenuItem.Text = "Configure Email Address";
            this.configureEmailAddressToolStripMenuItem.Click += new System.EventHandler(this.configureRepoEmailToolStripMenuItem_Click);
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setOriginToolStripMenuItem,
            this.resetToHeadToolStripMenuItem,
            this.cloneToolStripMenuItem,
            this.initialiseNewRepoToolStripMenuItem,
            this.showOriginToolStripMenuItem,
            this.pushAllToolStripMenuItem,
            this.revertLastChangeToolStripMenuItem,
            this.commitChangesToolStripMenuItem1,
            this.updategitignoreToolStripMenuItem,
            this.changeRepoUrlToolStripMenuItem});
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.advancedToolStripMenuItem.Text = "Actions";
            // 
            // setOriginToolStripMenuItem
            // 
            this.setOriginToolStripMenuItem.Name = "setOriginToolStripMenuItem";
            this.setOriginToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.setOriginToolStripMenuItem.Text = "Set Repo Url";
            this.setOriginToolStripMenuItem.Click += new System.EventHandler(this.setOriginToolStripMenuItem_Click);
            // 
            // resetToHeadToolStripMenuItem
            // 
            this.resetToHeadToolStripMenuItem.Name = "resetToHeadToolStripMenuItem";
            this.resetToHeadToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.resetToHeadToolStripMenuItem.Text = "Reset to Head";
            this.resetToHeadToolStripMenuItem.Click += new System.EventHandler(this.resetToHeadToolStripMenuItem_Click);
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.cloneToolStripMenuItem.Text = "Clone";
            this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
            // 
            // initialiseNewRepoToolStripMenuItem
            // 
            this.initialiseNewRepoToolStripMenuItem.Name = "initialiseNewRepoToolStripMenuItem";
            this.initialiseNewRepoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.initialiseNewRepoToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.initialiseNewRepoToolStripMenuItem.Text = "Initialise New Repo";
            this.initialiseNewRepoToolStripMenuItem.Click += new System.EventHandler(this.initialiseNewRepoToolStripMenuItem_Click);
            // 
            // showOriginToolStripMenuItem
            // 
            this.showOriginToolStripMenuItem.Name = "showOriginToolStripMenuItem";
            this.showOriginToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.showOriginToolStripMenuItem.Text = "Show Origin";
            this.showOriginToolStripMenuItem.Click += new System.EventHandler(this.showOriginToolStripMenuItem_Click);
            // 
            // pushAllToolStripMenuItem
            // 
            this.pushAllToolStripMenuItem.Name = "pushAllToolStripMenuItem";
            this.pushAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.P)));
            this.pushAllToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.pushAllToolStripMenuItem.Text = "Push All";
            this.pushAllToolStripMenuItem.ToolTipText = "Add, commit, push all changes";
            this.pushAllToolStripMenuItem.Click += new System.EventHandler(this.pushAllToolStripMenuItem_Click);
            // 
            // revertLastChangeToolStripMenuItem
            // 
            this.revertLastChangeToolStripMenuItem.Name = "revertLastChangeToolStripMenuItem";
            this.revertLastChangeToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.revertLastChangeToolStripMenuItem.Text = "Revert Last Change";
            this.revertLastChangeToolStripMenuItem.Click += new System.EventHandler(this.revertLastChangeToolStripMenuItem_Click);
            // 
            // commitChangesToolStripMenuItem1
            // 
            this.commitChangesToolStripMenuItem1.Name = "commitChangesToolStripMenuItem1";
            this.commitChangesToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.commitChangesToolStripMenuItem1.Text = "Commit Changes";
            this.commitChangesToolStripMenuItem1.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // updategitignoreToolStripMenuItem
            // 
            this.updategitignoreToolStripMenuItem.Name = "updategitignoreToolStripMenuItem";
            this.updategitignoreToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.updategitignoreToolStripMenuItem.Text = "Update .gitignore";
            this.updategitignoreToolStripMenuItem.Click += new System.EventHandler(this.updategitignoreToolStripMenuItem_Click);
            // 
            // changeRepoUrlToolStripMenuItem
            // 
            this.changeRepoUrlToolStripMenuItem.Name = "changeRepoUrlToolStripMenuItem";
            this.changeRepoUrlToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.changeRepoUrlToolStripMenuItem.Text = "Change Repo Url";
            this.changeRepoUrlToolStripMenuItem.Click += new System.EventHandler(this.changeRepoUrlToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contactToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // contactToolStripMenuItem
            // 
            this.contactToolStripMenuItem.Name = "contactToolStripMenuItem";
            this.contactToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.contactToolStripMenuItem.Text = "Contact";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Git Location";
            // 
            // rtbOutput
            // 
            this.rtbOutput.BackColor = System.Drawing.SystemColors.Window;
            this.rtbOutput.ContextMenuStrip = this.cMenuOutputBox;
            this.rtbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbOutput.Location = new System.Drawing.Point(0, 0);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(396, 181);
            this.rtbOutput.TabIndex = 14;
            this.rtbOutput.Text = "";
            this.rtbOutput.TextChanged += new System.EventHandler(this.rtbOutput_TextChanged);
            // 
            // cMenuOutputBox
            // 
            this.cMenuOutputBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMenuOutputBox_Clear});
            this.cMenuOutputBox.Name = "cMenuOutputBox";
            this.cMenuOutputBox.Size = new System.Drawing.Size(153, 48);
            // 
            // cMenuOutputBox_Clear
            // 
            this.cMenuOutputBox_Clear.Name = "cMenuOutputBox_Clear";
            this.cMenuOutputBox_Clear.Size = new System.Drawing.Size(152, 22);
            this.cMenuOutputBox_Clear.Text = "Clear";
            this.cMenuOutputBox_Clear.Click += new System.EventHandler(this.cMenuOutputBox_Clear_Click);
            // 
            // tvDirectoryList
            // 
            this.tvDirectoryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDirectoryList.Location = new System.Drawing.Point(0, 0);
            this.tvDirectoryList.Name = "tvDirectoryList";
            this.tvDirectoryList.Size = new System.Drawing.Size(195, 184);
            this.tvDirectoryList.TabIndex = 15;
            this.tvDirectoryList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDirectoryList_AfterSelect);
            this.tvDirectoryList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDirectoryList_NodeMouseClick);
            this.tvDirectoryList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvDirectoryList_KeyDown);
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
            this.splitContainer1.Size = new System.Drawing.Size(396, 184);
            this.splitContainer1.SplitterDistance = 195;
            this.splitContainer1.TabIndex = 16;
            // 
            // lbFileList
            // 
            this.lbFileList.ContextMenuStrip = this.cMnuFileViewer;
            this.lbFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFileList.FormattingEnabled = true;
            this.lbFileList.IntegralHeight = false;
            this.lbFileList.Location = new System.Drawing.Point(0, 0);
            this.lbFileList.Name = "lbFileList";
            this.lbFileList.Size = new System.Drawing.Size(197, 184);
            this.lbFileList.TabIndex = 0;
            // 
            // cMnuFileViewer
            // 
            this.cMnuFileViewer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.openFileToolStripMenuItem,
            this.renameFileToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.deleteFolderToolStripMenuItem});
            this.cMnuFileViewer.Name = "cMnuFileViewer";
            this.cMnuFileViewer.Size = new System.Drawing.Size(150, 120);
            this.cMnuFileViewer.Opening += new System.ComponentModel.CancelEventHandler(this.cMnuFileViewer_Opening);
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.newFileToolStripMenuItem.Text = "New File";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.newFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 6);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // renameFileToolStripMenuItem
            // 
            this.renameFileToolStripMenuItem.Name = "renameFileToolStripMenuItem";
            this.renameFileToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.renameFileToolStripMenuItem.Text = "Rename File";
            this.renameFileToolStripMenuItem.Click += new System.EventHandler(this.renameFileToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.deleteToolStripMenuItem.Text = "Delete File";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // deleteFolderToolStripMenuItem
            // 
            this.deleteFolderToolStripMenuItem.Name = "deleteFolderToolStripMenuItem";
            this.deleteFolderToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.deleteFolderToolStripMenuItem.Text = "Delete Folder";
            this.deleteFolderToolStripMenuItem.Click += new System.EventHandler(this.deleteFolderToolStripMenuItem_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(13, 117);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.rtbOutput);
            this.splitContainer2.Size = new System.Drawing.Size(396, 369);
            this.splitContainer2.SplitterDistance = 184;
            this.splitContainer2.TabIndex = 17;
            // 
            // ClientMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 498);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnPush);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.btnPull);
            this.Controls.Add(this.tbDirectory);
            this.Controls.Add(this.mnuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuStrip;
            this.Name = "ClientMainWindow";
            this.Text = "PreppieGit";
            this.mnuStrip.ResumeLayout(false);
            this.mnuStrip.PerformLayout();
            this.cMenuOutputBox.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cMnuFileViewer.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDirectory;
        private System.Windows.Forms.Button btnPull;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnPush;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.MenuStrip mnuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setOriginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToHeadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initialiseNewRepoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showOriginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pushAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem revertLastChangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commitChangesToolStripMenuItem1;
        private System.Windows.Forms.TreeView tvDirectoryList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lbFileList;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ContextMenuStrip cMnuFileViewer;
        private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem updategitignoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeRepoUrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setCredentialsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem configureRepoUsernameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem configureEmailAddressToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cMenuOutputBox;
        private System.Windows.Forms.ToolStripMenuItem cMenuOutputBox_Clear;
    }
}

