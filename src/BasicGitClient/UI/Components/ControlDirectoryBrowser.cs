﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGitClient
{
    enum DirectoryTask
    {
        CREATE,
        RENAME,
        DELETE,
        OPEN
    } // end enum

    internal partial class ControlDirectoryBrowser : UserControl
    {
        public ControlDirectoryBrowser(UIEventManager eventManager, string currentDirectory, int height)
        {
            InitializeComponent();

            currentDirectoryPath_m = currentDirectory;

            tvDirectoryList.Location = lbFileList.Location = new Point(0, 0);
            tvDirectoryList.Height = lbFileList.Height = height;

            tvDirectoryList.Width = splitContainer1.Panel1.Width;
            lbFileList.Width = splitContainer1.Panel2.Width;

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

            TreeNode rootNode;
            DirectoryInfo info = new DirectoryInfo(currentDirectoryPath_m);

            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                addDirectoriesToNode(info.GetDirectories(), rootNode);
                tvDirectoryList.Nodes.Add(rootNode);
            } // end if
        }

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

            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                lbFileList.Items.Add(file.Name);
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
            if (sender == newDirectoryToolStripMenuItem)
            {
                directoryModifyToolstripHandler(DirectoryTask.CREATE);
            }
            else if (sender == renameDirectoryToolStripMenuItem)
            {
                directoryModifyToolstripHandler(DirectoryTask.RENAME);
            }
            else if (sender == deleteDirectoryToolStripMenuItem)
            {
                directoryModifyToolstripHandler(DirectoryTask.DELETE);
            } // end if
        } // end method

        private void toolStripFileMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == newFileToolStripMenuItem)
            {
                fileModifyToolstripHandler(DirectoryTask.CREATE);
            }
            else if (sender == renameDirectoryToolStripMenuItem)
            {
                fileModifyToolstripHandler(DirectoryTask.RENAME);
            }
            else if (sender == deleteDirectoryToolStripMenuItem)
            {
                fileModifyToolstripHandler(DirectoryTask.DELETE);
            }
            else if (sender == openFileToolStripMenuItem)
            {
                fileModifyToolstripHandler(DirectoryTask.OPEN);
            } // end if
        } // end method

        private void directoryModifyToolstripHandler(DirectoryTask task)
        {
            string dirPath = getDirectoryPath();

            switch (task)
            {
                case DirectoryTask.CREATE:
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
                case DirectoryTask.DELETE:
                    if (!String.IsNullOrEmpty(dirPath))
                    {
                        Directory.Delete(dirPath, true);
                    } // end if
                    break;
                case DirectoryTask.RENAME:
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
                default:
                    return;
            } // end switch

            populateTreeView();
            lbFileList.Items.Clear();
        } // end method

        private void fileModifyToolstripHandler(DirectoryTask task)
        {
            string dirPath;
            switch (task)
            {
                case DirectoryTask.CREATE:
                    string name = getStringFromDialogBox("New File", "Name");

                    if (String.IsNullOrEmpty(name))
                    {
                        break;
                    } // end if

                    dirPath = getDirectoryPath() + "\\" + name;
                    File.Create(dirPath);

                    break;
                case DirectoryTask.DELETE:
                    dirPath = getDirectoryPath();
                    if (!String.IsNullOrEmpty(dirPath))
                    {
                        File.Delete(dirPath + "\\" + lbFileList.Text);
                    } // end if
                    break;
                case DirectoryTask.OPEN:
                    break;
                case DirectoryTask.RENAME:
                    break;
                default:
                    return;
            } // end switch

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
