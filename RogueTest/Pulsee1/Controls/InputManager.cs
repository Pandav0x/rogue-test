using System;
using System.Collections.Generic;
using OpenTK.Input;
using Pulsee1.Controls.Devices.Buttons;

namespace Pulsee1.Devices.Controls
{
    class InputManager
    {
        /// <summary>
        /// Physic engine input manager
        /// </summary>
        private InputManager _instance;

        public InputManager GetInstance ()
        {
            _instance = _instance ?? new InputManager();
            return _instance;
        }

        public InputManager()
        {
            /* TODO: foreach gamepad detected
            _gamepadButtons = PopulateButtonMaps<GamepadButton>();
            */
        }

        private Dictionary<T, bool> PopulateButtonMaps<T>()
        {
            Dictionary<T, bool> map = new Dictionary<T, bool>();
            foreach(T key in Enum.GetValues(typeof(T)))
            {
                map.Add(key, false);
            }
            return map;
        }

        private List<Dictionary<GamepadButton, bool>> _gamepadButtons; // <-- TODO: should be a list of dict (many gamepads)
        private Dictionary<Key ,bool> _keyboardKeys;

        public List<Dictionary<GamepadButton, bool>> GetGamepadButtons()
        {
            return _gamepadButtons;
        }
    }
}
