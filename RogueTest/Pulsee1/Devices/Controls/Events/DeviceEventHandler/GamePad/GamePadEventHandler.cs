using OpenTK.Input;
using Pulsee1.Devices.Controls.Binding;
using Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.GamePad;
using Pulsee1.Utils.Display;

namespace Pulsee1.Devices.Controls.Events.DeviceHandler.GamePad
{
    class GamePadEventHandler
    {
        private EventManager _parent;

        public GamePadEventHandler(EventManager parent_)
        {
            this._parent = parent_;
            return;
        }

        public bool IsBinded()
        {
            return KeyBinding.gamePadBind.TryGetValue(GamePadButton.X, out string a);
        }

        public void Geh_ButtonDown(object sender, GamePadButtonEventArgs e)
        {
            xConsole.WriteLine("Mon zbi est un volcan");
            return;
        }

        public void Geh_ButtonUp(object sender, GamePadButtonEventArgs e)
        {
            xConsole.WriteLine("Mon zbi est un volcan, encore !");
            return;
        }

    }
}
