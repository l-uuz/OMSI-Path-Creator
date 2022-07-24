
// ReSharper disable StringLastIndexOfIsCultureSpecific.1

namespace Omsipath
{

    /// <summary>
    /// A file or directory entry, mainly a helper class for UI (e.g. to store a path entry in ListBoxes etc.).
    /// </summary>
    internal abstract class Entry
    {
        public string AbsolutePath { get; }

        protected Entry(string absolutePath)
        {
            this.AbsolutePath = absolutePath;
        }

        /// <summary>
        /// Generates a list with absolute file paths.
        /// </summary>
        /// <returns>A non-null collection of strings that represent absolute file names.</returns>
        public abstract IEnumerable<string> ToAbsoluteFiles();

        /// <summary>
        /// Generates a string representation (basically for UI and comparison)
        /// </summary>
        public abstract override string ToString();

        public sealed override bool Equals(object? obj)
        {
            if (obj is not Entry other) return false; // null-check inclusive
            return ToString() == other.ToString();
        }

        public sealed override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }

    /// <summary>
    /// An entry where the stored absolute path is only a simple file.
    /// </summary>
    internal class FileEntry : Entry
    {
        public FileEntry(string absolutePath) : base(absolutePath) { }

        public override IEnumerable<string> ToAbsoluteFiles()
        {
            // Return just the file path
            return new[] { AbsolutePath };
        }

        public override string ToString()
        {
            // Return the file name, shortened by the OMSI path
            return AbsolutePath.Substring(AbsolutePath.LastIndexOf(@"OMSI 2") + 7);
        }
    }

    /// <summary>
    /// An entry where the stored absolute path is a directory that can contains other files and directories.
    /// </summary>
    internal class DirectoryEntry : Entry
    {
        public DirectoryEntry(string absolutePath) : base(absolutePath) { }

        public override IEnumerable<string> ToAbsoluteFiles()
        {
            if (!Directory.Exists(AbsolutePath)) return Enumerable.Empty<string>();

            // Search recursively for files in the directory
            return Directory.GetFiles(AbsolutePath, "*.*", SearchOption.AllDirectories);
        }

        public override string ToString()
        {
            // Returns the (shortened) path with the suffix "*" to indicate that this is a directory and not a simple file
            return string.Concat(AbsolutePath.AsSpan(AbsolutePath.LastIndexOf(@"OMSI 2") + 7), @"\*");
        }
    }
}
