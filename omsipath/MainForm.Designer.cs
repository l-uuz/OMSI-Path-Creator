namespace Omsipath
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fileList = new System.Windows.Forms.CheckedListBox();
            this.targetButton = new System.Windows.Forms.Button();
            this.targetLabel = new System.Windows.Forms.Label();
            this.copyFiles = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.subCombobox = new System.Windows.Forms.ComboBox();
            this.subLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.fileCopyWorker = new System.ComponentModel.BackgroundWorker();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.deleteSelected = new System.Windows.Forms.Button();
            this.deleteAll = new System.Windows.Forms.Button();
            this.topLayout = new System.Windows.Forms.TableLayoutPanel();
            this.targetTextbox = new System.Windows.Forms.TextBox();
            this.editSession = new System.Windows.Forms.Button();
            this.bottomLayout = new System.Windows.Forms.TableLayoutPanel();
            this.infoButton = new System.Windows.Forms.Button();
            this.topLayout.SuspendLayout();
            this.bottomLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileList
            // 
            resources.ApplyResources(this.fileList, "fileList");
            this.fileList.CheckOnClick = true;
            this.fileList.FormattingEnabled = true;
            this.fileList.Name = "fileList";
            this.fileList.Sorted = true;
            this.toolTip.SetToolTip(this.fileList, resources.GetString("fileList.ToolTip"));
            // 
            // targetButton
            // 
            resources.ApplyResources(this.targetButton, "targetButton");
            this.targetButton.Image = global::Omsipath.Properties.Resources.Folder;
            this.targetButton.Name = "targetButton";
            this.toolTip.SetToolTip(this.targetButton, resources.GetString("targetButton.ToolTip"));
            this.targetButton.Click += new System.EventHandler(this.OnClickSelectTarget);
            // 
            // targetLabel
            // 
            resources.ApplyResources(this.targetLabel, "targetLabel");
            this.targetLabel.Name = "targetLabel";
            // 
            // copyFiles
            // 
            resources.ApplyResources(this.copyFiles, "copyFiles");
            this.copyFiles.Image = global::Omsipath.Properties.Resources.Check;
            this.copyFiles.Name = "copyFiles";
            this.toolTip.SetToolTip(this.copyFiles, resources.GetString("copyFiles.ToolTip"));
            this.copyFiles.UseVisualStyleBackColor = true;
            this.copyFiles.Click += new System.EventHandler(this.CopyFiles_Click);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            this.progressBar.Step = 1;
            // 
            // subCombobox
            // 
            this.subCombobox.FormattingEnabled = true;
            resources.ApplyResources(this.subCombobox, "subCombobox");
            this.subCombobox.Name = "subCombobox";
            this.subCombobox.Sorted = true;
            this.toolTip.SetToolTip(this.subCombobox, resources.GetString("subCombobox.ToolTip"));
            // 
            // subLabel
            // 
            resources.ApplyResources(this.subLabel, "subLabel");
            this.subLabel.Name = "subLabel";
            // 
            // folderBrowserDialog
            // 
            resources.ApplyResources(this.folderBrowserDialog, "folderBrowserDialog");
            // 
            // fileCopyWorker
            // 
            this.fileCopyWorker.WorkerReportsProgress = true;
            this.fileCopyWorker.WorkerSupportsCancellation = true;
            this.fileCopyWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FileCopyWorker_DoWork);
            this.fileCopyWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.FileCopyWorker_ProgressChanged);
            this.fileCopyWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FileCopyWorker_RunWorkerCompleted);
            // 
            // deleteSelected
            // 
            resources.ApplyResources(this.deleteSelected, "deleteSelected");
            this.deleteSelected.Image = global::Omsipath.Properties.Resources.Minus;
            this.deleteSelected.Name = "deleteSelected";
            this.toolTip.SetToolTip(this.deleteSelected, resources.GetString("deleteSelected.ToolTip"));
            this.deleteSelected.UseVisualStyleBackColor = true;
            this.deleteSelected.Click += new System.EventHandler(this.DeleteSelected_Click);
            // 
            // deleteAll
            // 
            resources.ApplyResources(this.deleteAll, "deleteAll");
            this.deleteAll.Image = global::Omsipath.Properties.Resources.Times;
            this.deleteAll.Name = "deleteAll";
            this.toolTip.SetToolTip(this.deleteAll, resources.GetString("deleteAll.ToolTip"));
            this.deleteAll.UseVisualStyleBackColor = true;
            this.deleteAll.Click += new System.EventHandler(this.DeleteAll_Click);
            // 
            // topLayout
            // 
            resources.ApplyResources(this.topLayout, "topLayout");
            this.topLayout.Controls.Add(this.targetLabel, 0, 0);
            this.topLayout.Controls.Add(this.subCombobox, 1, 1);
            this.topLayout.Controls.Add(this.subLabel, 0, 1);
            this.topLayout.Controls.Add(this.targetTextbox, 1, 0);
            this.topLayout.Controls.Add(this.targetButton, 2, 0);
            this.topLayout.Controls.Add(this.editSession, 2, 1);
            this.topLayout.Name = "topLayout";
            // 
            // targetTextbox
            // 
            resources.ApplyResources(this.targetTextbox, "targetTextbox");
            this.targetTextbox.Name = "targetTextbox";
            this.targetTextbox.ReadOnly = true;
            // 
            // editSession
            // 
            resources.ApplyResources(this.editSession, "editSession");
            this.editSession.Image = global::Omsipath.Properties.Resources.Settings;
            this.editSession.Name = "editSession";
            this.editSession.Click += new System.EventHandler(this.editSession_Click);
            // 
            // bottomLayout
            // 
            resources.ApplyResources(this.bottomLayout, "bottomLayout");
            this.bottomLayout.Controls.Add(this.infoButton, 4, 0);
            this.bottomLayout.Controls.Add(this.deleteSelected, 2, 0);
            this.bottomLayout.Controls.Add(this.copyFiles, 0, 0);
            this.bottomLayout.Controls.Add(this.deleteAll, 1, 0);
            this.bottomLayout.Controls.Add(this.progressBar, 3, 0);
            this.bottomLayout.Name = "bottomLayout";
            // 
            // infoButton
            // 
            resources.ApplyResources(this.infoButton, "infoButton");
            this.infoButton.Image = global::Omsipath.Properties.Resources.Info;
            this.infoButton.Name = "infoButton";
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.copyFiles;
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bottomLayout);
            this.Controls.Add(this.topLayout);
            this.Controls.Add(this.fileList);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.topLayout.ResumeLayout(false);
            this.topLayout.PerformLayout();
            this.bottomLayout.ResumeLayout(false);
            this.bottomLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox targetTextbox;
        private System.Windows.Forms.CheckedListBox fileList;
        private System.Windows.Forms.Button targetButton;
        private System.Windows.Forms.Label targetLabel;
        private System.Windows.Forms.Button copyFiles;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ComboBox subCombobox;
        private System.Windows.Forms.Label subLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.ComponentModel.BackgroundWorker fileCopyWorker;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TableLayoutPanel topLayout;
        private System.Windows.Forms.TableLayoutPanel bottomLayout;
        private System.Windows.Forms.Button deleteSelected;
        private System.Windows.Forms.Button deleteAll;
        private Button editSession;
        private Button infoButton;
    }
}

