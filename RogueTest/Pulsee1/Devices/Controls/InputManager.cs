using System;
using System.Collections.Generic;
using OpenTK.Input;
using Pulsee1.Devices.Controls.Binding;

namespace RogueTest.Pulsee1.Devices.Controls
{
    class InputManager
    {
        /// <summary>
        /// Physic engine input manager
        /// </summary>
        private InputManager PInputManager;

        /// <summary>
        /// Render engine input manager
        /// </summary>
        private InputManager RInputManager;

        public InputManager()
        {
            _gamepadButtons = PopulateButtonMaps<GamepadButton>();

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

        /// <summary>
        /// Get the physic input manager instance
        /// </summary>
        /// <returns></returns>
        public InputManager GetPhysic()
        {
            PInputManager = PInputManager ?? new InputManager();
            return PInputManager;
        }

        /// <summary>
        /// Get the render input manager instance
        /// </summary>
        /// <returns></returns>
        public InputManager GetRender()
        {
            RInputManager = RInputManager ?? new InputManager();
            return RInputManager;
        }

        private Dictionary<GamepadButton, bool> _gamepadButtons; // <-- TODO: should be a list of dict (many gamepads)
        //TODO: add triggers + joysticks
        public Dictionary<GamepadButton, bool> GetGamepadButtons()
        {
            return _gamepadButtons;
        }

        private Dictionary<Key, bool> _keyboardKeys;

        public Dictionary<Key, bool> GetKeyboardKeys()
        {
            return _keyboardKeys;
        }


    }
}
