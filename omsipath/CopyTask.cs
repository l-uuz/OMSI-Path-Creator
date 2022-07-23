namespace Omsipath
{
    /// <summary>
    /// A task which is executed if copying is started.
    /// </summary>
    internal class CopyTask
    {
        public CopyTask(string target, OverwriteInstruction overwriteInstruction)
        {
            Target = target;
            OverwriteInstruction = overwriteInstruction;
        }

        /// <summary>
        /// Stores which files are to copy.
        /// </summary>
        public HashSet<FileToCopy> FilesToCopy { get; } = new();

        /// <summary>
        /// The target directory
        /// </summary>
        public string Target { get; }

        /// <summary>
        /// Stores how existing files will be handled by the task.
        /// </summary>
        public OverwriteInstruction OverwriteInstruction { get; } // Default

        public bool HasNoFiles() => FilesToCopy.Count == 0;

    }

    /// <summary>
    /// A pair with a source and a target file.
    /// </summary>
    internal struct FileToCopy
    {
        public FileToCopy(string source, string target)
        {
            if (!File.Exists(source)) throw new ArgumentException($"The source file \"{ source }\" does not exist.");
            if (string.IsNullOrWhiteSpace(target)) throw new ArgumentException("The target path must not be empty!");

            Target = target;
            Source = source;
        }

        public string Source { get; }
        public string Target { get; }
    }

    /// <summary>
    /// Different options how existing files will be handled.
    /// </summary>
    internal enum OverwriteInstruction
    {
        /// <summary>
        /// An existing folder will be deleted so the output directory is a "fresh" copy (DEFAULT)
        /// </summary>
        DeleteBeforeCopying = 0,

        /// <summary>
        /// Existing files will be overwritten and all new files will be copied.
        /// </summary>
        CopyAllAndOverwrite = 1,

        /// <summary>
        /// Only existing files will be replaced. New files will be not copied.
        /// </summary>
        OnlyOverwrite = 2,

        /// <summary>
        /// Only new files will be copied.
        /// </summary>
        NotOverwrite = 3
    }
}
