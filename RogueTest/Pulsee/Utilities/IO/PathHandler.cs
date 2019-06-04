using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsee.Utilities.IO
{
    class PathHandler
    {
        private string[] _path;
        private string _stringPath;

        public string[] Path { get { return _path; } }
        public string StringPath { get { return _stringPath; } }


        public PathHandler() { return; }

        public PathHandler(string path_)
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
