using OpenTK.Input;
using Pulsee1.Utils.Display;
using System.Threading;

namespace RogueTest.Pulsee1.Devices.Controls.Peripherals
{
    class GamepadDevice
    {
        private Thread _thread;
        private int _gamepadID;
        private string _gamepadName;
        private GamepadStateWeighted _actualState, _newState;
        private GamePadCapabilities _gamepadCapa;

        public GamepadDevice()
        {
            _thread = new Thread(Listen);
            return;
        }

        public GamepadDevice(int index_, string name_, GamePadState state_, GamePadCapabilities capas_)
        {
            this._gamepadID = index_;
            this._gamepadName = name_;
            this._actualState = _newState =  new GamepadStateWeighted(state_);
            this._gamepadCapa = capas_;

            _thread = new Thread(Listen);

            return;
        }

        public void StartListening()
        {
            _thread.Start();
            return;
        }

        private void GetNewGamepadState()
        {
            _newState = new GamepadStateWeighted(GamePad.GetState(this._gamepadID));

            return;
        }

        private void Listen()
        {
            while (true)
            {
                GetNewGamepadState();
                xConsole.WriteLine(GamepadStateWeighted.SticksMoveWeighted(_actualState, _newState).ToString());
                if (_actualState == _newState)
                {
                    xConsole.WriteLine(this._gamepadName + " - event");
                    _actualState = _newState;
                }
            }
            return;
        }
    }
}
