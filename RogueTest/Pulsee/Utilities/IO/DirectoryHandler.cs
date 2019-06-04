using System.Collections.Generic;
using System.IO;

namespace Pulsee.Utilities.IO
{
    class DirManagement
    {
        public static List<string> GetAllFiles(string path_)
        {
            List<string> files = new List<string>();

            foreach (string file in Directory.GetFiles(path_))
                files.Add(file.Substring(file.LastIndexOf('\\')));

            return files;
        }
    }
}
