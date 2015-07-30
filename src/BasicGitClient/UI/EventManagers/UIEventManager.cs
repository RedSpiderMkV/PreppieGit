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

        public delegate void CommandCompletionNotificationEvent(string completionMessage);
        public event CommandCompletionNotificationEvent OnCompletionNotification;

        #endregion

        #region Public Methods

        public void TriggerCompletionNotificationEvent(string completionMessage)
        {
            CommandCompletionNotificationEvent handler = OnCompletionNotification;
            if (handler != null)
            {
                OnCompletionNotification(completionMessage);
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
