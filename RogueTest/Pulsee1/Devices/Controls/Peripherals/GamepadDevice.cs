using OpenTK.Input;
using System.Threading;
using Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.Gamepad;
using RogueTest.Pulsee1.Devices.Display.Window;
using Pulsee1.Devices.Controls.Events.DeviceHandler.Gamepad;

namespace Pulsee1.Devices.Controls.Peripherals
{
    class GamepadDevice
    {
        private Ple_GameWindow _context;
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
            this._gamepadCapa   = GamePad.GetCapabilities(index_);
            this._actualState   = new GamepadStateWeighted(GamePad.GetState(this._gamepadId));
            this._newState      = this._actualState;

            this._thread        = new Thread(this.Listen);

            return;
        }

        public void StartListening(Ple_GameWindow context)
        {
            this._context = context;
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
            GamepadEventHandler geh = new GamepadEventHandler();
            bool buttonPressed = false;

            do
            {
                GetNewGamepadState();
                if (this._actualState != this._newState)
                {
                    GamepadEventArgs buttonArgs   = new GamepadEventArgs();

                    //TODO: fix gamepad args when events raise
                    
                    if (GamePad.GetState(this._gamepadId).Buttons.IsAnyButtonPressed && !buttonPressed)
                    {
                        this._context.OnButtonDown(buttonArgs);
                        buttonPressed = true;
                    }
                    if (!GamePad.GetState(this._gamepadId).Buttons.IsAnyButtonPressed && buttonPressed)
                    {
                        this._context.OnButtonUp(buttonArgs);
                        buttonPressed = false;
                    }
                }
                this._actualState = this._newState;
            } while (true);
            return;
        }
    }
}
