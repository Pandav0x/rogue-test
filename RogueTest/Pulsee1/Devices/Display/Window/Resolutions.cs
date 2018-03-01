using System.Collections.Generic;

namespace Pulsee1.Devices.Display.Window
{
    class Resolutions
    {
        /// <summary>
        /// 4:3
        /// </summary>
        public static Dictionary<int, int> StandardResolution = new Dictionary<int, int> {
            { 800, 600 },
            { 1024, 768 },
            { 1280, 960 },
            { 1400, 1050 },
            { 1600, 1200 },
            { 2048, 1536 },
            { 2560, 1920 },
        };

        /// <summary>
        /// 3:2
        /// </summary>
        public static Dictionary<int, int> TVResolution = new Dictionary<int, int> {
            { 1152, 768 },
            { 1281, 854 },
            { 1440, 960 },
            { 2560, 1707 },
        };

        /// <summary>
        /// 16:10
        /// </summary>
        public static Dictionary<int, int> WidescreenResolution = new Dictionary<int, int> {
            { 1680, 1050 },
            { 1920, 1200 },
            { 2560, 1600 }
        };

        /// <summary>
        /// 16:9
        /// </summary>
        public static Dictionary<int, int> HDResolution = new Dictionary<int, int> {
            { 640, 360 },
            { 854, 480 },
            { 1136, 640 },
            { 1280, 720 },
            { 1334, 750 },
            { 1920, 1080 },
            { 2560, 1440 },
        };

    }
}
