using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicGitClient
{
    enum RepoOwnerChangeType
    {
        EMAIL,
        USERNAME
    } // end enum

    enum BranchResponseType
    {
        LOCAL,
        REMOTE
    } // end enum

    enum CursorUpdateType
    {
        CURSOR_WAIT,
        CURSOR_NORMAL
    } // end enum

    internal class UIEventManager
    {
        #region Events

        public delegate void DirectoryChangedEvent(string newDirectoryFullPath);
        public event DirectoryChangedEvent OnDirectoryChanged;

        public delegate void UpdateCredentialsEvent(bool showMessage);
        public event UpdateCredentialsEvent OnCredentialsUpdateRequired;

        public delegate void NewCredentialsEvent(string username, string password);
        public event NewCredentialsEvent OnNewCredentials;

        public delegate void RepoOwnerChangeRequestedEvent(RepoOwnerChangeType type);
        public event RepoOwnerChangeRequestedEvent OnRepoOwnerChangeRequest;

        public delegate void NewGitCommandEvent(string command);
        public event NewGitCommandEvent OnNewGitCommandIssued;

        public delegate void GitResponseEvent(string output, string error);
        public event GitResponseEvent OnNewGitResponse;

        public delegate void CursorChangeRequiredEvent(CursorUpdateType cursorType);
        public event CursorChangeRequiredEvent OnCursorChangeRequired;

        public delegate void NotificationEvent(string completionMessage);
        public event NotificationEvent OnNewNotification;

        public delegate void NewRepoNameEvent(string newRepoName);
        public event NewRepoNameEvent OnNewRepoName;

        public delegate void GitBranchResponseEvent(string output, BranchResponseType branchType);
        public event GitBranchResponseEvent OnNewGitBranchEvent;

        public delegate void GitBranchCheckoutEvent(string currentBranch);
        public event GitBranchCheckoutEvent OnGitBranchCheckout;

        public delegate void GitBranchCreateEvent(string newBranchName);
        public event GitBranchCreateEvent OnGitBranchCreate;

        public delegate void RefreshControlsEvent();
        public event RefreshControlsEvent OnRefreshControlsRequest;

        #endregion

        #region Public Methods

        public void TriggerRefreshControlsEvent()
        {
            RefreshControlsEvent handler = OnRefreshControlsRequest;
            if (handler != null)
            {
                OnRefreshControlsRequest();
            } // end if
        } // end method

        public void TriggerNewGitBranchCreate(string newBranchName)
        {
            GitBranchCreateEvent handler = OnGitBranchCreate;
            if (handler != null)
            {
                OnGitBranchCreate(newBranchName);
            } // end if
        } // end method

        public void TriggerNewGitBranchCheckout(string gitBranchName)
        {
            GitBranchCheckoutEvent handler = OnGitBranchCheckout;
            if (handler != null)
            {
                OnGitBranchCheckout(gitBranchName);
            } // end if
        } // end method

        public void TriggerNewBranchResponseEvent(string output, BranchResponseType branchType)
        {
            GitBranchResponseEvent handler = OnNewGitBranchEvent;
            if (handler != null)
            {
                OnNewGitBranchEvent(output, branchType);
            } // end if
        } // end method

        public void TriggerNewRepoNameEvent(string repoName)
        {
            NewRepoNameEvent handler = OnNewRepoName;
            if (handler != null)
            {
                OnNewRepoName(repoName);
            } // end if
        } // end method

        public void TriggerNotificationEvent(string message)
        {
            NotificationEvent handler = OnNewNotification;
            if (handler != null)
            {
                OnNewNotification(message);
            } // end if
        } // end method

        public void TriggerGitResponseEvent(string output, string error)
        {
            GitResponseEvent handler = OnNewGitResponse;
            if (handler != null)
            {
                OnNewGitResponse(output, error);
            } // end if
        } // end method

        public void TriggerNewGitCommandEvent(string command)
        {
            triggerCursorChangeEvent(CursorUpdateType.CURSOR_WAIT);
            
            NewGitCommandEvent handler = OnNewGitCommandIssued;
            if (handler != null)
            {
                OnNewGitCommandIssued(command);
            } // end if

            triggerCursorChangeEvent(CursorUpdateType.CURSOR_NORMAL);
        } // end method

        public void TriggerRepoOwnerChangeEvent(RepoOwnerChangeType type)
        {
            RepoOwnerChangeRequestedEvent handler = OnRepoOwnerChangeRequest;
            if (handler != null)
            {
                OnRepoOwnerChangeRequest(type);
            } // end if
        } // end method

        public void TriggerNewCredentialsEvent(string username, string password)
        {
            NewCredentialsEvent handler = OnNewCredentials;
            if (handler != null)
            {
                OnNewCredentials(username, password);
            } // end if
        } // end method

        public void TriggerDirectoryChangedEvent(string newDirectory)
        {
            DirectoryChangedEvent handler = OnDirectoryChanged;
            if (handler != null)
            {
                OnDirectoryChanged(newDirectory);
            } // end if
        } // end method

        public void TriggerUpdateCredentialsEvent(bool showMessageBox)
        {
            UpdateCredentialsEvent handler = OnCredentialsUpdateRequired;
            if (handler != null)
            {
                OnCredentialsUpdateRequired(showMessageBox);
            } // end if
        } // end method

        #endregion

        #region Private Methods

        private void triggerCursorChangeEvent(CursorUpdateType cursorType)
        {
            CursorChangeRequiredEvent handler = OnCursorChangeRequired;
            if (handler != null)
            {
                OnCursorChangeRequired(cursorType);
            } // end if
        } // end method

        #endregion

    } // end class
} // end namespace
