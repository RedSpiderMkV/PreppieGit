namespace BasicGitClient
{
    internal partial class BranchBrowser
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbLocalBranches = new System.Windows.Forms.ListBox();
            this.lblLocalBranches = new System.Windows.Forms.Label();
            this.lbRemoteBranches = new System.Windows.Forms.ListBox();
            this.lblRemoteBranches = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbLocalBranches);
            this.splitContainer1.Panel1.Controls.Add(this.lblLocalBranches);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbRemoteBranches);
            this.splitContainer1.Panel2.Controls.Add(this.lblRemoteBranches);
            this.splitContainer1.Size = new System.Drawing.Size(269, 246);
            this.splitContainer1.SplitterDistance = 128;
            this.splitContainer1.TabIndex = 0;
            // 
            // lbLocalBranches
            // 
            this.lbLocalBranches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLocalBranches.FormattingEnabled = true;
            this.lbLocalBranches.IntegralHeight = false;
            this.lbLocalBranches.Location = new System.Drawing.Point(0, 19);
            this.lbLocalBranches.Name = "lbLocalBranches";
            this.lbLocalBranches.Size = new System.Drawing.Size(269, 111);
            this.lbLocalBranches.TabIndex = 4;
            // 
            // lblLocalBranches
            // 
            this.lblLocalBranches.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocalBranches.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblLocalBranches.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalBranches.Location = new System.Drawing.Point(0, 0);
            this.lblLocalBranches.Name = "lblLocalBranches";
            this.lblLocalBranches.Size = new System.Drawing.Size(269, 19);
            this.lblLocalBranches.TabIndex = 5;
            this.lblLocalBranches.Text = "Local Branches";
            // 
            // lbRemoteBranches
            // 
            this.lbRemoteBranches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRemoteBranches.FormattingEnabled = true;
            this.lbRemoteBranches.IntegralHeight = false;
            this.lbRemoteBranches.Location = new System.Drawing.Point(0, 20);
            this.lbRemoteBranches.Name = "lbRemoteBranches";
            this.lbRemoteBranches.Size = new System.Drawing.Size(269, 94);
            this.lbRemoteBranches.TabIndex = 6;
            // 
            // lblRemoteBranches
            // 
            this.lblRemoteBranches.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemoteBranches.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblRemoteBranches.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemoteBranches.Location = new System.Drawing.Point(0, 1);
            this.lblRemoteBranches.Name = "lblRemoteBranches";
            this.lblRemoteBranches.Size = new System.Drawing.Size(269, 19);
            this.lblRemoteBranches.TabIndex = 7;
            this.lblRemoteBranches.Text = "Remote Branches";
            // 
            // BranchBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "BranchBrowser";
            this.Size = new System.Drawing.Size(269, 246);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lbLocalBranches;
        private System.Windows.Forms.Label lblLocalBranches;
        private System.Windows.Forms.ListBox lbRemoteBranches;
        private System.Windows.Forms.Label lblRemoteBranches;
    }
}
