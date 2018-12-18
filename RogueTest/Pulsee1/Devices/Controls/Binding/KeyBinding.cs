using System.Collections.Generic;
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

        public static Dictionary<MouseButton, string> mouseBind = new Dictionary<MouseButton, string> {
            { MouseButton.Left, "LMB"},
            { MouseButton.Right, "RMB"},
            { MouseButton.Middle, "MMB"}
        };

        public static Dictionary<GamePadButton, string> gamePadBind = new Dictionary<GamePadButton, string> {
            { GamePadButton.Start, "pause" }
        };

        public enum DeviceType
        {
            Keyboard,
            Mouse,
            Controller
        }
    }
}
