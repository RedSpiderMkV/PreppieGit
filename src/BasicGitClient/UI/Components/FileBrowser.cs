using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGitClient
{
    #region Enums

    enum ContextMenuFileTask
    {
        NEW = 0,
        OPEN = 1,
        RENAME = 2,
        DELETE = 3
    } // end enum

    #endregion

    public partial class FileBrowser : UserControl
    {
        #region Public Methods

        internal FileBrowser(UIEventManager eventManager, SelectedDirectoryEventManager directoryEventManager)
        {
            InitializeComponent();

            eventManager_m = eventManager;
            directoryEventManager_m = directoryEventManager;
            currentSelectedDirectory_m = "";

            newFileToolStripMenuItem.Tag = ContextMenuFileTask.NEW;
            openToolStripMenuItem.Tag = ContextMenuFileTask.OPEN;
            renameToolStripMenuItem.Tag = ContextMenuFileTask.RENAME;
            deleteToolStripMenuItem.Tag = ContextMenuFileTask.DELETE;

            lbFileList.ContextMenuStrip = ctxFileMenuStrip;

            this.Dock = DockStyle.Fill;

            eventManager_m.OnDirectoryChanged += new UIEventManager.DirectoryChangedEvent(eventManager_m_OnDirectoryChanged);
            eventManager.OnRefreshControlsRequest += new UIEventManager.RefreshControlsEvent(eventManager_OnRefreshDirectoryRequest);
            directoryEventManager_m.OnSelectedDirectoryNodeChanged += new SelectedDirectoryEventManager.SelectedDirectoryNodeChangedEvent(directoryEventManager_m_OnSelectedDirectoryNodeChanged);
        } // end method

        #endregion

        #region Private Methods

        private void lbFileList_DoubleClick(object sender, EventArgs e)
        {
            openSelectedFile();
        } // end method

        private void toolStripDirectoryMenuItem_Click(object sender, EventArgs e)
        {
            ContextMenuFileTask task = (ContextMenuFileTask)Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            handlerToolStripTask(task);
        } // end method

        private void handlerToolStripTask(ContextMenuFileTask task)
        {
            string fileName;
            DialogResult result;

            switch (task)
            {
                case ContextMenuFileTask.NEW:
                    SingleTextBoxDialogWindow newFileNameWindow = new SingleTextBoxDialogWindow("File Name...", "Name");
                    result = newFileNameWindow.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        fileName = currentSelectedDirectory_m + "\\" + newFileNameWindow.TextField;
                        if (!File.Exists(fileName))
                        {
                            try
                            {
                                File.Create(fileName);
                            }
                            catch (Exception)
                            {
                                // log this probably..
                            } // end try-catch
                        } // end if
                    } // end if

                    break;
                case ContextMenuFileTask.DELETE:
                    fileName = currentSelectedDirectory_m + "\\" + lbFileList.GetItemText(lbFileList.SelectedItem);
                    if(File.Exists(fileName))
                    {
                        try
                        {
                            File.Delete(fileName);
                        }
                        catch (Exception)
                        {
                            // log this..
                        } // end try-catch
                    } // end if

                    break;
                case ContextMenuFileTask.OPEN:
                    openSelectedFile();

                    break;
                case ContextMenuFileTask.RENAME:
                    SingleTextBoxDialogWindow renameWindow = new SingleTextBoxDialogWindow("Rename File", "Name");
                    result = renameWindow.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string currentFilename = currentSelectedDirectory_m + "\\" + lbFileList.GetItemText(lbFileList.SelectedItem);
                        fileName = currentSelectedDirectory_m + "\\" + renameWindow.TextField;

                        try
                        {
                            File.Move(currentFilename, fileName);
                        }
                        catch (Exception)
                        {
                            //
                        } // end try-catch
                    } // end if

                    break;
                default:
                    return;
            } // end switch

            populateFileList(currentSelectedDirectory_m);
        } // end method

        private void openSelectedFile()
        {
            string fileName = currentSelectedDirectory_m + "\\" + lbFileList.GetItemText(lbFileList.SelectedItem);

            try
            {
                Process.Start(fileName);
            }
            catch (Exception)
            {
                //
            } // end try-catch
        } // end method

        private void directoryEventManager_m_OnSelectedDirectoryNodeChanged(string directoryFullPath)
        {
            currentSelectedDirectory_m = directoryFullPath;
            populateFileList(directoryFullPath);
        } // end method

        private void eventManager_m_OnDirectoryChanged(string newDirectoryFullPath)
        {
            clearFileList();
        } // end method

        private void eventManager_OnRefreshDirectoryRequest()
        {
            clearFileList();
        } // end method

        private void clearFileList()
        {
            lbFileList.Items.Clear();
            currentSelectedDirectory_m = "";
        } // end method

        private void populateFileList(string directory)
        {
            if (directory.Length > 0)
            {
                lbFileList.Items.Clear();

                foreach (string fileWithPath in Directory.GetFiles(directory))
                {
                    lbFileList.Items.Add(Path.GetFileName(fileWithPath));
                } // end foreach
            } // end if
        } // end method

        private void ctxFileMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (currentSelectedDirectory_m.Equals(""))
            {
                ctxFileMenuStrip.Enabled = false;
            }
            else
            {
                ctxFileMenuStrip.Enabled = true;
            } // end if

            if (lbFileList.SelectedItem == null)
            {
                deleteToolStripMenuItem.Enabled = false;
                openToolStripMenuItem.Enabled = false;
                renameToolStripMenuItem.Enabled = false;
            }
            else
            {
                deleteToolStripMenuItem.Enabled = true;
                openToolStripMenuItem.Enabled = true;
                renameToolStripMenuItem.Enabled = true;
            } // end if
        } // end method

        #endregion

        #region Private Data

        private UIEventManager eventManager_m;
        private SelectedDirectoryEventManager directoryEventManager_m;

        private string currentSelectedDirectory_m;

        #endregion

    } // end class
} // end namespace
