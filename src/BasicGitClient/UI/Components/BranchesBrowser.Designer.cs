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
            this.lbLocalBranches = new System.Windows.Forms.ListBox();
            this.tabRemote = new Dotnetrix.Controls.TabControlEX();
            this.tabPageEX1 = new Dotnetrix.Controls.TabPageEX();
            this.tabPageEX2 = new Dotnetrix.Controls.TabPageEX();
            this.lbRemoteBranches = new System.Windows.Forms.ListBox();
            this.tabRemote.SuspendLayout();
            this.tabPageEX1.SuspendLayout();
            this.tabPageEX2.SuspendLayout();
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
            // lbLocalBranches
            // 
            this.lbLocalBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLocalBranches.FormattingEnabled = true;
            this.lbLocalBranches.IntegralHeight = false;
            this.lbLocalBranches.Location = new System.Drawing.Point(0, 0);
            this.lbLocalBranches.Name = "lbLocalBranches";
            this.lbLocalBranches.Size = new System.Drawing.Size(188, 227);
            this.lbLocalBranches.TabIndex = 7;
            this.ttBranches.SetToolTip(this.lbLocalBranches, "Double click a branch to checkout");
            // 
            // tabRemote
            // 
            this.tabRemote.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabRemote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabRemote.Appearance = Dotnetrix.Controls.TabAppearanceEX.FlatTab;
            this.tabRemote.Controls.Add(this.tabPageEX1);
            this.tabRemote.Controls.Add(this.tabPageEX2);
            this.tabRemote.FlatBorderColor = System.Drawing.SystemColors.ControlDark;
            this.tabRemote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabRemote.Location = new System.Drawing.Point(0, 24);
            this.tabRemote.Name = "tabRemote";
            this.tabRemote.SelectedIndex = 1;
            this.tabRemote.SelectedTabFontStyle = System.Drawing.FontStyle.Regular;
            this.tabRemote.Size = new System.Drawing.Size(196, 256);
            this.tabRemote.TabIndex = 2;
            this.tabRemote.UseVisualStyles = false;
            // 
            // tabPageEX1
            // 
            this.tabPageEX1.Controls.Add(this.lbLocalBranches);
            this.tabPageEX1.Location = new System.Drawing.Point(4, 4);
            this.tabPageEX1.Name = "tabPageEX1";
            this.tabPageEX1.Size = new System.Drawing.Size(188, 227);
            this.tabPageEX1.TabIndex = 0;
            this.tabPageEX1.Text = "Local";
            // 
            // tabPageEX2
            // 
            this.tabPageEX2.Controls.Add(this.lbRemoteBranches);
            this.tabPageEX2.Location = new System.Drawing.Point(4, 4);
            this.tabPageEX2.Name = "tabPageEX2";
            this.tabPageEX2.Size = new System.Drawing.Size(188, 227);
            this.tabPageEX2.TabIndex = 1;
            this.tabPageEX2.Text = "Remote";
            // 
            // lbRemoteBranches
            // 
            this.lbRemoteBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRemoteBranches.FormattingEnabled = true;
            this.lbRemoteBranches.IntegralHeight = false;
            this.lbRemoteBranches.Location = new System.Drawing.Point(0, 0);
            this.lbRemoteBranches.Name = "lbRemoteBranches";
            this.lbRemoteBranches.Size = new System.Drawing.Size(188, 227);
            this.lbRemoteBranches.TabIndex = 8;
            // 
            // BranchesBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabRemote);
            this.Controls.Add(this.label1);
            this.Name = "BranchesBrowser";
            this.Size = new System.Drawing.Size(196, 280);
            this.Resize += new System.EventHandler(this.BranchesBrowser_Resize);
            this.tabRemote.ResumeLayout(false);
            this.tabPageEX1.ResumeLayout(false);
            this.tabPageEX2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip ttBranches;
        private Dotnetrix.Controls.TabControlEX tabRemote;
        private Dotnetrix.Controls.TabPageEX tabPageEX1;
        private System.Windows.Forms.ListBox lbLocalBranches;
        private Dotnetrix.Controls.TabPageEX tabPageEX2;
        private System.Windows.Forms.ListBox lbRemoteBranches;
    }
}
