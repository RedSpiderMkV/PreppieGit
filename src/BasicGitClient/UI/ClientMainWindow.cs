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

        private string defaultDir_m;
        private XmlHandler xmlHandler_m;
        private GitClientAccessor gitClient_m;
        private UIEventManager eventManager_m;

        #endregion

        #region Constructors

        public ClientMainWindow()
        {
            InitializeComponent();

            try
            {
                eventManager_m = new UIEventManager();
                eventManager_m.OnDirectoryChanged += new UIEventManager.DirectoryChangedEvent(eventManager_m_OnDirectoryChanged);
                eventManager_m.OnCredentialsUpdateRequired += new UIEventManager.UpdateCredentialsEvent(eventManager_m_OnCredentialsUpdateRequired);
                eventManager_m.OnRepoOwnerChangeRequest += new UIEventManager.RepoOwnerChangeRequestedEvent(eventManager_m_OnRepoOwnerChangeRequest);
                eventManager_m.OnNewGitResponse += new UIEventManager.GitResponseEvent(eventManager_m_OnNewGitResponse);

                xmlHandler_m = new XmlHandler(eventManager_m);
                gitClient_m = new GitClientAccessor(eventManager_m);

                runCommand(GitCommands.VERSION);

                defaultDir_m = xmlHandler_m.GetLastLocation();
                tbDirectory.Text = defaultDir_m;
                tbDirectory.SelectionStart = tbDirectory.TextLength;
                gitClient_m.SetDirectory(defaultDir_m);

                ControlDirectoryBrowser directoryBrowser = new ControlDirectoryBrowser(eventManager_m, defaultDir_m, splitContainer2.Panel1.Height);
                directoryBrowser.Width = splitContainer2.Panel1.Width;
                directoryBrowser.Height = splitContainer2.Panel1.Height;
                directoryBrowser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                
                splitContainer2.Panel1.Controls.Add(directoryBrowser);

                // set remote
                showOrigin();

                // Populate tree view.
                //populateTreeView();

                MenuStrip menuStrip = (new MainMenuStripBuilder(this.BackColor, eventManager_m, defaultDir_m)).GetMainMenuStrip();
                this.Controls.Add(menuStrip);
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
            }
        }

        #endregion

        private void eventManager_m_OnRepoOwnerChangeRequest(RepoOwnerChangeType type)
        {
            string title, label, command;

            if (type == RepoOwnerChangeType.EMAIL)
            {
                title = "Set Email...";
                label = "Email";
                command = GitCommands.SET_EMAIL;
            }
            else
            {
                title = "Set Username...";
                label = "Name";
                command = GitCommands.SET_USERNAME;
            } // end if

            SingleTextBoxDialogWindow dialogWindow = new SingleTextBoxDialogWindow(title, label);
            dialogWindow.ShowDialog();

            if (!string.IsNullOrEmpty(dialogWindow.TextField))
            {
                runCommand(command + dialogWindow.TextField);
            } // end if
        } // end method

        private void eventManager_m_OnCredentialsUpdateRequired(bool showMessage)
        {
            if (showMessage)
            {
                MessageBox.Show("Credentials required");
            } // end if

            CredentialConfigureWindow credentialWindow = new CredentialConfigureWindow();
            credentialWindow.ShowDialog();

            string username = credentialWindow.Username;
            string password = credentialWindow.Password;

            if (!username.Equals(String.Empty) && !password.Equals(String.Empty))
            {
                eventManager_m.TriggerNewCredentialsEvent(username, password);
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            runCommand(GitCommands.STATUS);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addAll();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            commitChanges();
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            pushCommits();
        }

        private void btnPull_Click(object sender, EventArgs e)
        {
            runCommand(GitCommands.PULL);
        }

        private void eventManager_m_OnDirectoryChanged(string newDirectoryFullPath)
        {
            tbDirectory.Text = newDirectoryFullPath;

            // get remote name
            showOrigin();
        } // end method

        private void setOriginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleTextBoxDialogWindow setOriginWindow = new SingleTextBoxDialogWindow("Set Origin...");
            setOriginWindow.ShowDialog();

            if (!String.IsNullOrEmpty(setOriginWindow.TextField))
            {
                string command = GitCommands.SET_ORIGIN + setOriginWindow.TextField;
                runCommand(command);
            }
        }

        private void changeRepoUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleTextBoxDialogWindow newUrlDialog = new SingleTextBoxDialogWindow("Set Repo URL");
            DialogResult dialogResult = newUrlDialog.ShowDialog();

            if (!String.IsNullOrEmpty(newUrlDialog.TextField))
            {
                runCommand(GitCommands.SET_URL + newUrlDialog.TextField);
            }

            showOrigin();
        }

        private void initialiseNewRepoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runCommand(GitCommands.INIT);
        }

        private void showOriginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showOrigin();
        } // end method

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleTextBoxDialogWindow cloneWindow = new SingleTextBoxDialogWindow("Clone");
            cloneWindow.ShowDialog();

            if (!string.IsNullOrEmpty(cloneWindow.TextField))
            {
                runCommand(GitCommands.CLONE + cloneWindow.TextField);
            }
        }

        private void resetToHeadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runCommand(GitCommands.RESET);
        }

        private void pushAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addAll();
            commitChanges();
            pushCommits();
        }

        private void revertLastChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runCommand(GitCommands.REVERT);
        }

        #region Helper Methods

        private void runCommand(string command)
        {
            Cursor = Cursors.WaitCursor;

            eventManager_m.TriggerNewGitCommandEvent(command);

            Cursor = Cursors.Default;
        }

        private void updateRtbOutput(string output, string error)
        {
            if (output == string.Empty && error == string.Empty)
            {
                output = "Error running command..." + Environment.NewLine;
            }

            rtbOutput.AppendText(output.Replace("\n", Environment.NewLine));
            rtbOutput.AppendText(error.Replace("\n", Environment.NewLine));
        }

        private void addAll()
        {
            eventManager_m.TriggerNewGitCommandEvent(GitCommands.ADD_ALL);
        } // end method

        private void commitChanges()
        {
            CommitCommentWindow commitWindow = new CommitCommentWindow();
            commitWindow.ShowDialog();

            string comment = commitWindow.CommitComment;

            if (comment != String.Empty)
            {
                string command = GitCommands.COMMIT + " " + comment;
                eventManager_m.TriggerNewGitCommandEvent(command);
            }
            else
            {
                updateRtbOutput("\nNo comment added.  Not committed..", string.Empty);
            } // end if
        } // end method

        private void pushCommits()
        {
            string username, password;
            xmlHandler_m.GetCredentials(out username, out password);

            string directoryName = Path.GetDirectoryName(defaultDir_m);
            string command = String.Format(GitCommands.PUSH, username, password, directoryName);
            runCommand(command);

            // push then pull required due to master/origin local mismatch
            runCommand(GitCommands.PULL);
        } // end method

        private void showOrigin()
        {
            eventManager_m.TriggerNewGitCommandEvent(GitCommands.SHOW_ORIGIN);
        } // end method

        #endregion

        private void rtbOutput_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < rtbOutput.Lines.Length; ++i)
            {
                if (rtbOutput.Lines[i].Contains("modified: ")
                    || rtbOutput.Lines[i].Contains("renamed: ")
                    || rtbOutput.Lines[i].Contains("deleted: "))
                {
                    rtbOutput.Select(rtbOutput.GetFirstCharIndexFromLine(i), rtbOutput.Lines[i].Length);
                    rtbOutput.SelectionColor = Color.DarkRed;
                }

                if (rtbOutput.Lines[i].Contains("new file: "))
                {
                    rtbOutput.Select(rtbOutput.GetFirstCharIndexFromLine(i), rtbOutput.Lines[i].Length);
                    rtbOutput.SelectionColor = Color.DarkGreen;
                }
            }

            rtbOutput.SelectionStart = rtbOutput.TextLength;
            rtbOutput.ScrollToCaret();
        }

        private void updategitignoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Have you committed outstanding code changes?",
                "Commit Changes", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                runCommand("rm -r --cached .");
                runCommand("add .");
                runCommand(GitCommands.STATUS);
                runCommand("commit -m \"gitignore updated\"");

                pushCommits();
            }
        }

        private void cMenuOutputBox_Clear_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
        }

        private void eventManager_m_OnNewGitResponse(string output, string error)
        {
            updateRtbOutput(output, error);
        } // end method
    }
}
