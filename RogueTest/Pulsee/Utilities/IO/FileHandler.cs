using System;
using System.IO;

namespace Pulsee.Utilities.IO
{
    class FileHandler
    {
        public FileHandler() { return; }

        public FileHandler(string file)
        {
            return;
        }

        public string GetLine(int lineToGet, string path)
        {
            int counter = 0;
            string line, ans = "";
            StreamReader file = new StreamReader(Environment.CurrentDirectory + path);
            while ((line = file.ReadLine()) != null)
            {
                if (counter == lineToGet)
                {
                    ans += line;
                    break;
                }
                counter++;
            }
            file.Close();
            return ans;
        }
    }
}
