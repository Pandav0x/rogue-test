using System;
using System.IO;
using System.Web.Script.Serialization;

namespace Pulsee1
{
    class Config
    {
        private Config config;

        private Config ()
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            dynamic config = jsonSerializer.Deserialize<dynamic>(File.ReadAllText("./Config/Pulsee1.json"));
        }

        private static BuildType _buildType = BuildType.Debug;
        public static string buildDate = DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString();
    }
}
