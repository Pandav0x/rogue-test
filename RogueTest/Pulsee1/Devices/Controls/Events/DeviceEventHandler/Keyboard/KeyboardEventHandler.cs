using System;
using OpenTK;
using OpenTK.Input;
using Pulsee1.Devices.Controls.Binding;
using Pulsee1.Utils.Display;

using Pulsee1.Graphics;

namespace Pulsee1.Devices.Controls.Events.DeviceHandler.Keyboard
{
    class KeyboardEventHandler
    {
        private EventManager _parent;

        public KeyboardEventHandler(EventManager parent_)
        {
            this._parent = parent_;
            return;
        }

        public bool IsBinded(KeyboardKeyEventArgs e)
        {
            return KeyBinding.keyboardBind.TryGetValue(e.Key, out string a);
        }
        
        public void ExtendedEvent()
        {
            return;
        }

        private string GetActionFromKey(KeyboardKeyEventArgs e)
        {
            if (KeyBinding.keyboardBind.ContainsKey(e.Key))
                return KeyBinding.keyboardBind[e.Key];
            return "";
        }

        public void Keh_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (GetActionFromKey(e) == "pause")
                _parent._parent.dim.window.Exit();
            if (GetActionFromKey(e) == "right")
                PulseGL.ResetTexLoaded();
            if (this.IsBinded(e))
                Console.WriteLine("Binded - " + KeyBinding.keyboardBind[e.Key]);
            xConsole.WriteLine(e.Key.ToString()+" ", ConsoleColor.Red);
            return;
        }

        public void Keh_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            return;
        }

        public void Keh_KeyPress(object sender, KeyPressEventArgs e)
        {
            return;
        }
    }
}
