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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientMainWindow));
            this.tbDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainterMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerMiddle = new System.Windows.Forms.SplitContainer();
            this.btnPanelGroup_m = new System.Windows.Forms.Panel();
            this.splitContainerMiddleInner = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainterMain)).BeginInit();
            this.splitContainterMain.Panel1.SuspendLayout();
            this.splitContainterMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMiddle)).BeginInit();
            this.splitContainerMiddle.Panel1.SuspendLayout();
            this.splitContainerMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMiddleInner)).BeginInit();
            this.splitContainerMiddleInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDirectory
            // 
            this.tbDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDirectory.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbDirectory.Location = new System.Drawing.Point(10, 62);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.ReadOnly = true;
            this.tbDirectory.Size = new System.Drawing.Size(596, 20);
            this.tbDirectory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(595, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Git Location";
            // 
            // splitContainterMain
            // 
            this.splitContainterMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainterMain.Location = new System.Drawing.Point(12, 137);
            this.splitContainterMain.Name = "splitContainterMain";
            this.splitContainterMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainterMain.Panel1
            // 
            this.splitContainterMain.Panel1.Controls.Add(this.splitContainerMiddle);
            this.splitContainterMain.Size = new System.Drawing.Size(593, 388);
            this.splitContainterMain.SplitterDistance = 245;
            this.splitContainterMain.TabIndex = 17;
            // 
            // splitContainerMiddle
            // 
            this.splitContainerMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMiddle.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMiddle.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMiddle.Name = "splitContainerMiddle";
            // 
            // splitContainerMiddle.Panel1
            // 
            this.splitContainerMiddle.Panel1.Controls.Add(this.splitContainerMiddleInner);
            this.splitContainerMiddle.Size = new System.Drawing.Size(593, 245);
            this.splitContainerMiddle.SplitterDistance = 185;
            this.splitContainerMiddle.TabIndex = 0;
            // 
            // btnPanelGroup_m
            // 
            this.btnPanelGroup_m.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPanelGroup_m.Location = new System.Drawing.Point(10, 88);
            this.btnPanelGroup_m.Name = "btnPanelGroup_m";
            this.btnPanelGroup_m.Size = new System.Drawing.Size(596, 43);
            this.btnPanelGroup_m.TabIndex = 18;
            // 
            // splitContainerMiddleInner
            // 
            this.splitContainerMiddleInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMiddleInner.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMiddleInner.Name = "splitContainerMiddleInner";
            this.splitContainerMiddleInner.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainerMiddleInner.Size = new System.Drawing.Size(185, 245);
            this.splitContainerMiddleInner.SplitterDistance = 115;
            this.splitContainerMiddleInner.TabIndex = 0;
            // 
            // ClientMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 537);
            this.Controls.Add(this.splitContainterMain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPanelGroup_m);
            this.Controls.Add(this.tbDirectory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientMainWindow";
            this.Text = "PreppieGit";
            this.splitContainterMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainterMain)).EndInit();
            this.splitContainterMain.ResumeLayout(false);
            this.splitContainerMiddle.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMiddle)).EndInit();
            this.splitContainerMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMiddleInner)).EndInit();
            this.splitContainerMiddleInner.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainterMain;
        private System.Windows.Forms.Panel btnPanelGroup_m;
        private System.Windows.Forms.SplitContainer splitContainerMiddle;
        private System.Windows.Forms.SplitContainer splitContainerMiddleInner;
    }
}

