﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BasicGitClient
{
    public partial class ClientMainWindow : Form
    {
        #region Private Data

        private static string titleText_m;

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

            this.MinimumSize = new Size(628,564);

            try
            {
                titleText_m = "PreppieGit v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

                eventManager_m = new UIEventManager();
                actionEventManager_m = new UIActionEventManager();

                xmlHandler_m = new XmlHandler(eventManager_m);
                gitClient_m = new GitClientAccessor(eventManager_m);

                eventManager_m.OnDirectoryChanged += new UIEventManager.DirectoryChangedEvent(eventManager_m_OnDirectoryChanged);
                eventManager_m.OnCredentialsUpdateRequired += new UIEventManager.UpdateCredentialsEvent(eventManager_m_OnCredentialsUpdateRequired);
                eventManager_m.OnCursorChangeRequired += new UIEventManager.CursorChangeRequiredEvent(eventManager_m_OnCursorChangeRequired);

                string defaultDir = xmlHandler_m.GetLastLocation();
                tbDirectory.Text = defaultDir;

                BranchesBrowser branchBrowser = new BranchesBrowser(eventManager_m);
                splitContainerMiddleInner.Panel2.Controls.Add(branchBrowser);

                SelectedDirectoryEventManager directoryEventManager = new SelectedDirectoryEventManager();

                DirectoryBrowser directoryBrowser = new DirectoryBrowser(eventManager_m, directoryEventManager, defaultDir, splitContainterMain.Panel1.Width, splitContainterMain.Panel1.Height);
                splitContainerMiddleInner.Panel1.Controls.Add(directoryBrowser);

                FileBrowser fileBrowser = new FileBrowser(eventManager_m, directoryEventManager);
                splitContainerMiddle.Panel2.Controls.Add(fileBrowser);

                outputDataTextBox_m = new OutputDataTextBox(eventManager_m, splitContainterMain.Panel2.Width, splitContainterMain.Panel2.Height);
                splitContainterMain.Panel2.Controls.Add(outputDataTextBox_m);

                MenuStrip menuStrip = (new MainMenuStripBuilder(this.BackColor, eventManager_m, actionEventManager_m, defaultDir)).GetMainMenuStrip();
                this.Controls.Add(menuStrip);

                btnGroup_m = new ButtonGroup(eventManager_m, xmlHandler_m, repoName_m, btnPanelGroup_m.Width, btnPanelGroup_m.Height, new Point(0, 5));
                btnPanelGroup_m.Controls.Add(btnGroup_m);

                updateRepoName();

                eventManager_m.TriggerDirectoryChangedEvent(defaultDir);
                eventManager_m.TriggerNewGitCommandEvent(GitCommands.VERSION);
                eventManager_m.TriggerNewGitCommandEvent(GitCommands.BRANCH_LOCAL);
                eventManager_m.TriggerNewGitCommandEvent(GitCommands.BRANCH_REMOTE);
                eventManager_m.TriggerNewGitCommandEvent(GitCommands.BRANCH_GET_CURRENT);
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
            string name = Path.GetFileName(newDirectoryFullPath);
            this.Text = titleText_m + " - " + name;

            tbDirectory.Text = newDirectoryFullPath;
            eventManager_m.TriggerNewGitCommandEvent(GitCommands.SHOW_ORIGIN);

            eventManager_m.TriggerNewGitCommandEvent(GitCommands.BRANCH_LOCAL);
            eventManager_m.TriggerNewGitCommandEvent(GitCommands.BRANCH_REMOTE);

            updateRepoName();
        } // end method

        private void updateRepoName()
        {
            string[] parts = tbDirectory.Text.Split('\\');
            repoName_m = parts[parts.Length - 1];

            eventManager_m.TriggerNewRepoNameEvent(repoName_m);
        } // end method
    } // end class
} // end namespace
