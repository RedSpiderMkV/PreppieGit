namespace BasicGitClient
{
    partial class ClientMainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientMainWindow));
            this.tbDirectory = new System.Windows.Forms.TextBox();
            this.btnPull = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnPush = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.cMenuOutputBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMenuOutputBox_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cMenuOutputBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDirectory
            // 
            this.tbDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDirectory.Location = new System.Drawing.Point(10, 62);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.Size = new System.Drawing.Size(399, 20);
            this.tbDirectory.TabIndex = 0;
            // 
            // btnPull
            // 
            this.btnPull.Location = new System.Drawing.Point(253, 88);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(75, 23);
            this.btnPull.TabIndex = 3;
            this.btnPull.Text = "Pull";
            this.btnPull.UseVisualStyleBackColor = true;
            this.btnPull.Click += new System.EventHandler(this.btnPull_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(91, 88);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 23);
            this.btnCommit.TabIndex = 4;
            this.btnCommit.Text = "Commit";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnPush
            // 
            this.btnPush.Location = new System.Drawing.Point(172, 88);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(75, 23);
            this.btnPush.TabIndex = 5;
            this.btnPush.Text = "Push";
            this.btnPush.UseVisualStyleBackColor = true;
            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(334, 88);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(75, 23);
            this.btnStatus.TabIndex = 7;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(10, 88);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Git Location";
            // 
            // rtbOutput
            // 
            this.rtbOutput.BackColor = System.Drawing.SystemColors.Window;
            this.rtbOutput.ContextMenuStrip = this.cMenuOutputBox;
            this.rtbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbOutput.Location = new System.Drawing.Point(0, 0);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(396, 181);
            this.rtbOutput.TabIndex = 14;
            this.rtbOutput.Text = "";
            this.rtbOutput.WordWrap = false;
            this.rtbOutput.TextChanged += new System.EventHandler(this.rtbOutput_TextChanged);
            // 
            // cMenuOutputBox
            // 
            this.cMenuOutputBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMenuOutputBox_Clear});
            this.cMenuOutputBox.Name = "cMenuOutputBox";
            this.cMenuOutputBox.Size = new System.Drawing.Size(153, 48);
            // 
            // cMenuOutputBox_Clear
            // 
            this.cMenuOutputBox_Clear.Name = "cMenuOutputBox_Clear";
            this.cMenuOutputBox_Clear.Size = new System.Drawing.Size(152, 22);
            this.cMenuOutputBox_Clear.Text = "Clear";
            this.cMenuOutputBox_Clear.Click += new System.EventHandler(this.cMenuOutputBox_Clear_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(13, 117);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.rtbOutput);
            this.splitContainer2.Size = new System.Drawing.Size(396, 369);
            this.splitContainer2.SplitterDistance = 184;
            this.splitContainer2.TabIndex = 17;
            // 
            // ClientMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 498);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnPush);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.btnPull);
            this.Controls.Add(this.tbDirectory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientMainWindow";
            this.Text = "PreppieGit";
            this.cMenuOutputBox.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDirectory;
        private System.Windows.Forms.Button btnPull;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnPush;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ContextMenuStrip cMenuOutputBox;
        private System.Windows.Forms.ToolStripMenuItem cMenuOutputBox_Clear;
    }
}

