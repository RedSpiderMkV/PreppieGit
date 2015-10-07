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

    internal partial class ControlDirectoryBrowser : UserControl
    {
        public ControlDirectoryBrowser(UIEventManager eventManager, string currentDirectory, int width, int height)
        {
            InitializeComponent();

            currentDirectoryPath_m = currentDirectory;

            tvDirectoryList.Location = lbFileList.Location = new Point(0, 0);
            tvDirectoryList.Height = lbFileList.Height = height;
            tvDirectoryList.Width = splitContainer1.Panel1.Width;
            tvDirectoryList.Scrollable = true;
            //tvDirectoryList.Dock = DockStyle.Fill;

            lbFileList.Width = splitContainer1.Panel2.Width;
            //lbFileList.Dock = DockStyle.Fill;
            //lbFileList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            this.Width = width;
            this.Height = height;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.SplitterDistance = (int)(width * 0.35);

            populateTreeView();
            //populateFileList();

            eventManager_m = eventManager;
            eventManager_m.OnDirectoryChanged += new UIEventManager.DirectoryChangedEvent(eventManager_m_OnDirectoryChanged);
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
            lbFileList.Items.Clear();

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

        private void populateFileList()
        {
            if (currentSelectedNode_m == null)
            {
                return;
            } // end if

            lbFileList.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)currentSelectedNode_m.Tag;

            try
            {
                foreach (FileInfo file in nodeDirInfo.GetFiles())
                {
                    lbFileList.Items.Add(file.Name);
                } // end foreach
            }
            catch (DirectoryNotFoundException)
            {
                // directory may have been deleted/renamed
                populateTreeView();
                populateFileList();
            } // end try-catch
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

            populateFileList();
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

        private void toolStripFileMenuItem_Click(object sender, EventArgs e)
        {
            ContextMenuItemTask task = (ContextMenuItemTask)Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            fileModifyToolstripHandler(task);
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
            lbFileList.Items.Clear();
        } // end method

        private void fileModifyToolstripHandler(ContextMenuItemTask task)
        {
            string dirPath = getDirectoryPath();

            if (String.IsNullOrEmpty(dirPath))
            {
                return;
            } // end if

            string name;

            try
            {
                switch (task)
                {
                    case ContextMenuItemTask.CREATE:
                        name = getStringFromDialogBox("New File", "Name");

                        if (String.IsNullOrEmpty(name))
                        {
                            break;
                        } // end if

                        FileStream fs = File.Create(dirPath + "\\" + name);
                        fs.Dispose();
                        break;
                    case ContextMenuItemTask.DELETE:
                        File.Delete(dirPath + "\\" + lbFileList.Text);
                        break;
                    case ContextMenuItemTask.OPEN:
                        Process.Start(dirPath + "\\" + lbFileList.Text);
                        break;
                    case ContextMenuItemTask.RENAME:
                        name = getStringFromDialogBox("Rename", "Name");

                        if (String.IsNullOrEmpty(name))
                        {
                            break;
                        } // end if

                        string currentPath = dirPath + "\\" + lbFileList.Text;
                        string newPath = dirPath + "\\" + name;

                        File.Move(currentPath, newPath);
                        break;
                    default:
                        return;
                } // end switch
            }
            catch (Exception e)
            {
                // TODO: lazy error handling... do it right at some point
                eventManager_m.TriggerNotificationEvent("Error occured: " + e.Message);
            } // end try-catch

            populateFileList();
        } // end method

        private void ctxMnuFileBrowser_Opening(object sender, CancelEventArgs e)
        {
            deleteFileToolStripMenuItem.Enabled
                = renameFileToolStripMenuItem.Enabled
                = openFileToolStripMenuItem.Enabled
                = lbFileList.SelectedItem != null;
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

        #region Private Data

        private UIEventManager eventManager_m;
        private TreeNode currentSelectedNode_m;
        private string currentDirectoryPath_m;
        private string treeViewSelectedDirectory_m;

        #endregion

    } // end class
} // end namespace
