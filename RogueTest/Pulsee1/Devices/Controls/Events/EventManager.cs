using Pulsee1.Devices.Controls.Events.DeviceHandler.Mouse;
using Pulsee1.Devices.Controls.Events.DeviceHandler.Keyboard;
using Pulsee1.Devices.Controls.Events.DeviceHandler.Controller;

namespace Pulsee1.Devices.Controls.Events
{
    class EventManager
    {
        public GameManager _parent;

        private MouseEventHandler meh;
        private KeyboardEventHandler keh;
        private ControllerEventHandler ceh;

        public EventManager(GameManager parent_)
        {
            this._parent = parent_;

            this.meh = new MouseEventHandler();
            this.keh = new KeyboardEventHandler(this);
            this.ceh = new ControllerEventHandler();
            
            //Keyboard event binding (put in KeyboardEventHandler)
            this._parent.dim.window.KeyUp += this.keh.Keh_KeyUp;
            this._parent.dim.window.KeyPress += this.keh.Keh_KeyPress;
            this._parent.dim.window.Keyboard.KeyDown += this.keh.Keh_KeyDown;
        }
    }
}
