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
        internal ButtonGroup(UIEventManager eventManager)
        {
            eventManager_m = eventManager;
            InitializeComponent();
        }

        private void btnScroll_Click(object sender, EventArgs e)
        {
            if (sender == btnScrollLeft)
            {
                panelInner.Location = new Point(panelInner.Location.X + 10, panelInner.Location.Y);
            }
            else if (sender == btnScrollRight)
            {
                panelInner.Location = new Point(panelInner.Location.X - 10, panelInner.Location.Y);
            } // end if
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
        } // end method

        #region Private Data

        private UIEventManager eventManager_m;

        #endregion
    }
}
