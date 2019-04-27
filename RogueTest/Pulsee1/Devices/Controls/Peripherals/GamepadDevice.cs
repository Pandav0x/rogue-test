using System;
using OpenTK.Input;
using System.Threading;
using Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.Gamepad;
using RogueTest.Pulsee1.Devices.Display.Window;
using System.Collections.Generic;
using Pulsee1.Devices.Controls.Binding;

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
                    //TODO: remove this new statement (maybe in the first condition)
                    GamepadEventArgs buttonArgs = new GamepadEventArgs {
                        Button = RetrievePressedButton()
                    };

                    //TODO: fix <= cannot get args when pressing one button while another one is pressed

                    if (GamePad.GetState(this._gamepadId).Buttons.IsAnyButtonPressed)
                    {
                        this._newState.buttonState[buttonArgs.Button] = true;
                        this._context.OnButtonDown(buttonArgs);
                    }
                    
                    //TODO:
                    if (!GamePad.GetState(this._gamepadId).Buttons.IsAnyButtonPressed)
                    {
                        Utils.Display.xConsole.WriteLine("List length - " + GamepadStateWeighted.GetButtonsChanges(this._actualState, this._newState).Count.ToString());
                        foreach (GamepadButton btn in GamepadStateWeighted.GetButtonsChanges(this._actualState, this._newState))
                        {
                            this._context.OnButtonUp(new GamepadEventArgs { Button = btn });
                            //Pulsee1.Utils.Display.xConsole.WriteLine(this._newState.buttonState[btn].ToString() + "YEA YEA YEAY !!");
                            this._newState.buttonState[btn] = false;
                        }
                    }

                    if (!GamepadStateWeighted.LeftStickStatesEquals(this._actualState, this._newState))
                    {
                        this._context.OnLeftStickMove(buttonArgs);
                    }

                    if (!GamepadStateWeighted.RightStickStatesEquals(this._actualState, this._newState))
                    {
                        this._context.OnRightStickMove(buttonArgs);
                    }

                    if (!GamepadStateWeighted.TriggerStatesEquals(this._actualState, this._newState))
                    {
                        //TODO: fire good event + good evnts args for the triggers
                        Utils.Display.xConsole.WriteLine(this._actualState.Triggers.Left.CompareTo(this._newState.Triggers.Left).ToString(), Pulsee1.Utils.Display.MessageType.Error);
                    }
                }
                this._actualState =  this._newState;
            } while (true);
            return;
        }

        private GamepadButton RetrievePressedButton()
        {
            GamepadButton ans = 0;

            if (this._newState.GamepadState.Buttons.A == ButtonState.Pressed)
                ans = GamepadButton.A;
            if (this._newState.GamepadState.Buttons.B == ButtonState.Pressed)
                ans = GamepadButton.B;
            if (this._newState.GamepadState.Buttons.X == ButtonState.Pressed)
                ans = GamepadButton.X;
            if (this._newState.GamepadState.Buttons.Y == ButtonState.Pressed)
                ans = GamepadButton.Y;
            //Shoulder buttons
            if (this._newState.GamepadState.Buttons.LeftShoulder == ButtonState.Pressed)
                ans = GamepadButton.LB;
            if (this._newState.GamepadState.Buttons.RightShoulder == ButtonState.Pressed)
                ans = GamepadButton.RB;
            //Start/select/xbox button
            if (this._newState.GamepadState.Buttons.Start == ButtonState.Pressed)
                ans = GamepadButton.Start;
            if (this._newState.GamepadState.Buttons.Back == ButtonState.Pressed)
                ans = GamepadButton.Back;
            if (this._newState.GamepadState.Buttons.BigButton == ButtonState.Pressed)
                ans = GamepadButton.BigButton;
            //Dpad
            if (this._newState.GamepadState.DPad.IsUp)
                ans = GamepadButton.DPadUp;
            if (this._newState.GamepadState.DPad.IsDown)
                ans = GamepadButton.DPadDown;
            if (this._newState.GamepadState.DPad.IsLeft)
                ans = GamepadButton.DPadLeft;
            if (this._newState.GamepadState.DPad.IsRight)
                ans = GamepadButton.DPadRight;
            //Joysticks buttons 
            if (this._newState.GamepadState.Buttons.LeftStick == ButtonState.Pressed)
                ans = GamepadButton.JoystickLeft;
            if (this._newState.GamepadState.Buttons.RightStick == ButtonState.Pressed)
                ans = GamepadButton.JoystickRight;

            return ans;
        }
    }
}
