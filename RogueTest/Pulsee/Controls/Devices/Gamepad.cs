using System.Collections.Generic;
using Pulsee.Controls.Devices.Buttons;

namespace Pulsee.Controls.Devices
{
    class Gamepad: IDevice
    {
        public List<GamepadButton> ManagedButtons { get; internal set; }

        public Dictionary<GamepadButton, ButtonState> ButtonsState { get; internal set; }
        public Dictionary<GamepadButton, ButtonEvent> ButtonsEvent { get; internal set; }

        public void Populate()
        {
            throw new System.NotImplementedException();
        }

        public void Refresh()
        {
            throw new System.NotImplementedException();
        }
    }
}
