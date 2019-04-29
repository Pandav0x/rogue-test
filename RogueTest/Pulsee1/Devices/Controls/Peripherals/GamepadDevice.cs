using OpenTK.Input;
using System.Threading;
using Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.Gamepad;
using RogueTest.Pulsee1.Devices.Display.Window;
using Pulsee1.Devices.Controls.Binding;
using System.Collections.Generic;
using System;

namespace Pulsee1.Devices.Controls.Peripherals
{
    class GamepadDevice
    {
        private Ple_GameWindow _context;
        private Thread _thread;
        private readonly int _gamepadId;
        private readonly string _gamepadName;
        private GamepadStateWeighted _actualState, _newState;
        private GamePadCapabilities _gamepadCapa;

        /// <summary>
        /// Represents the state (pressed or not pressed) of all the buttons mapped on the gamepad
        /// </summary>
        public Dictionary<GamepadButton, bool> _gamepadButtonState = new Dictionary<GamepadButton, bool>();

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
            this._actualState   = new GamepadStateWeighted(GamePad.GetState(this._gamepadId), this);
            this._newState      = this._actualState;

            foreach (GamepadButton btn in Enum.GetValues(typeof(GamepadButton)))
                this._gamepadButtonState.Add(btn, false);

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
            this._newState = new GamepadStateWeighted(GamePad.GetState(this._gamepadId), this._actualState);
            return;
        }

        private void Listen()
        {
            do
            {
                GetNewGamepadState();
                if (this._actualState != this._newState)
                {
                    foreach (GamepadButton btn in RetrieveButton(ButtonState.Pressed))
                    {
                        if (!_gamepadButtonState[btn])
                        {
                            _context.OnButtonDown(new GamepadEventArgs { Button = btn });
                            _gamepadButtonState[btn] = true;
                        }
                    }
                    foreach (GamepadButton btn in RetrieveButton(ButtonState.Released))
                    {
                        if (_gamepadButtonState[btn])
                        {
                            _context.OnButtonUp(new GamepadEventArgs { Button = btn });
                            _gamepadButtonState[btn] = false;
                        }
                    }
                }

                if (!GamepadStateWeighted.LeftStickStatesEquals(this._actualState, this._newState))
                {
                    this._context.OnLeftStickMove(new GamepadEventArgs());
                }

                if (!GamepadStateWeighted.RightStickStatesEquals(this._actualState, this._newState))
                {
                    this._context.OnRightStickMove(new GamepadEventArgs());
                }

                if (!GamepadStateWeighted.TriggerStatesEquals(this._actualState, this._newState))
                {
                    Utils.Display.xConsole.WriteLine(this._actualState.Triggers.Left.CompareTo(this._newState.Triggers.Left).ToString(), Pulsee1.Utils.Display.MessageType.Error);
                }

                this._actualState =  this._newState;
                //TODO : thread sleep pour pas casser CPU (genre a 120 ticks/s)
                Thread.Sleep(100);
            } while (true);
            return;
        }

        private List<GamepadButton> RetrieveButton(ButtonState state)
        {
            List<GamepadButton> ans = new List<GamepadButton>();

            if (this._newState.GamepadState.Buttons.A == state)
                ans.Add(GamepadButton.A);
            if (this._newState.GamepadState.Buttons.B == state)
                ans.Add(GamepadButton.B);
            if (this._newState.GamepadState.Buttons.X == state)
                ans.Add(GamepadButton.X);
            if (this._newState.GamepadState.Buttons.Y == state)
                ans.Add(GamepadButton.Y);
            //Shoulder buttons
            if (this._newState.GamepadState.Buttons.LeftShoulder == state)
                ans.Add(GamepadButton.LB);
            if (this._newState.GamepadState.Buttons.RightShoulder == state)
                ans.Add(GamepadButton.RB);
            //Start/select/xbox button
            if (this._newState.GamepadState.Buttons.Start == state)
                ans.Add(GamepadButton.Start);
            if (this._newState.GamepadState.Buttons.Back == state)
                ans.Add(GamepadButton.Back);
            if (this._newState.GamepadState.Buttons.BigButton == state)
                ans.Add(GamepadButton.BigButton);
            //Dpad
            if (this._newState.GamepadState.DPad.IsUp)
                ans.Add(GamepadButton.DPadUp);
            if (this._newState.GamepadState.DPad.IsDown)
                ans.Add(GamepadButton.DPadDown);
            if (this._newState.GamepadState.DPad.IsLeft)
                ans.Add(GamepadButton.DPadLeft);
            if (this._newState.GamepadState.DPad.IsRight)
                ans.Add(GamepadButton.DPadRight);
            //Joysticks buttons 
            if (this._newState.GamepadState.Buttons.LeftStick == state)
                ans.Add(GamepadButton.JoystickLeft);
            if (this._newState.GamepadState.Buttons.RightStick == state)
                ans.Add(GamepadButton.JoystickRight);
            return ans;
        }
    }
}
