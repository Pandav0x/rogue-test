using OpenTK;
using OpenTK.Input;
using System;

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

        public GamepadStateWeighted(GamePadState state_, float stickDZ_ = 0.1f)
        {
            this.StickDZ = stickDZ_;
            _gamepadState = state_;
            return;
        }

        public GamepadStateWeighted(GamepadStateWeighted state_)
        {
            this._gamepadState = state_._gamepadState;
            return;
        }


        /**
         * Joysticks
         */
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

        /**
         * Triggers
         */
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


        //operator definitions
        public static bool operator ==(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            bool ans = a.GamepadState.DPad == b.GamepadState.DPad;
            ans &= a.GamepadState.Buttons == b.GamepadState.Buttons;
            ans &= GamepadStateWeighted.TriggerStatesEquals(a, b);
            ans &= GamepadStateWeighted.StickStatesEquals(a, b);
            return ans;
        }

        public static bool operator !=(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            return !(a==b);
        }

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
