using OpenTK.Input;
using Pulsee1.Utils.Display;
using System;
using System.Collections.Generic;
using System.Threading;
using RogueTest.Pulsee1.Devices.Display.Window;
using Pulsee1.Controls.Devices.Buttons;

namespace Pulsee1.Controls.Gamepad
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
        /// Represents the state of the buttons mapped on the gamepad
        /// </summary>
        public Dictionary<GamepadButton, bool> _gamepadButtonState = new Dictionary<GamepadButton, bool>();

        public GamepadDevice()
        {
            _thread = new Thread(Listen);
            return;
        }

        public GamepadDevice(int index_)
        {
            _gamepadId     = index_;
            _gamepadName   = GamePad.GetName(index_);
            _gamepadCapa   = GamePad.GetCapabilities(index_);
            _actualState   = new GamepadStateWeighted(GamePad.GetState(_gamepadId));
            _newState      = _actualState;

            foreach (GamepadButton btn in Enum.GetValues(typeof(GamepadButton)))
                _gamepadButtonState.Add(btn, false);

            _thread        = new Thread(Listen);
            return;
        }

        public void StartListening(Ple_GameWindow context)
        {
            _context = context;
            _thread.Start();
            return;
        }

        private void GetNewGamepadState()
        {
            _newState = new GamepadStateWeighted(GamePad.GetState(_gamepadId));
            return;
        }

        public void Refresh ()
        {
            Listen();
        }

        private void Listen()
        {
            do
            {
                GetNewGamepadState();
                if (_actualState != _newState)
                {
                    foreach (GamepadButton btn in RetrieveButton(OpenTK.Input.ButtonState.Pressed))
                    {
                        if (!_gamepadButtonState[btn])
                        {
                            _context.OnButtonDown(new GamepadEventArgs { Button = btn });
                            _gamepadButtonState[btn] = true;
                        }
                    }
                    foreach (GamepadButton btn in RetrieveButton(OpenTK.Input.ButtonState.Released))
                    {
                        if (_gamepadButtonState[btn])
                        {
                            _context.OnButtonUp(new GamepadEventArgs { Button = btn });
                            _gamepadButtonState[btn] = false;
                        }
                    }
                }

                if (!GamepadStateWeighted.LeftStickStatesEquals(_actualState, _newState))
                {
                    _context.OnLeftStickMove(new GamepadEventArgs());
                }

                if (!GamepadStateWeighted.RightStickStatesEquals(_actualState, _newState))
                {
                    _context.OnRightStickMove(new GamepadEventArgs());
                }

                if (!GamepadStateWeighted.TriggerStatesEquals(_actualState, _newState))
                {
                    xConsole.WriteLine(_newState.Triggers.ToString(), MessageType.Error);
                }

                _actualState =  _newState;

                Thread.Sleep(100); //TODO: scale this by the FPS setted in the Ple_GameWindow object
            } while (true);
        }

        private List<GamepadButton> RetrieveButton(OpenTK.Input.ButtonState state)
        {
            List<GamepadButton> ans = new List<GamepadButton>();

            if (_newState.GamepadState.Buttons.A == state)
                ans.Add(GamepadButton.A);
            if (_newState.GamepadState.Buttons.B == state)
                ans.Add(GamepadButton.B);
            if (_newState.GamepadState.Buttons.X == state)
                ans.Add(GamepadButton.X);
            if (_newState.GamepadState.Buttons.Y == state)
                ans.Add(GamepadButton.Y);
            //Shoulder buttons
            if (_newState.GamepadState.Buttons.LeftShoulder == state)
                ans.Add(GamepadButton.LB);
            if (_newState.GamepadState.Buttons.RightShoulder == state)
                ans.Add(GamepadButton.RB);
            //Start/select/xbox button
            if (_newState.GamepadState.Buttons.Start == state)
                ans.Add(GamepadButton.Start);
            if (_newState.GamepadState.Buttons.Back == state)
                ans.Add(GamepadButton.Back);
            if (_newState.GamepadState.Buttons.BigButton == state)
                ans.Add(GamepadButton.BigButton);
            //Dpad
            if (_newState.GamepadState.DPad.IsUp)
                ans.Add(GamepadButton.DPadUp);
            if (_newState.GamepadState.DPad.IsDown)
                ans.Add(GamepadButton.DPadDown);
            if (_newState.GamepadState.DPad.IsLeft)
                ans.Add(GamepadButton.DPadLeft);
            if (_newState.GamepadState.DPad.IsRight)
                ans.Add(GamepadButton.DPadRight);
            //Joysticks buttons 
            if (_newState.GamepadState.Buttons.LeftStick == state)
                ans.Add(GamepadButton.JoystickLeft);
            if (_newState.GamepadState.Buttons.RightStick == state)
                ans.Add(GamepadButton.JoystickRight);
            return ans;
        }
    }
}
