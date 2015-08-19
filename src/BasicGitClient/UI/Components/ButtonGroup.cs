using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGitClient
{
    public partial class ButtonGroup : UserControl
    {
        #region Constructors

        internal ButtonGroup(UIEventManager eventManager, XmlHandler xmlHandler, string repoName)
        {
            eventManager_m = eventManager;
            xmlHandler_m = xmlHandler;
            repoName_m = repoName;

            eventManager_m.OnNewRepoName += new UIEventManager.NewRepoNameEvent(eventManager_m_OnNewRepoName);

            InitializeComponent();
        } // end method

        #endregion

        #region Private Methods

        private void eventManager_m_OnNewRepoName(string newRepoName)
        {
            repoName_m = newRepoName;
        } // end method

        private void btn_Click(object sender, EventArgs e)
        {
            if (sender == btnAdd)
            {
                eventManager_m.TriggerNewGitCommandEvent(GitCommands.ADD_ALL);
            }
            else if (sender == btnCommit)
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
                    eventManager_m.TriggerNotificationEvent("\nNo comment added.  Not committed..");
                } // end if
            }
            else if (sender == btnPush)
            {
                string username, password;
                xmlHandler_m.GetCredentials(out username, out password);

                string command = String.Format(GitCommands.PUSH, username, password, repoName_m);
                eventManager_m.TriggerNewGitCommandEvent(command);

                // push then pull required due to master/origin local mismatch
                eventManager_m.TriggerNewGitCommandEvent(GitCommands.PULL);
            }
            else if (sender == btnPull)
            {
                eventManager_m.TriggerNewGitCommandEvent(GitCommands.PULL);
            }
            else if (sender == btnStatus)
            {
                eventManager_m.TriggerNewGitCommandEvent(GitCommands.STATUS);
            } // end if
        } // end method

        #endregion

        #region Private Data

        private UIEventManager eventManager_m;
        private XmlHandler xmlHandler_m;
        private string repoName_m;

        #endregion
    }
}
