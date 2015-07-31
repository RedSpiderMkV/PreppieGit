namespace BasicGitClient
{
    partial class ButtonGroup
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
            this.btnScrollRight = new System.Windows.Forms.Button();
            this.btnScrollLeft = new System.Windows.Forms.Button();
            this.panelInner = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnPush = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnPull = new System.Windows.Forms.Button();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelInner.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnScrollRight
            // 
            this.btnScrollRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScrollRight.Location = new System.Drawing.Point(466, 6);
            this.btnScrollRight.Name = "btnScrollRight";
            this.btnScrollRight.Size = new System.Drawing.Size(15, 32);
            this.btnScrollRight.TabIndex = 0;
            this.btnScrollRight.Text = ">";
            this.btnScrollRight.UseVisualStyleBackColor = true;
            this.btnScrollRight.Click += new System.EventHandler(this.btnScroll_Click);
            // 
            // btnScrollLeft
            // 
            this.btnScrollLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnScrollLeft.Location = new System.Drawing.Point(0, 6);
            this.btnScrollLeft.Name = "btnScrollLeft";
            this.btnScrollLeft.Size = new System.Drawing.Size(15, 32);
            this.btnScrollLeft.TabIndex = 1;
            this.btnScrollLeft.Text = "<";
            this.btnScrollLeft.UseVisualStyleBackColor = true;
            this.btnScrollLeft.Click += new System.EventHandler(this.btnScroll_Click);
            // 
            // panelInner
            // 
            this.panelInner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panelInner.Controls.Add(this.btnAdd);
            this.panelInner.Controls.Add(this.btnStatus);
            this.panelInner.Controls.Add(this.btnPush);
            this.panelInner.Controls.Add(this.btnCommit);
            this.panelInner.Controls.Add(this.btnPull);
            this.panelInner.Location = new System.Drawing.Point(3, 3);
            this.panelInner.Name = "panelInner";
            this.panelInner.Size = new System.Drawing.Size(433, 28);
            this.panelInner.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(327, 3);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(75, 23);
            this.btnStatus.TabIndex = 12;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnPush
            // 
            this.btnPush.Location = new System.Drawing.Point(165, 3);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(75, 23);
            this.btnPush.TabIndex = 11;
            this.btnPush.Text = "Push";
            this.btnPush.UseVisualStyleBackColor = true;
            this.btnPush.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(84, 3);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 23);
            this.btnCommit.TabIndex = 10;
            this.btnCommit.Text = "Commit";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnPull
            // 
            this.btnPull.Location = new System.Drawing.Point(246, 3);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(75, 23);
            this.btnPull.TabIndex = 9;
            this.btnPull.Text = "Pull";
            this.btnPull.UseVisualStyleBackColor = true;
            this.btnPull.Click += new System.EventHandler(this.btn_Click);
            // 
            // panelOuter
            // 
            this.panelOuter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOuter.Controls.Add(this.panelInner);
            this.panelOuter.Location = new System.Drawing.Point(21, 3);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(439, 35);
            this.panelOuter.TabIndex = 12;
            // 
            // ButtonGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelOuter);
            this.Controls.Add(this.btnScrollLeft);
            this.Controls.Add(this.btnScrollRight);
            this.Name = "ButtonGroup";
            this.Size = new System.Drawing.Size(481, 44);
            this.panelInner.ResumeLayout(false);
            this.panelOuter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScrollRight;
        private System.Windows.Forms.Button btnScrollLeft;
        private System.Windows.Forms.Panel panelInner;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnPush;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnPull;
    }
}
