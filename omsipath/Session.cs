using Omsipath.Properties;

namespace Omsipath
{
    /// <summary>
    /// A container with the project name and all file / directory entries.
    /// It can be saved for later purposes, even across application launches.
    /// </summary>
    internal class Session
    {
        public string ProjectName { get; set; } = string.Empty;
        public List<Entry> Entries { get; } = new();
    }

    internal static class SessionManager
    {
        // TODO Exception handling should better occur in SessionForm!

        /// <summary>
        /// Saves the entries in a file called &lt;ProjectName&gt;.session.txt.
        /// </summary>
        public static void WriteSession(Session session)
        {
            try
            {
                using StreamWriter writer = new(Settings.Default.targetDirectory + @"\" + session.ProjectName + ".session.txt");
                writer.WriteLine("# Made with Omsipath by Lukas G. / Lµkas");
                foreach (var entry in session.Entries)
                {
                    writer.Write(entry.GetType().Name);
                    writer.Write('|');
                    writer.WriteLine(entry.AbsolutePath);
                }
            }
            catch (Exception)
            {
                // TODO Better Exception handling
                throw;
            }
        }

        /// <summary>
        /// Lists all found session.txt files in the current target directory.
        /// </summary>
        public static IEnumerable<string> FindSessions()
        {
            try
            {
                var files = Directory.GetFiles(Settings.Default.targetDirectory, "*.session.txt", SearchOption.TopDirectoryOnly);
                for (var i = 0; i < files.Length; i++)
                {
                    // Shorten the path to the filename and cut off ".session.txt"
                    var filename = Path.GetFileName(files[i]);
                    files[i] = filename[..filename.LastIndexOf(".session.txt", StringComparison.Ordinal)];
                }
                Array.Sort(files);
                return files;
            }
            catch (Exception)
            {
                // TODO Better Exception handling
                return Enumerable.Empty<string>();
            }
        }

        /// <summary>
        /// Tries to read the session with the given name.
        /// </summary>
        /// <returns>Session or null if e.g. file not found.</returns>
        public static Session? ReadSession(string name)
        {
            try
            {
                using StreamReader reader = new(Settings.Default.targetDirectory + @"\" + name + ".session.txt");
                var session = new Session { ProjectName = name };

                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("FileEntry|"))
                    {
                        session.Entries.Add(new FileEntry(line.Substring(10)));
                    }
                    else if (line.StartsWith("DirectoryEntry|"))
                    {
                        session.Entries.Add(new DirectoryEntry(line.Substring(15)));
                    }
                }
                return session;
            }
            catch (Exception)
            {
                // TODO Better Exception handling
                return null;
            }
        }

        public static void DeleteSession(string name)
        {
            try
            {
                File.Delete(Settings.Default.targetDirectory + @"\" + name + ".session.txt");
            }
            catch (Exception)
            {
                // TODO Better Exception handling
                // Do nothing, because in most cases, file does not exist.?
            }
        }
    }
}
