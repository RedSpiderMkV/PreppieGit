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
    internal partial class ControlDirectoryBrowser : UserControl
    {
        public ControlDirectoryBrowser(UIEventManager eventManager)
        {
            InitializeComponent();

            eventManager_m = eventManager;
            eventManager_m.OnDirectoryChanged += new UIEventManager.DirectoryChangedEvent(eventManager_m_OnDirectoryChanged);
        } // end method

        private void eventManager_m_OnDirectoryChanged(string newDirectoryFullPath)
        {
            tvDirectoryList.Nodes.Clear();
            lbFileList.Items.Clear();

            TreeNode rootNode;
            DirectoryInfo info = new DirectoryInfo(newDirectoryFullPath);

            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
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

        private UIEventManager eventManager_m;
        private TreeNode currentSelectedNode_m;
        private string currentDirectoryPath_m;
        private string treeViewSelectedDirectory_m;
    } // end class
} // end namespace
