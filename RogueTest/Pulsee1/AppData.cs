using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsee1
{
    class AppData
    {
        public static string name = "P.U.L.S.E Engine";
        public static string nameFull = "Panda Unlimited Low Spec Experience Engine";

        public static string version = "0.1.0";
        public static string buildName = "El Bridget";

        public static string buildDate = DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_"+ DateTime.Now.Year.ToString();
     
        public static string buildType = "DEBUG";

        public static string devName = "Panda";

        public static bool BuildIsDebug(){return AppData.buildType == "DEBUG";}
    }
}
