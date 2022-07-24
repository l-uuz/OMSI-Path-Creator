using System.Diagnostics;
using System.Media;
using System.Reflection;

using Omsipath.Properties;

namespace Omsipath
{
    internal class Utils
    {
        /// <summary>
        /// Returns the product version of this application
        /// </summary>
        public static string GetVersion()
        {
            return GetProductVersion() ?? "";
        }

        /// <summary>
        /// Returns the name and product version of this application
        /// </summary>
        public static string GetNameAndVersion()
        {
            var version = GetProductVersion();
            if (version == null) return i18n.application_name;
            else return i18n.application_name + ' ' + version;
        }

        private static string? GetProductVersion()
        {
//            var location = Assembly.GetExecutingAssembly().Location;
//            if (File.Exists(location))
//                return FileVersionInfo.GetVersionInfo(location).ProductVersion;

            var location = Environment.ProcessPath;
            if (File.Exists(location))
                return FileVersionInfo.GetVersionInfo(location).ProductVersion;

            return null;
        }

        public static void OpenUrl(string filename)
        {
            try
            {
                Process.Start("explorer.exe", filename);
            }
            catch (Exception)
            {
                Beep();
            }
        }

        public static void Beep()
        {
            SystemSounds.Beep.Play();
        }

    }
}
