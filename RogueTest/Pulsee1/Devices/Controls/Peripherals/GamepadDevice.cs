using OpenTK.Input;
using Pulsee1.Utils.Display;
using System.Threading;

namespace RogueTest.Pulsee1.Devices.Controls.Peripherals
{
    class GamepadDevice
    {
        private Thread _thread;
        private int _gamepadId;
        private string _gamepadName;
        private GamepadStateWeighted _actualState, _newState;
        private GamePadCapabilities _gamepadCapa;

        public GamepadDevice()
        {
            this._thread = new Thread(Listen);
            return;
        }

        public GamepadDevice(int index_)
        {
            this._gamepadId     = index_;
            this._gamepadName   = GamePad.GetName(index_);
            this._actualState   =  new GamepadStateWeighted(GamePad.GetState(this._gamepadId));
            this._newState      = this._actualState;
            this._gamepadCapa   = GamePad.GetCapabilities(index_);

            this._thread        = new Thread(this.Listen);

            return;
        }

        public void StartListening()
        {
            this._thread.Start();
            return;
        }

        private void GetNewGamepadState()
        {
            this._newState = new GamepadStateWeighted(GamePad.GetState(this._gamepadId));
            return;
        }

        private void Listen()
        {
            do
            {
                GetNewGamepadState();
                if (this._actualState != this._newState)
                {
                    xConsole.WriteLine("event");
                }
                this._actualState = this._newState;
            } while (true);
            return;
        }
    }
}
