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
            this.SuspendLayout();
            // 
            // tbDirectory
            // 
            this.tbDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDirectory.Location = new System.Drawing.Point(93, 15);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.Size = new System.Drawing.Size(350, 20);
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
            this.tbOutput.Size = new System.Drawing.Size(431, 124);
            this.tbOutput.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 373);
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
    }
}

