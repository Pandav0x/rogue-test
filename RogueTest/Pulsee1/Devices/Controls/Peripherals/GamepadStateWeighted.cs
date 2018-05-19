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

        public GamePadState GetGamepadState
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

        private Vector2 _stickDZ;//stick dead zone

        public Vector2 StickDZ
        {
            get { return _stickDZ; }
            set { _stickDZ = value; }
        }

        private float _triggerDZ; //trigger dead zone

        public float TriggerDZ
        {
            get { return _triggerDZ; }
            set { _triggerDZ = value; }
        }


        #endregion

        public GamepadStateWeighted(GamePadState state_)
        {
            return;
        }

        public GamepadStateWeighted(GamePadState state_, float stickDZ_ = 0.1f, float triggerDZ_ = 0.1f)
        {
            this.StickDZ = new Vector2(stickDZ_, stickDZ_);
            this.TriggerDZ = triggerDZ_;
            _gamepadState = state_;
            return;
        }

        public static bool operator ==(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            return SticksMoveWeighted(a, b) || TriggersMoveWeighted(a, b);
        }

        public static bool operator !=(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            return !(SticksMoveWeighted(a, b) || TriggersMoveWeighted(a, b));
        }

        /// <summary>
        /// Check if the joystick has moved more than the DZ value
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool SticksMoveWeighted(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            Vector2 aLeft = a.gamepadState.ThumbSticks.Left; 
            Vector2 aRight = a.gamepadState.ThumbSticks.Left;
            Vector2 bLeft = b.gamepadState.ThumbSticks.Left; 
            Vector2 bRight = b.gamepadState.ThumbSticks.Left;

            bool ans = false;

            if (xMath.Vector2GreaterThan(xMath.Abs(aLeft - bLeft), a.StickDZ))
                ans = true;

            if (xMath.Vector2GreaterThan(xMath.Abs(aRight - bRight), a.StickDZ))
                ans = true;

            //Here some maths to get if the moves where in the DZ or not

            return ans;
        }

        private static bool TriggersMoveWeighted(GamepadStateWeighted a, GamepadStateWeighted b)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
