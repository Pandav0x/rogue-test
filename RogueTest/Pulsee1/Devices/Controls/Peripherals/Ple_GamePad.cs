﻿using System;
using OpenTK.Input;
using Pulsee1.Devices.Controls.Binding;
using Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.GamePad;
using Pulsee1.Utils.Display;

namespace Pulsee1.Devices.Controls.Peripherals
{
    class Ple_GamePad : IInputDevice
    {
        private bool[] _buttons = new bool[Enum.GetValues(typeof(GamePadButtons)).Length];
        private string _description;
        private int _numButtons;
        private IntPtr _devID;
        private bool _repeat;
        private GamePadButtonEventArgs bArgs = new GamePadButtonEventArgs();

        #region contructors

        internal Ple_GamePad() { return; }

        #endregion

        public bool this[GamePadButton button]
        {
            get { return _buttons[(int)button]; }
            internal set
            {
                if (_buttons[(int)button] != value)
                {
                    _buttons[(int)button] = value;

                    if (value && ButtonDown != null)
                    {
                        bArgs.Button = button;
                        ButtonDown(this, bArgs);
                    }
                    else if (!value && ButtonUp != null)
                    {
                        bArgs.Button = button;
                        ButtonUp(this, bArgs);
                    }
                }
            }
        }

        public int NumberOfButtons
        {
            get { return _numButtons; }
            internal set { _numButtons = value; }
        }

        public IntPtr DeviceID
        {
            get { return _devID; }
            internal set { _devID = value; }
        }
        
        public event EventHandler<GamePadButtonEventArgs> ButtonDown;
        public event EventHandler<GamePadButtonEventArgs> ButtonUp;

        #region IInputDevice Members

        public string Description
        {
            get { return _description; }
            internal set { _description = value; }
        }

        public InputDeviceType DeviceType
        {
            get { return InputDeviceType.Hid; }
        }

        #endregion

        internal void ClearButtons()
        {
            for (int i = 0; i < _buttons.Length; i++)
                if (this[(GamePadButton)i])
                    this[(GamePadButton)i] = false;
            return;
        }

    }
}
