namespace BasicGitClient
{
    partial class Form1
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
            this.tbDirectory = new System.Windows.Forms.TextBox();
            this.btnSetDir = new System.Windows.Forms.Button();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.btnPull = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnPush = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClone = new System.Windows.Forms.Button();
            this.tbnShowOrigin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbDirectory
            // 
            this.tbDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDirectory.Location = new System.Drawing.Point(93, 15);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.Size = new System.Drawing.Size(318, 20);
            this.tbDirectory.TabIndex = 0;
            // 
            // btnSetDir
            // 
            this.btnSetDir.Location = new System.Drawing.Point(12, 12);
            this.btnSetDir.Name = "btnSetDir";
            this.btnSetDir.Size = new System.Drawing.Size(75, 23);
            this.btnSetDir.TabIndex = 1;
            this.btnSetDir.Text = "Open";
            this.btnSetDir.UseVisualStyleBackColor = true;
            this.btnSetDir.Click += new System.EventHandler(this.btnSetDir_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutput.Location = new System.Drawing.Point(12, 237);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(399, 124);
            this.tbOutput.TabIndex = 2;
            // 
            // btnPull
            // 
            this.btnPull.Location = new System.Drawing.Point(174, 41);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(75, 23);
            this.btnPull.TabIndex = 3;
            this.btnPull.Text = "Pull";
            this.btnPull.UseVisualStyleBackColor = true;
            this.btnPull.Click += new System.EventHandler(this.btnPull_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(12, 99);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 23);
            this.btnCommit.TabIndex = 4;
            this.btnCommit.Text = "Commit";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnPush
            // 
            this.btnPush.Location = new System.Drawing.Point(12, 128);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(75, 23);
            this.btnPush.TabIndex = 5;
            this.btnPush.Text = "Push";
            this.btnPush.UseVisualStyleBackColor = true;
            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(255, 41);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 6;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(336, 41);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(75, 23);
            this.btnStatus.TabIndex = 7;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 70);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClone
            // 
            this.btnClone.Location = new System.Drawing.Point(93, 41);
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(75, 23);
            this.btnClone.TabIndex = 9;
            this.btnClone.Text = "Clone";
            this.btnClone.UseVisualStyleBackColor = true;
            // 
            // tbnShowOrigin
            // 
            this.tbnShowOrigin.Location = new System.Drawing.Point(336, 70);
            this.tbnShowOrigin.Name = "tbnShowOrigin";
            this.tbnShowOrigin.Size = new System.Drawing.Size(75, 23);
            this.tbnShowOrigin.TabIndex = 10;
            this.tbnShowOrigin.Text = "Show Origin";
            this.tbnShowOrigin.UseVisualStyleBackColor = true;
            this.tbnShowOrigin.Click += new System.EventHandler(this.tbnShowOrigin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 373);
            this.Controls.Add(this.tbnShowOrigin);
            this.Controls.Add(this.btnClone);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.btnPush);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.btnPull);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.btnSetDir);
            this.Controls.Add(this.tbDirectory);
            this.Name = "Form1";
            this.Text = "BasicGit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDirectory;
        private System.Windows.Forms.Button btnSetDir;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button btnPull;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnPush;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClone;
        private System.Windows.Forms.Button tbnShowOrigin;
    }
}

