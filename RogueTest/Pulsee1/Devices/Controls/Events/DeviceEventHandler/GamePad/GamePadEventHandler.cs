using OpenTK.Input;
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

        public bool IsBinded()
        {
            return KeyBinding.gamepadBind.TryGetValue(GamepadButton.X, out string a);
        }

        public void Geh_ButtonDown(object sender, GamepadButtonEventArgs e)
        {
            xConsole.WriteLine("Mon zbi est un volcan");
            return;
        }

        public void Geh_ButtonUp(object sender, GamepadButtonEventArgs e)
        {
            xConsole.WriteLine("Mon zbi est un volcan, encore !");
            return;
        }

    }
}
