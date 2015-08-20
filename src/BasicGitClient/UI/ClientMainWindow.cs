using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGitClient
{
    public partial class ClientMainWindow : Form
    {
        #region Private Data

        private string repoName_m;
        private XmlHandler xmlHandler_m;
        private GitClientAccessor gitClient_m;
        private UIEventManager eventManager_m;
        private UIActionEventManager actionEventManager_m;
        private ButtonGroup btnGroup_m;
        private OutputDataTextBox outputDataTextBox_m;

        #endregion

        #region Constructors

        public ClientMainWindow()
        {
            InitializeComponent();

            try
            {
                eventManager_m = new UIEventManager();
                actionEventManager_m = new UIActionEventManager();

                xmlHandler_m = new XmlHandler(eventManager_m);
                gitClient_m = new GitClientAccessor(eventManager_m);

                eventManager_m.OnDirectoryChanged += new UIEventManager.DirectoryChangedEvent(eventManager_m_OnDirectoryChanged);
                eventManager_m.OnCredentialsUpdateRequired += new UIEventManager.UpdateCredentialsEvent(eventManager_m_OnCredentialsUpdateRequired);
                eventManager_m.OnNewGitResponse += new UIEventManager.GitResponseEvent(eventManager_m_OnNewGitResponse);
                eventManager_m.OnNewNotification += new UIEventManager.NotificationEvent(eventManager_m_OnNewNotification);
                eventManager_m.OnCursorChangeRequired += new UIEventManager.CursorChangeRequiredEvent(eventManager_m_OnCursorChangeRequired);

                string defaultDir = xmlHandler_m.GetLastLocation();
                tbDirectory.Text = defaultDir;
                tbDirectory.SelectionStart = tbDirectory.TextLength;
                eventManager_m.TriggerDirectoryChangedEvent(defaultDir);

                ControlDirectoryBrowser directoryBrowser = new ControlDirectoryBrowser(eventManager_m, defaultDir, splitContainer2.Panel1.Height);
                directoryBrowser.Width = splitContainer2.Panel1.Width;
                directoryBrowser.Height = splitContainer2.Panel1.Height;
                directoryBrowser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                splitContainer2.Panel1.Controls.Add(directoryBrowser);
                
                outputDataTextBox_m = new OutputDataTextBox(eventManager_m, splitContainer2.Panel2.Width, splitContainer2.Panel2.Height);
                splitContainer2.Panel2.Controls.Add(outputDataTextBox_m);

                MenuStrip menuStrip = (new MainMenuStripBuilder(this.BackColor, eventManager_m, actionEventManager_m, defaultDir)).GetMainMenuStrip();
                this.Controls.Add(menuStrip);

                btnGroup_m = new ButtonGroup(eventManager_m, xmlHandler_m, repoName_m);
                btnGroup_m.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                btnGroup_m.Width = btnPanelGroup.Width;
                btnGroup_m.Height = btnPanelGroup.Height;
                btnPanelGroup.Controls.Add(btnGroup_m);

                updateRepoName();

                eventManager_m.TriggerNewGitCommandEvent(GitCommands.VERSION);
            }
            catch (Win32Exception)
            {
                MessageBox.Show("Error with application.  Could not find Git.\nTerminating..");
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(0);
            } // end try-catch
        } // end method

        #endregion

        private void eventManager_m_OnCursorChangeRequired(CursorUpdateType cursorType)
        {
            if (cursorType == CursorUpdateType.CURSOR_WAIT)
            {
                this.Cursor = Cursors.WaitCursor;
            }
            else
            {
                this.Cursor = Cursors.Default;
            } // end if
        } // end method

        private void eventManager_m_OnNewNotification(string completionMessage)
        {
            //updateRtbOutput(completionMessage, String.Empty);
        } // end method

        private void eventManager_m_OnNewGitResponse(string output, string error)
        {
            //updateRtbOutput(output, error);
        } // end method

        private void eventManager_m_OnCredentialsUpdateRequired(bool showMessage)
        {
            // Consider having this event handled in a separate class altogether
            if (showMessage)
            {
                MessageBox.Show("Credentials required");
            } // end if

            CredentialConfigureWindow credentialWindow = new CredentialConfigureWindow();
            if (credentialWindow.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string username = credentialWindow.Username;
                string password = credentialWindow.Password;

                if (!username.Equals(String.Empty) && !password.Equals(String.Empty))
                {
                    eventManager_m.TriggerNewCredentialsEvent(username, password);
                } // end if
            } // end if
        } // end method

        private void eventManager_m_OnDirectoryChanged(string newDirectoryFullPath)
        {
            tbDirectory.Text = newDirectoryFullPath;
            eventManager_m.TriggerNewGitCommandEvent(GitCommands.SHOW_ORIGIN);
            updateRepoName();
        } // end method

        //private void updateRtbOutput(string output, string error)
        //{
        //    if (output == string.Empty && error == string.Empty)
        //    {
        //        output = "Error running command..." + Environment.NewLine;
        //    } // end if

        //    rtbOutput.AppendText(output.Replace("\n", Environment.NewLine));
        //    rtbOutput.AppendText(error.Replace("\n", Environment.NewLine));
        //    rtbOutput.AppendText(Environment.NewLine);
        //} // end method

        //private void rtbOutput_TextChanged(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < rtbOutput.Lines.Length; ++i)
        //    {
        //        if (rtbOutput.Lines[i].Contains("modified: ")
        //            || rtbOutput.Lines[i].Contains("renamed: ")
        //            || rtbOutput.Lines[i].Contains("deleted: "))
        //        {
        //            rtbOutput.Select(rtbOutput.GetFirstCharIndexFromLine(i), rtbOutput.Lines[i].Length);
        //            rtbOutput.SelectionColor = Color.DarkRed;
        //            rtbOutput.SelectionFont = new Font(rtbOutput.SelectionFont, FontStyle.Bold);
        //        }

        //        if (rtbOutput.Lines[i].Contains("new file: "))
        //        {
        //            rtbOutput.Select(rtbOutput.GetFirstCharIndexFromLine(i), rtbOutput.Lines[i].Length);
        //            rtbOutput.SelectionColor = Color.DarkGreen;
        //            rtbOutput.SelectionFont = new Font(rtbOutput.SelectionFont, FontStyle.Bold);
        //        }
        //    }

        //    rtbOutput.SelectionStart = rtbOutput.TextLength;
        //    rtbOutput.ScrollToCaret();
        //}

        private void cMenuOutputBox_Clear_Click(object sender, EventArgs e)
        {
            //rtbOutput.Clear();
        }

        private void updateRepoName()
        {
            string[] parts = tbDirectory.Text.Split('\\');
            repoName_m = parts[parts.Length - 1];

            eventManager_m.TriggerNewRepoNameEvent(repoName_m);
        } // end method
    }
}
