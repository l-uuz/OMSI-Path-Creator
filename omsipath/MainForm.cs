using Omsipath.Properties;
using System.ComponentModel;

namespace Omsipath
{
    internal partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Additional actions on form loading
        /// <list type="bullet">
        ///     <item>Set size from saved settings</item>
        ///     <item>Show application version in header</item>
        ///     <item>Refresh the combobox with the sub directories</item>
        /// </list>
        /// </summary>
        private void OnFormLoad(object sender, EventArgs e)
        {
            Size = Settings.Default.windowSize; // automatically within boundary
            Text = Utils.GetNameAndVersion();
            RefreshSubdirectoryCombobox();

            targetTextbox.DataBindings.Add(nameof(targetTextbox.Text), Settings.Default, nameof(Settings.Default.targetDirectory), true, DataSourceUpdateMode.OnPropertyChanged);
            targetTextbox.Text = Settings.Default.targetDirectory;
        }

        // Called when the form is closing => save the form's size
        /// <summary>
        /// Additional actions on form closing
        /// <list type="bullet">
        ///     <item>Cancel the background worker for file copying</item>
        ///     <item>Save the current window size in the settings</item>
        /// </list>
        /// </summary>
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (fileCopyWorker.IsBusy) fileCopyWorker.CancelAsync();
            Settings.Default.windowSize = Size;
            Settings.Default.Save();
        }

        /// <summary>
        /// Opens a dialog to select the target path
        /// </summary>
        private void OnClickSelectTarget(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.targetDirectory = folderBrowserDialog.SelectedPath;
                Settings.Default.Save();
                Settings.Default.Reload();
                RefreshSubdirectoryCombobox();
            }
        }

        /// <summary>
        /// Updates the combobox with sub directories from the settings
        /// </summary>
        private void RefreshSubdirectoryCombobox()
        {
            subCombobox.Items.Clear();
            if (Settings.Default.targetDirectory != null && Directory.Exists(Settings.Default.targetDirectory))
                foreach (var item in Directory.GetDirectories(Settings.Default.targetDirectory))
                    subCombobox.Items.Add(item.Substring(item.LastIndexOf("\\", StringComparison.Ordinal) + 1));

            // Removes sub directory "OMSI 2" in case of there previously was no sub directory entered
            subCombobox.Items.Remove("OMSI 2");
        }

        /// <summary>
        /// Validates the drag-drop event, shows an effect if the file's directory contains a partial path called "OMSI 2"
        /// </summary>
        private void OnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop) && ((string[])e.Data.GetData(DataFormats.FileDrop)).All(path => path.Contains(@"\OMSI 2\")))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// Finishes the drag-drop event and adds a new directory or file entry depending on the dragged element
        /// </summary>
        private void OnDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null) return;
            foreach (var dragged in ((string[])e.Data.GetData(DataFormats.FileDrop)).Where(path => path.Contains(@"\OMSI 2")))
            {
                if (File.Exists(dragged))
                {
                    var newEntry = new FileEntry(dragged);
                    if (!fileList.Items.OfType<FileEntry>().Contains(newEntry)) fileList.Items.Add(newEntry);
                }
                else if (Directory.Exists(dragged))
                {
                    var newEntry = new DirectoryEntry(dragged);
                    if (!fileList.Items.OfType<DirectoryEntry>().Contains(newEntry)) fileList.Items.Add(newEntry);
                }
            }
        }

        /// <summary>
        /// Deletes all items from the list
        /// </summary>
        private void DeleteAll_Click(object sender, EventArgs e)
        {
            fileList.Items.Clear();
        }

        /// <summary>
        /// Removes the selected items from the list
        /// </summary>
        private void DeleteSelected_Click(object sender, EventArgs e)
        {
            // Removes each selected entry
            // https://stackoverflow.com/questions/14590726/how-to-delete-multiple-checked-items-from-checkedlistbox
            fileList.CheckedItems.OfType<Entry>().ToList().ForEach(fileList.Items.Remove);
        }

        /// <summary>
        /// Ensures the conditions for copying, asks for an overwrite instruction if neccessary and finally starts with copying the files
        /// </summary>
        private void CopyFiles_Click(object sender, EventArgs e)
        {

            // Preconditions
            try
            {
                CheckPreconditions();
            }
            catch (PreconditionException exception)
            {
                MessageBox.Show(exception.Message, i18n.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Remove invalid path characters from the target directory
            string targetDirectory = Settings.Default.targetDirectory;
            if (!string.IsNullOrWhiteSpace(subCombobox.Text)) targetDirectory += "\\" + string.Join("_", subCombobox.Text.Split(Path.GetInvalidPathChars()));

            // Get the overwrite instruction, cancel if user cancelled the operation
            OverwriteInstruction? overwriteInstruction = GetOverwriteInstruction(targetDirectory);
            if (!overwriteInstruction.HasValue) return;

            // Prepare the UI
            UpdateUiForBackgroundTask(false);

            CopyTask? task;
            try
            {
                task = PrepareTask(targetDirectory, overwriteInstruction.Value);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, i18n.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cancel if no file is to copy
            if (task.HasNoFiles())
            {
                MessageBox.Show(i18n.msg_noFiles, i18n.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Reactivate UI
                UpdateUiForBackgroundTask(true);
                return;
            }

            // Update progress bar
            progressBar.Value = 0;
            progressBar.Maximum = task.FilesToCopy.Count;

            // Start the background worker and pass the task
            fileCopyWorker.RunWorkerAsync(task);
        }

        /// <summary>
        /// Checks that
        /// <list type="bullet">
        /// <item>the target directory exists</item>
        /// </list>
        /// Throws an exception if the action is to be cancelled because the preconditions are not fulfilled.
        /// </summary>
        /// <exception cref="PreconditionException"/>
        private void CheckPreconditions()
        {
            if (Settings.Default.targetDirectory == null || !Directory.Exists(Settings.Default.targetDirectory))
                throw new PreconditionException(i18n.msg_invalidTarget);

            if (subCombobox.Text.ToUpper().Equals("OMSI 2"))
                throw new PreconditionException(i18n.msg_invalidProjectName);

            if (fileList.Items.Count == 0)
                throw new PreconditionException(i18n.msg_noFiles);
        }

        /// <summary>
        /// Get an instruction for existing files: Returns "full overwrite" if the target directory does not exists, otherwise asks the user for an instruction
        /// </summary>
        /// <returns>A overwrite instruction or NULL if cancelled</returns>
        private static OverwriteInstruction? GetOverwriteInstruction(string target)
        {
            if (!Directory.Exists(target)) return OverwriteInstruction.DeleteBeforeCopying;

            OverwriteDialog dialog = new(target);
            if (dialog.ShowDialog() == DialogResult.OK) return dialog.OverwriteInstruction;

            // Cancelled
            return null;
        }

        /// <summary>
        /// Prepares the task object
        /// </summary>
        private CopyTask PrepareTask(string target, OverwriteInstruction overwriteInstruction)
        {
            // Prepare the CopyTask object
            CopyTask task = new(target, overwriteInstruction);

            // Collect all files to copy
            foreach (var entry in fileList.Items.OfType<Entry>())
            {
                foreach (var sourceFile in entry.ToAbsoluteFiles())
                {
                    // TODO Better Exception handling if file was deleted mheanwile - see also FileToCopy constructor
                    var targetFile = string.Concat(task.Target, @"\", sourceFile.AsSpan(sourceFile.LastIndexOf("OMSI 2", StringComparison.Ordinal)));
                    task.FilesToCopy.Add(new FileToCopy(sourceFile, targetFile));
                }
            }

            return task;
        }

        // Background worker (Background thread)
        /// <summary>
        /// The background worker uses this method to work in background
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        private void FileCopyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is not CopyTask task) throw new ArgumentException("Argument is not a CopyTask.");

            try
            {
                if (task.OverwriteInstruction == OverwriteInstruction.DeleteBeforeCopying && Directory.Exists(task.Target))
                {
                    Directory.Delete(task.Target, true);
                }

                foreach (var copiedFile in task.FilesToCopy)
                {
                    if (fileCopyWorker.CancellationPending)
                    {
                        return;
                    }

                    switch (task.OverwriteInstruction)
                    {
                        // First create the directory, then copy the files
                        case OverwriteInstruction.DeleteBeforeCopying:
                        case OverwriteInstruction.CopyAllAndOverwrite:
                            Directory.CreateDirectory(Path.GetDirectoryName(copiedFile.Target) ?? throw new ArgumentException("Illegal path."));
                            File.Copy(copiedFile.Source, copiedFile.Target, true);
                            break;

                        // Only copy if file already exists
                        case OverwriteInstruction.OnlyOverwrite:
                            if (File.Exists(copiedFile.Target))
                            {
                                File.Copy(copiedFile.Source, copiedFile.Target, true);
                            }
                            break;

                        // Don't overwrite existing files
                        case OverwriteInstruction.NotOverwrite:
                            Directory.CreateDirectory(Path.GetDirectoryName(copiedFile.Target) ?? throw new ArgumentException("Illegal path."));
                            if (!File.Exists(copiedFile.Target))
                            {
                                File.Copy(copiedFile.Source, copiedFile.Target, true);
                            }
                            break;
                        default:
                            throw new ArgumentException(task.OverwriteInstruction + @" is not supported.");
                    }

                    // Update the progress bar
                    fileCopyWorker.ReportProgress(1);
                }
            }
            catch (Exception)
            {
                e.Result = i18n.msg_copyError;
            }
        }

        /// <summary>
        /// Updates the progress of the background worker
        /// </summary>
        private void FileCopyWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.PerformStep();
        }

        /// <summary>
        /// Finishes background working
        /// </summary>
        private void FileCopyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is string resultMsg)
            {
                MessageBox.Show(resultMsg, i18n.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateUiForBackgroundTask(true);
            RefreshSubdirectoryCombobox();
        }

        /// <summary>
        /// Set all important elements (buttons, text boxes, etc) to disabled or enabled, depending on the passed value
        /// </summary>
        private void UpdateUiForBackgroundTask(bool enable)
        {
            topLayout.Enabled = enable;
            fileList.Enabled = enable;
            copyFiles.Enabled = enable;
            deleteAll.Enabled = enable;
            deleteSelected.Enabled = enable;
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            new InfoForm().ShowDialog();
        }
        
        /// <summary>
        /// Shows the session dialog
        /// </summary>
        private void editSession_Click(object sender, EventArgs e)
        {
            // Dialog can only be shown if target directory is not empty
            // Otherwise the session files could not be loaded
            if (string.IsNullOrWhiteSpace(Settings.Default.targetDirectory) ||
                !Directory.Exists(Settings.Default.targetDirectory))
            {
                MessageBox.Show(i18n.msg_invalidTarget, i18n.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var currentSession = new Session
            {
                ProjectName = string.Join("_", subCombobox.Text.Split(Path.GetInvalidPathChars()))
            };
            currentSession.Entries.AddRange(fileList.Items.OfType<Entry>());

            var sessionForm = new SessionForm(currentSession);
            if (sessionForm.ShowDialog() == DialogResult.OK && sessionForm.SessionToLoad != null)
            {
                // If a new session was loaded in the dialog, the UI is updated
                subCombobox.Text = sessionForm.SessionToLoad.ProjectName;
                fileList.Items.Clear();
                foreach (var entry in sessionForm.SessionToLoad.Entries)
                {
                    if (!fileList.Items.Contains(entry)) fileList.Items.Add(entry);
                }
                
            }
        }
    }
}
