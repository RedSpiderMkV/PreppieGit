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
            this.panelInner = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnPush = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnPull = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInner
            // 
            this.panelInner.Controls.Add(this.btnRefresh);
            this.panelInner.Controls.Add(this.btnAdd);
            this.panelInner.Controls.Add(this.btnStatus);
            this.panelInner.Controls.Add(this.btnPush);
            this.panelInner.Controls.Add(this.btnCommit);
            this.panelInner.Controls.Add(this.btnPull);
            this.panelInner.Location = new System.Drawing.Point(0, 0);
            this.panelInner.Name = "panelInner";
            this.panelInner.Size = new System.Drawing.Size(483, 33);
            this.panelInner.TabIndex = 12;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 33);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.FlatAppearance.BorderSize = 0;
            this.btnStatus.Location = new System.Drawing.Point(324, 0);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(75, 33);
            this.btnStatus.TabIndex = 12;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnPush
            // 
            this.btnPush.Location = new System.Drawing.Point(162, 0);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(75, 33);
            this.btnPush.TabIndex = 11;
            this.btnPush.Text = "Push";
            this.btnPush.UseVisualStyleBackColor = true;
            this.btnPush.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(81, 0);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 33);
            this.btnCommit.TabIndex = 10;
            this.btnCommit.Text = "Commit";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnPull
            // 
            this.btnPull.Location = new System.Drawing.Point(243, 0);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(75, 33);
            this.btnPull.TabIndex = 9;
            this.btnPull.Text = "Pull";
            this.btnPull.UseVisualStyleBackColor = true;
            this.btnPull.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Location = new System.Drawing.Point(405, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 33);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btn_Click);
            // 
            // ButtonGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelInner);
            this.Name = "ButtonGroup";
            this.Size = new System.Drawing.Size(486, 33);
            this.panelInner.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInner;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnPush;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnPull;
        private System.Windows.Forms.Button btnRefresh;

    }
}
