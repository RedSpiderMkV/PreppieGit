namespace BasicGitClient
{
    partial class FileBrowser
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
            this.lbFileList = new System.Windows.Forms.ListBox();
            this.lblFileList = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbFileList
            // 
            this.lbFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFileList.FormattingEnabled = true;
            this.lbFileList.HorizontalScrollbar = true;
            this.lbFileList.IntegralHeight = false;
            this.lbFileList.Location = new System.Drawing.Point(0, 19);
            this.lbFileList.Name = "lbFileList";
            this.lbFileList.Size = new System.Drawing.Size(150, 131);
            this.lbFileList.TabIndex = 4;
            // 
            // lblFileList
            // 
            this.lblFileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFileList.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblFileList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileList.Location = new System.Drawing.Point(0, 0);
            this.lblFileList.Name = "lblFileList";
            this.lblFileList.Size = new System.Drawing.Size(150, 19);
            this.lblFileList.TabIndex = 5;
            this.lblFileList.Text = "File List";
            // 
            // FileBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbFileList);
            this.Controls.Add(this.lblFileList);
            this.Name = "FileBrowser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbFileList;
        private System.Windows.Forms.Label lblFileList;
    }
}
