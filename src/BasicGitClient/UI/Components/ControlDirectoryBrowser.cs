using System;
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
        DELETE
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

        private void newDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            directoryModify(DirectoryTask.CREATE);
        }

        private void deleteDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            directoryModify(DirectoryTask.DELETE);
        }

        private void renameDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            directoryModify(DirectoryTask.RENAME);
        }

        private void directoryModify(DirectoryTask task)
        {
            switch (task)
            {
                case DirectoryTask.CREATE:
                    if (currentSelectedNode_m != null)
                    {
                        string dirPath = Directory.GetParent(currentDirectoryPath_m) + "\\" + currentSelectedNode_m.FullPath + "\\New Folder";
                        Directory.CreateDirectory(dirPath);
                    }
                    else
                    {
                        string dirPath = currentDirectoryPath_m + "\\New Folder";
                        Directory.CreateDirectory(currentDirectoryPath_m + "\\New Folder");
                    } // end if
                    break;
                case DirectoryTask.DELETE:
                    if (currentSelectedNode_m != null)
                    {
                        string dirPath = Directory.GetParent(currentDirectoryPath_m) + "\\" + currentSelectedNode_m.FullPath;
                        Directory.Delete(dirPath, true);
                    } // end if
                    break;
                case DirectoryTask.RENAME:
                    if (currentSelectedNode_m != null)
                    {
                        string dirPath = Directory.GetParent(currentDirectoryPath_m) + "\\" + currentSelectedNode_m.FullPath; ;

                        SingleTextBoxDialogWindow dialog = new SingleTextBoxDialogWindow("Rename", "Name");
                        DialogResult result = dialog.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            string newName = dialog.TextField;
                            string[] dirPathParts = dirPath.Split('\\');
                            dirPathParts[dirPathParts.Length - 1] = newName;

                            string newFullPath = "";

                            foreach (string part in dirPathParts)
                            {
                                newFullPath += part + "\\";
                            } // end foreach

                            Directory.Move(dirPath, newFullPath);
                        } // end if
                    } // end if
                    break;
                default:
                    break;
            } // end switch
        } // end method

        private UIEventManager eventManager_m;
        private TreeNode currentSelectedNode_m;
        private string currentDirectoryPath_m;
        private string treeViewSelectedDirectory_m;
    } // end class
} // end namespace
