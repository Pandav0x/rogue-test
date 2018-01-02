using System;
using OpenTK.Input;
using OpenTK;
using RogueTest.Engine.Controls.Events.DeviceEventHandler.Mouse;
using RogueTest.Engine.Controls.Events.DeviceEventHandler.Keyboard;
using RogueTest.Engine.Controls.Events.DeviceEventHandler.Controller;
using RogueTest.Engine.Binding.Controls;

namespace RogueTest.Engine.Controls.Events
{
    class EventManager
    {
        private GameManager _parent;

        private MouseEventHandler meh = new MouseEventHandler();
        private KeyboardEventHandler keh = new KeyboardEventHandler();
        private ControllerEventHandler ceh = new ControllerEventHandler();

        public EventManager(GameManager parent_)
        {
            this._parent = parent_;
            
            //Keyboard event binding (put in KeyboardEventHandler)
            this._parent.dm.window.KeyUp += this.keh.Keh_KeyUp;
            this._parent.dm.window.KeyPress += this.keh.Keh_KeyPress;
            this._parent.dm.window.Keyboard.KeyDown += this.keh.Keh_KeyDown;
        }
    }
}
