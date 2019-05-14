using OpenTK;
using OpenTK.Input;
using Pulsee1.Controls.Devices.Buttons;
using System;
using System.Collections.Generic;

namespace Pulsee1.Controls.Gamepad
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
            StickDZ = stickDZ_;
            _gamepadState = state_;

            Triggers = state_.Triggers;
            ThumbSticks = state_.ThumbSticks;
            Buttons = state_.Buttons;
            DPad = state_.DPad;

            IsConnected = state_.IsConnected;
            PacketNumber = state_.PacketNumber;
        }

        public GamepadStateWeighted(GamepadStateWeighted state_)
        {
            _gamepadState = state_._gamepadState;
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
        #endregion

        public override string ToString()
        {
            return _gamepadState.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
