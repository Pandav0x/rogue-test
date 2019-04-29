using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using Pulsee1.Devices.Controls.Binding;

namespace Pulsee1.Devices.Controls.Peripherals
{
    class GamepadStateWeighted
    {
        #region fields

        private GamePadState _gamepadState;

        public GamePadState GamepadState
        {
            get { return _gamepadState; }
            set { _gamepadState = value; }
        }

        public GamePadThumbSticks ThumbSticks;
        public GamePadTriggers Triggers;
        public GamePadButtons Buttons;
        public GamePadDPad DPad;

        private Dictionary<GamepadButton, bool> buttonState = new Dictionary<GamepadButton, bool>();

        public bool IsConnected;
        public int PacketNumber;

        private float _stickDZ;//stick dead zone

        public float StickDZ
        {
            get { return _stickDZ; }
            set
            {
                if(value < 1.0f || value > -1.0f)
                    _stickDZ = value;
            }
        }

        #endregion

        #region ctor
        public GamepadStateWeighted(GamePadState state_, float stickDZ_ = 0.1f)
        {
            this.StickDZ = stickDZ_;
            this._gamepadState = state_;

            this.IsConnected = state_.IsConnected;
            this.PacketNumber = state_.PacketNumber;
        }

        public GamepadStateWeighted(GamePadState state_, GamepadDevice caller_): this(state_)
        {
            foreach (GamepadButton btn in caller_._gamepadButtonState.Keys)
                this.buttonState.Add(btn, caller_._gamepadButtonState[btn]);
        }

        public GamepadStateWeighted(GamePadState state_, GamepadStateWeighted gm): this(state_)
        {
            /*if (gm.Equals(null))
            {
                foreach (GamepadButton btn in Enum.GetValues(typeof(GamepadButton)))
                    this.buttonState.Add(btn, false);
            }
            else
            {
                foreach (GamepadButton btn in Enum.GetValues(typeof(GamepadButton)))
                    this.buttonState.Add(btn, (gm.buttonState.ContainsKey(btn))? gm.buttonState[btn] : false);
            }*/
        }

        public GamepadStateWeighted(GamepadStateWeighted state_)
        {
            this._gamepadState = state_._gamepadState;
        }
        #endregion

        #region Buttons
        public static List<GamepadButton> GetButtonsChanges(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            List<GamepadButton> diff = new List<GamepadButton>();

            foreach (GamepadButton btn in Enum.GetValues(typeof(GamepadButton)))
            {
                //Utils.Display.xConsole.WriteLine(btn.ToString().Substring(0,1) + "\t\ta: " + aButtonsState[btn].ToString() + "\tb: " + bButtonsState[btn].ToString()); //TODEL
                if (a.buttonState[btn] != b.buttonState[btn])
                    diff.Add(btn);
                else
                    diff.Remove(btn);
            }
            return diff;
        }
        #endregion

        #region Joysticks
        public static bool LeftStickStatesEquals(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            Vector2 aPosLeft = a.GamepadState.ThumbSticks.Left.Yx;
            return Math.Sqrt(Math.Pow(aPosLeft.X, 2) + Math.Pow(aPosLeft.Y, 2)) < a.StickDZ; ;
        }

        public static bool RightStickStatesEquals(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            Vector2 aPosRight = a.GamepadState.ThumbSticks.Right.Yx;
            return Math.Sqrt(Math.Pow(aPosRight.X, 2) + Math.Pow(aPosRight.Y, 2)) < a.StickDZ;
        }

        public static bool StickStatesEquals(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            return LeftStickStatesEquals(a, b) && RightStickStatesEquals(a, b);
        }
        #endregion

        #region Triggers
        public static bool LeftTriggerStatesEquals(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            return a.GamepadState.Triggers.Left == b.GamepadState.Triggers.Left; ;
        }

        public static bool RightTriggerStatesEquals(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            return a.GamepadState.Triggers.Right == b.GamepadState.Triggers.Right;
        }

        public static bool TriggerStatesEquals(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            return LeftTriggerStatesEquals(a, b) && RightTriggerStatesEquals(a, b);
        }
        #endregion

        #region operator definitions
        public static bool operator ==(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            bool ans = a.GamepadState.DPad == b.GamepadState.DPad;
            ans &= a.GamepadState.Buttons == b.GamepadState.Buttons;
            ans &= TriggerStatesEquals(a, b);
            ans &= StickStatesEquals(a, b);
            return ans;
        }

        public static bool operator !=(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            return !(a==b);
        }

        public override bool Equals(dynamic b)
        {
            if (b == null)
                return false;
            else
                return this == b;
        }

        /// <summary>
        /// This works as the = operator, avoiding some attributes to be asigned
        /// </summary>
        /// <param name="b"></param>
        public void Assign(GamepadStateWeighted b)
        {
            this.Buttons = b.Buttons;
            this.buttonState = b.buttonState;
            this.DPad = b.DPad;
            this.IsConnected = b.IsConnected;
            this.PacketNumber = b.PacketNumber;
            this.ThumbSticks = b.ThumbSticks;
            this.Triggers = b.Triggers;
            return;
        }
        #endregion

        public override string ToString()
        {
            return this._gamepadState.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
