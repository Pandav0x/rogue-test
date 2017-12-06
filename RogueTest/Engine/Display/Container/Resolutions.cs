using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueTest.Engine.Display.Container
{
    class Resolutions
    {
        public static Dictionary<int, int> resolution = new Dictionary<int, int> {
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
