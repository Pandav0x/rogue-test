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
            xConsole.WriteLine(e.Button.ToString() + " - Pressed");
        }

        public void Geh_ButtonUp(object sender, GamepadEventArgs e)
        {
            xConsole.WriteLine(e.Button.ToString() + " - Released");
            //throw new NotImplementedException();
        }

        public void Geh_ButtonPressed(object sender, GamepadEventArgs e)
        {
            xConsole.WriteLine("Button pressed");
            return;
        }

        public void Geh_TriggerDown(object sender, GamepadEventArgs e)
        {
            xConsole.WriteLine("Trigger down");
            return;
        }

        public void Geh_TriggerUp(object sender, GamepadEventArgs e)
        {
            xConsole.WriteLine("Trigger up");
            return;
        }

        public void Geh_LeftStickMove(object sender, GamepadEventArgs e)
        {
            xConsole.WriteLine("lft stick moved");
            return;
        }

        public void Geh_RightStickMove(object sender, GamepadEventArgs e)
        {
            xConsole.WriteLine("rgt stick moved");
            return;
        }
    }
}
