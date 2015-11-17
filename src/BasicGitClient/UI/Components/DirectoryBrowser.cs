using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGitClient
{
    #region Enums

    enum DirectoryState
    {
        CLOSED = 0,
        OPEN = 1
    } // end enum

    enum ContextMenuItemTask
    {
        CREATE = 0,
        OPEN = 1,
        RENAME = 2,
        DELETE = 3,
        SHOW = 4
    } // end enum

    #endregion

    internal partial class DirectoryBrowser : UserControl
    {
        #region Public Methods

        public DirectoryBrowser(UIEventManager eventManager, string currentDirectory, int width, int height)
        {
            InitializeComponent();

            currentDirectoryPath_m = currentDirectory;

            tvDirectoryList.Scrollable = true;

            this.Width = width;
            this.Height = height;
            this.Dock = DockStyle.Fill;

            populateTreeView();

            eventManager_m = eventManager;
            eventManager_m.OnDirectoryChanged += new UIEventManager.DirectoryChangedEvent(eventManager_m_OnDirectoryChanged);
            eventManager.OnRefreshDirectoryRequest += new UIEventManager.RefreshDirectoryEvent(eventManager_OnRefreshDirectoryRequest);
        } // end method

        #endregion

        #region Private Methods

        private void eventManager_OnRefreshDirectoryRequest()
        {
            populateTreeView();
        } // end method

        private void eventManager_m_OnDirectoryChanged(string newDirectoryFullPath)
        {
            currentDirectoryPath_m = newDirectoryFullPath;
            populateTreeView();
        } // end method

        private void populateTreeView()
        {
            if (String.IsNullOrEmpty(currentDirectoryPath_m))
            {
                return;
            } // end if

            tvDirectoryList.Nodes.Clear();

            DirectoryInfo info = new DirectoryInfo(currentDirectoryPath_m);

            if (info.Exists)
            {
                TreeNode rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                addDirectoriesToNode(info.GetDirectories(), rootNode);
                tvDirectoryList.Nodes.Add(rootNode);
            } // end if
        } // end method

        private void addDirectoriesToNode(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    addDirectoriesToNode(subSubDirs, aNode);
                } // end if

                if (!(subDir.Attributes.HasFlag(FileAttributes.Hidden)))
                {
                    nodeToAddTo.Nodes.Add(aNode);
                } // end if
            } // end foreach
        } // end method

        private void tvDirectoryList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvDirectoryList.SelectedNode != null)
            {
                int headNodeLength = tvDirectoryList.Nodes[0].Text.Length;
                string selectedNode = tvDirectoryList.SelectedNode.FullPath.Remove(0, headNodeLength);
                treeViewSelectedDirectory_m = currentDirectoryPath_m + "//" + selectedNode;
            } // end if
        } // end method

        private void tvDirectoryList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            currentSelectedNode_m = e.Node;
            tvDirectoryList.SelectedNode = e.Node;

            tvDirectoryList.SelectedNode.ImageIndex =
                tvDirectoryList.SelectedNode.SelectedImageIndex =
                tvDirectoryList.SelectedNode.IsExpanded ? (int)DirectoryState.OPEN : (int)DirectoryState.CLOSED;
        } // end method

        private void tvDirectoryList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                populateTreeView();
            } // end if
        } // end method

        private void toolStripDirectoryMenuItem_Click(object sender, EventArgs e)
        {
            ContextMenuItemTask task = (ContextMenuItemTask)Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            directoryModifyToolstripHandler(task);
        } // end method

        private void directoryModifyToolstripHandler(ContextMenuItemTask task)
        {
            string dirPath = getDirectoryPath();

            switch (task)
            {
                case ContextMenuItemTask.CREATE:
                    string name = getStringFromDialogBox("New Directory", "Name");

                    if (String.IsNullOrEmpty(name))
                    {
                        break;
                    } // end if

                    if (String.IsNullOrEmpty(dirPath))
                    {
                        dirPath = currentDirectoryPath_m + "\\" + name;
                    }
                    else
                    {
                        dirPath += "\\" + name;
                    } // end if
                    
                    Directory.CreateDirectory(dirPath);
                    break;
                case ContextMenuItemTask.DELETE:
                    if (!String.IsNullOrEmpty(dirPath))
                    {
                        Directory.Delete(dirPath, true);
                    } // end if
                    break;
                case ContextMenuItemTask.RENAME:
                    if (!String.IsNullOrEmpty(dirPath))
                    {
                        string newName = getStringFromDialogBox("Rename", "Name");

                        if (String.IsNullOrEmpty(newName))
                        {
                            break;
                        } // end if

                        string[] dirPathParts = dirPath.Split('\\');
                        dirPathParts[dirPathParts.Length - 1] = newName;

                        string newFullPath = "";

                        foreach (string part in dirPathParts)
                        {
                            newFullPath += part + "\\";
                        } // end foreach

                        Directory.Move(dirPath, newFullPath);
                    } // end if
                    break;
                case ContextMenuItemTask.SHOW:
                    Process.Start(dirPath);
                    return;
                default:
                    return;
            } // end switch

            populateTreeView();
        } // end method

        private string getStringFromDialogBox(string title, string label)
        {
            SingleTextBoxDialogWindow dialog = new SingleTextBoxDialogWindow(title, label);
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                return dialog.TextField;
            } // end if

            return String.Empty;
        } // end method

        private string getDirectoryPath()
        {
            if (currentSelectedNode_m != null && currentSelectedNode_m.FullPath != null)
            {
                return Directory.GetParent(currentDirectoryPath_m) + "\\" + currentSelectedNode_m.FullPath;
            } // end if

            return String.Empty;
        } // end method

        private void ControlDirectoryBrowser_Resize(object sender, EventArgs e)
        {
        } // end method

        #endregion

        #region Private Data

        private UIEventManager eventManager_m;
        private TreeNode currentSelectedNode_m;
        private string currentDirectoryPath_m;
        private string treeViewSelectedDirectory_m;

        #endregion

    } // end class
} // end namespace
