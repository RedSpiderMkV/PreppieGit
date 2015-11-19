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
            this.tabRemote = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbLocalBranches = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbRemoteBranches = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ttBranches = new System.Windows.Forms.ToolTip(this.components);
            this.tabRemote.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabRemote
            // 
            this.tabRemote.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabRemote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabRemote.Controls.Add(this.tabPage1);
            this.tabRemote.Controls.Add(this.tabPage2);
            this.tabRemote.Location = new System.Drawing.Point(0, 21);
            this.tabRemote.Name = "tabRemote";
            this.tabRemote.SelectedIndex = 0;
            this.tabRemote.Size = new System.Drawing.Size(302, 259);
            this.tabRemote.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbLocalBranches);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(294, 233);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbLocalBranches
            // 
            this.lbLocalBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLocalBranches.FormattingEnabled = true;
            this.lbLocalBranches.IntegralHeight = false;
            this.lbLocalBranches.Location = new System.Drawing.Point(3, 3);
            this.lbLocalBranches.Name = "lbLocalBranches";
            this.lbLocalBranches.Size = new System.Drawing.Size(288, 227);
            this.lbLocalBranches.TabIndex = 6;
            this.ttBranches.SetToolTip(this.lbLocalBranches, "Double click a branch to checkout");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbRemoteBranches);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(294, 233);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Remote";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbRemoteBranches
            // 
            this.lbRemoteBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRemoteBranches.FormattingEnabled = true;
            this.lbRemoteBranches.IntegralHeight = false;
            this.lbRemoteBranches.Location = new System.Drawing.Point(3, 3);
            this.lbRemoteBranches.Name = "lbRemoteBranches";
            this.lbRemoteBranches.Size = new System.Drawing.Size(288, 227);
            this.lbRemoteBranches.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Branches";
            // 
            // BranchesBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabRemote);
            this.Name = "BranchesBrowser";
            this.Size = new System.Drawing.Size(302, 280);
            this.tabRemote.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabRemote;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbRemoteBranches;
        private System.Windows.Forms.ListBox lbLocalBranches;
        private System.Windows.Forms.ToolTip ttBranches;
    }
}
