﻿using System;
using Pulsee1.Devices.Controls.Binding;
using Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.Gamepad;
using Pulsee1.Utils.Display;

namespace Pulsee1.Devices.Controls.Events.DeviceHandler.Gamepad
{
    class GamepadEventHandler
    {
        private EventManager _parent;

        public GamepadEventHandler(EventManager parent_)
        {
            this._parent = parent_;
            return;
        }

        public GamepadEventHandler()
        {
            return;
        }
        
        public bool IsBinded()
        {
            return KeyBinding.gamepadBind.TryGetValue(GamepadButton.X, out string a);
        }

        public void Geh_ButtonDown(object sender, GamepadEventArgs e)
        {
            //TODO
            foreach (GamepadButton b in e.Buttons)
                xConsole.WriteLine(b.ToString());
        }

        public void Geh_ButtonPressed(object sender, GamepadEventArgs e)
        {
            xConsole.WriteLine("Button pressed");
            return;
        }

        internal void Geh_ButtonUp(object sender, GamepadEventArgs e)
        {
            return;
            //throw new NotImplementedException();
        }
    }
}
