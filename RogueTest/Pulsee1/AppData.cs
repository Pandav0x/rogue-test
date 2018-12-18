using System;
using System.Reflection;

namespace Pulsee1
{
    class AppData
    {
        public static string name = "P.U.L.S.E-Engine";
        public static string nameFull = "Panda Unlimited Low Spec Experience Engine";

        public static string version = "0.1.2";

        public static string buildName = "El Bridget";

        public static string buildDate = DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_"+ DateTime.Now.Year.ToString();
     
        private static BuildType _buildType = BuildType.Debug;

        public static string devName = "Pandav0x";

        private static string _currentDirectory = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        private static string _assetsLocation = @"";

        public static bool BuildIsDebug() { return AppData._buildType == BuildType.Debug; }

        public static string CurrentDirectory() { return AppData._currentDirectory; }

        public static string AssetsLocation() { return AppData._currentDirectory+"../Assets/"; }
    }

    public enum BuildType
    {
        Release,
        Debug
    }
}
