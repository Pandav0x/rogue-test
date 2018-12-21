using OpenTK;
using OpenTK.Input;
using RogueTest.Pulsee1.Utils.Mathp;
using System;

namespace RogueTest.Pulsee1.Devices.Controls.Peripherals
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

        private float _triggerDZ; //trigger dead zone

        public float TriggerDZ
        {
            get { return _triggerDZ; }
            set { _triggerDZ = value; }
        }


        #endregion

        public GamepadStateWeighted(GamePadState state_, float stickDZ_ = 0.1f, float triggerDZ_ = 0.1f)
        {
            this.StickDZ = stickDZ_;
            this.TriggerDZ = triggerDZ_;
            _gamepadState = state_;
            return;
        }

        public static bool operator ==(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            //TODO: correct the pb when negative number are given -> 
            //  x:-5 to x:6, both < Dz but sums up to be >

            Vector2 aPos = a.GamepadState.ThumbSticks.Left.Yx;
            Vector2 bPos = b.GamepadState.ThumbSticks.Left.Yx;

            bool ans = true;
            ans &= a._gamepadState.Equals(b._gamepadState);
            ans &= Math.Sqrt(Math.Pow(aPos.X, 2) + Math.Pow(aPos.Y, 2)) >= Math.Pow(a.StickDZ, 2);
            ans &= Math.Sqrt(Math.Pow(bPos.X, 2) + Math.Pow(bPos.Y, 2)) >= Math.Pow(b.StickDZ, 2);
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
