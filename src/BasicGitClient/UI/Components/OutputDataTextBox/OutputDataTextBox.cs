using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BasicGitClient
{
    internal partial class OutputDataTextBox : UserControl
    {
        #region Public Methods

        public OutputDataTextBox(UIEventManager eventManager, int width, int height)
        {
            InitializeComponent();

            this.Width = width;
            this.Height = height;
            this.Dock = DockStyle.Fill;
            this.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            eventManager_m = eventManager;

            eventManager_m.OnNewNotification += new UIEventManager.NotificationEvent(eventManager_m_OnNewNotification);
            eventManager_m.OnNewGitResponse += new UIEventManager.GitResponseEvent(eventManager_m_OnNewGitResponse);
        } // end method

        #endregion

        #region Private Methods

        private void eventManager_m_OnNewGitResponse(string output, string error)
        {
            updateRtbOutput(output, error);
        } // end method

        private void eventManager_m_OnNewNotification(string completionMessage)
        {
            updateRtbOutput(completionMessage, String.Empty);
        } // end method

        private void rtbOutput_TextChanged(object sender, EventArgs e)
        {
            OutputDataState state = OutputDataState.NONE;

            for (int i = 0; i < rtbOutput.Lines.Length; ++i)
            {
                if(rtbOutput.Lines[i].Contains("Changes to be committed:"))
                {
                    state = OutputDataState.STAGED;
                    continue;
                }
                else if (rtbOutput.Lines[i].Contains("Changes not staged for commit:"))
                {
                    state = OutputDataState.UNSTAGED;
                    continue;
                }
                else if (rtbOutput.Lines[i].Contains("Untracked files:"))
                {
                    state = OutputDataState.UNTRACKED;
                    continue;
                } // end if

                if (rtbOutput.Lines[i].Contains("modified: ")
                    || rtbOutput.Lines[i].Contains("renamed: ")
                    || rtbOutput.Lines[i].Contains("deleted: ")
                    || rtbOutput.Lines[i].StartsWith("\t"))
                {
                    rtbOutput.Select(rtbOutput.GetFirstCharIndexFromLine(i), rtbOutput.Lines[i].Length);
                    rtbOutput.SelectionColor = state == OutputDataState.STAGED ? Color.Green : Color.DarkRed;
                    rtbOutput.SelectionFont = new Font(rtbOutput.SelectionFont, FontStyle.Bold);
                }

                /*if (rtbOutput.Lines[i].Contains("new file: "))
                {
                    rtbOutput.Select(rtbOutput.GetFirstCharIndexFromLine(i), rtbOutput.Lines[i].Length);
                    rtbOutput.SelectionColor = Color.DarkGreen;
                    rtbOutput.SelectionFont = new Font(rtbOutput.SelectionFont, FontStyle.Bold);
                }*/
            }

            rtbOutput.SelectionStart = rtbOutput.TextLength;
            rtbOutput.ScrollToCaret();
        } // end method

        private void updateRtbOutput(string output, string error)
        {
            if (output == string.Empty && error == string.Empty)
            {
                //output = "Error running command..." + Environment.NewLine;
                output = Environment.NewLine;
            } // end if

            rtbOutput.AppendText(output.Replace("\n", Environment.NewLine));
            rtbOutput.AppendText(error.Replace("\n", Environment.NewLine));
            rtbOutput.AppendText(Environment.NewLine);
        } // end method

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbOutput.Text = "";
        } // end method

        #endregion

        #region Private Data

        // Event manager
        private UIEventManager eventManager_m;

        #endregion
    } // end class
} // end namespace
