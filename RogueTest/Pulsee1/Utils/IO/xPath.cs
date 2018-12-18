using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsee1.Utils.IO
{
    class xPath
    {
        private string[] _path;
        private string _stringPath;

        public string[] Path { get { return _path; } }
        public string StringPath { get { return _stringPath; } }


        public xPath() { return; }

        public xPath(string path_)
        {
            this._stringPath = path_;
            ExplodeDaString();
            return;
        }

        private void ExplodeDaString()
        {
            this._path = this._stringPath.Split('\\');
            return;
        }
    }
}
