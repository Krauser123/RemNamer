using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace remNamer.Class
{
    internal class Helper
    {
        internal static List<string> GetFiles(string initialDirPath, bool recursiveSearch, string[] extensionFilters)
        {
            //Get files in root directory
            List<string> files = new List<string>();

            if (recursiveSearch)
            {
                var directories = Directory.GetDirectories(initialDirPath);

                foreach (var subDirectoryPath in directories)
                {
                    var subItems = GetFilesUsingFilters(subDirectoryPath, extensionFilters);
                    files.AddRange(subItems);
                }
            }
            else
            {
                files = GetFilesUsingFilters(initialDirPath, extensionFilters);
            }

            return files;
        }

        internal static List<string> GetFilesUsingFilters(string directoryPath, string[] extensionFilters)
        {
            List<string> files = null;
            if (extensionFilters != null)
            {
                files = extensionFilters.SelectMany(filter => Directory.GetFiles(directoryPath, filter)).ToList();
            }
            else
            {
                files = Directory.GetFiles(directoryPath).ToList();
            }

            return files;
        }
    }
}
