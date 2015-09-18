namespace BasicGitClient
{
    partial class ImageButtonControl
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
            this.lblBtnText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBtnText
            // 
            this.lblBtnText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblBtnText.AutoSize = true;
            this.lblBtnText.Location = new System.Drawing.Point(12, 43);
            this.lblBtnText.Name = "lblBtnText";
            this.lblBtnText.Size = new System.Drawing.Size(35, 13);
            this.lblBtnText.TabIndex = 0;
            this.lblBtnText.Text = "label1";
            // 
            // ImageButtonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblBtnText);
            this.DoubleBuffered = true;
            this.Name = "ImageButtonControl";
            this.Size = new System.Drawing.Size(60, 60);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ImageButtonControl_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageButtonControl_MouseDown);
            this.MouseEnter += new System.EventHandler(this.ImageButtonControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ImageButtonControl_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageButtonControl_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBtnText;
    }
}
