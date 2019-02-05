using OpenTK;
using OpenTK.Input;
using RogueTest.Pulsee1.Utils.Mathp;
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


        public GamePadState gamepadState {get; set;}

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

        public static bool operator ==(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            GamePadState aState = a.GamepadState;
            GamePadState bState = b.GamepadState;

            Vector2 aPosLeft = a.GamepadState.ThumbSticks.Left.Yx;
            Vector2 aPosRight = a.GamepadState.ThumbSticks.Right.Yx;

            bool ans = aState.DPad == bState.DPad;
            ans &= aState.Buttons == bState.Buttons;
            ans &= aState.Triggers.Left == bState.Triggers.Left;
            ans &= aState.Triggers.Right == bState.Triggers.Right;
            ans &= Math.Sqrt(Math.Pow(aPosLeft.X, 2) + Math.Pow(aPosLeft.Y, 2)) < a.StickDZ;
            ans &= Math.Sqrt(Math.Pow(aPosRight.X, 2) + Math.Pow(aPosRight.Y, 2)) < a.StickDZ;

            return ans;
        }

        public static bool operator !=(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            return !(a==b);
        }

        private static bool TriggersMoveWeighted(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            return false;
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
