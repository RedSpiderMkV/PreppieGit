namespace BasicGitClient
{
    partial class BranchesBrowser
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
            this.label1 = new System.Windows.Forms.Label();
            this.ttBranches = new System.Windows.Forms.ToolTip(this.components);
            this.tabRemote = new Dotnetrix.Controls.TabControlEX();
            this.tabPageEX3 = new Dotnetrix.Controls.TabPageEX();
            this.lvLocalBranches = new System.Windows.Forms.ListView();
            this.columnBranch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCheckedOut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageEX4 = new Dotnetrix.Controls.TabPageEX();
            this.lvRemoteBranches = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxBranchesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newBranchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.checkoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabRemote.SuspendLayout();
            this.tabPageEX3.SuspendLayout();
            this.tabPageEX4.SuspendLayout();
            this.ctxBranchesMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Branches";
            // 
            // tabRemote
            // 
            this.tabRemote.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabRemote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabRemote.Appearance = Dotnetrix.Controls.TabAppearanceEX.FlatTab;
            this.tabRemote.Controls.Add(this.tabPageEX3);
            this.tabRemote.Controls.Add(this.tabPageEX4);
            this.tabRemote.FlatBorderColor = System.Drawing.SystemColors.ControlDark;
            this.tabRemote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabRemote.Location = new System.Drawing.Point(0, 24);
            this.tabRemote.Name = "tabRemote";
            this.tabRemote.SelectedIndex = 0;
            this.tabRemote.SelectedTabFontStyle = System.Drawing.FontStyle.Regular;
            this.tabRemote.Size = new System.Drawing.Size(196, 256);
            this.tabRemote.TabIndex = 2;
            this.tabRemote.UseVisualStyles = false;
            // 
            // tabPageEX3
            // 
            this.tabPageEX3.Controls.Add(this.lvLocalBranches);
            this.tabPageEX3.Location = new System.Drawing.Point(4, 4);
            this.tabPageEX3.Name = "tabPageEX3";
            this.tabPageEX3.Size = new System.Drawing.Size(188, 227);
            this.tabPageEX3.TabIndex = 2;
            this.tabPageEX3.Text = "Local";
            // 
            // lvLocalBranches
            // 
            this.lvLocalBranches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnBranch,
            this.columnCheckedOut});
            this.lvLocalBranches.ContextMenuStrip = this.ctxBranchesMenu;
            this.lvLocalBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLocalBranches.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLocalBranches.Location = new System.Drawing.Point(0, 0);
            this.lvLocalBranches.Name = "lvLocalBranches";
            this.lvLocalBranches.Size = new System.Drawing.Size(188, 227);
            this.lvLocalBranches.TabIndex = 0;
            this.lvLocalBranches.UseCompatibleStateImageBehavior = false;
            this.lvLocalBranches.View = System.Windows.Forms.View.Details;
            this.lvLocalBranches.DoubleClick += new System.EventHandler(this.lvLocalBranches_DoubleClick);
            // 
            // columnBranch
            // 
            this.columnBranch.Text = "Branch";
            this.columnBranch.Width = 151;
            // 
            // columnCheckedOut
            // 
            this.columnCheckedOut.Text = "*";
            this.columnCheckedOut.Width = 26;
            // 
            // tabPageEX4
            // 
            this.tabPageEX4.Controls.Add(this.lvRemoteBranches);
            this.tabPageEX4.Location = new System.Drawing.Point(4, 4);
            this.tabPageEX4.Name = "tabPageEX4";
            this.tabPageEX4.Size = new System.Drawing.Size(188, 227);
            this.tabPageEX4.TabIndex = 3;
            this.tabPageEX4.Text = "Remote";
            // 
            // lvRemoteBranches
            // 
            this.lvRemoteBranches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvRemoteBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRemoteBranches.Location = new System.Drawing.Point(0, 0);
            this.lvRemoteBranches.Name = "lvRemoteBranches";
            this.lvRemoteBranches.Size = new System.Drawing.Size(188, 227);
            this.lvRemoteBranches.TabIndex = 1;
            this.lvRemoteBranches.UseCompatibleStateImageBehavior = false;
            this.lvRemoteBranches.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Branch";
            this.columnHeader2.Width = 183;
            // 
            // ctxBranchesMenu
            // 
            this.ctxBranchesMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBranchToolStripMenuItem,
            this.toolStripMenuItem2,
            this.checkoutToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.ctxBranchesMenu.Name = "ctBranchesMenu";
            this.ctxBranchesMenu.Size = new System.Drawing.Size(167, 76);
            // 
            // newBranchToolStripMenuItem
            // 
            this.newBranchToolStripMenuItem.Name = "newBranchToolStripMenuItem";
            this.newBranchToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.newBranchToolStripMenuItem.Text = "New Branch";
            this.newBranchToolStripMenuItem.Click += new System.EventHandler(this.ctxBranchesMenuToolStripItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(163, 6);
            // 
            // checkoutToolStripMenuItem
            // 
            this.checkoutToolStripMenuItem.Name = "checkoutToolStripMenuItem";
            this.checkoutToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.checkoutToolStripMenuItem.Text = "Checkout Branch";
            this.checkoutToolStripMenuItem.Click += new System.EventHandler(this.ctxBranchesMenuToolStripItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.deleteToolStripMenuItem.Text = "Delete Branch";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.ctxBranchesMenuToolStripItem_Click);
            // 
            // BranchesBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabRemote);
            this.Controls.Add(this.label1);
            this.Name = "BranchesBrowser";
            this.Size = new System.Drawing.Size(196, 280);
            this.tabRemote.ResumeLayout(false);
            this.tabPageEX3.ResumeLayout(false);
            this.tabPageEX4.ResumeLayout(false);
            this.ctxBranchesMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip ttBranches;
        private Dotnetrix.Controls.TabControlEX tabRemote;
        private Dotnetrix.Controls.TabPageEX tabPageEX3;
        private System.Windows.Forms.ListView lvLocalBranches;
        private System.Windows.Forms.ColumnHeader columnCheckedOut;
        private System.Windows.Forms.ColumnHeader columnBranch;
        private Dotnetrix.Controls.TabPageEX tabPageEX4;
        private System.Windows.Forms.ListView lvRemoteBranches;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip ctxBranchesMenu;
        private System.Windows.Forms.ToolStripMenuItem newBranchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem checkoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}
