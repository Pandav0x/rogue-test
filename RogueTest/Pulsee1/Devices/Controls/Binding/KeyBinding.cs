using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace Pulsee1.Devices.Controls.Binding
{
    class KeyBinding
    {
        public static Dictionary<Key, string> keyboardBind = new Dictionary<Key, string> {
            { Key.Escape, "pause"},
            { Key.W , "up"},
            { Key.S , "down"},
            { Key.A , "left"},
            { Key.D , "right"}
        };

        public static Dictionary<Key, string> mouseBind = new Dictionary<Key, string> {
            { Key.Escape, "pause" }
        };

        public static Dictionary<Key, string> controllerBind = new Dictionary<Key, string> {
            { Key.Escape, "pause" }
        };

        public enum DeviceType
        {
            Keyboard,
            Mouse,
            Controller
        }
    }
}
