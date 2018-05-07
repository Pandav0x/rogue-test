using Pulsee1.Devices.Controls.Events.DeviceHandler.Mouse;
using Pulsee1.Devices.Controls.Events.DeviceHandler.Keyboard;
using Pulsee1.Devices.Controls.Events.DeviceHandler.GamePad;
using Pulsee1.Devices.Controls.Peripherals;
using OpenTK.Input;

namespace Pulsee1.Devices.Controls.Events
{
    class EventManager
    {
        public GameManager _parent;

        private MouseEventHandler meh;
        private KeyboardEventHandler keh;
        private GamePadEventHandler geh;

        public EventManager(GameManager parent_)
        {
            this._parent = parent_;

            this.meh = new MouseEventHandler(this);
            this.keh = new KeyboardEventHandler(this);
            this.geh = new GamePadEventHandler(this);
            
            //Keyboard event binding (put in KeyboardEventHandler)
            this._parent.dim.window.KeyUp += this.keh.Keh_KeyUp;
            this._parent.dim.window.KeyPress += this.keh.Keh_KeyPress;
            this._parent.dim.window.Keyboard.KeyDown += this.keh.Keh_KeyDown;

            this._parent.dim.window.MouseEnter += this.meh.Meh_MouseEnter;
            this._parent.dim.window.MouseLeave += this.meh.Meh_MouseLeave;
            this._parent.dim.window.MouseMove += this.meh.Meh_MouseMove;
            this._parent.dim.window.MouseDown += this.meh.Meh_MouseDown;
            this._parent.dim.window.MouseUp += this.meh.Meh_MouseUp;
            this._parent.dim.window.MouseWheel += this.meh.Meh_MouseWheel;

            GamePadState a = GamePad.GetState(0);

            //+= this.geh.Geh_ButtonDown;
            this._parent.dim.window.Joysticks[1].ButtonDown += this.geh.Geh_ButtonDown;
            this._parent.dim.window.Joysticks[2].ButtonDown += this.geh.Geh_ButtonDown;
            this._parent.dim.window.Joysticks[3].ButtonDown += this.geh.Geh_ButtonDown;

            //this._parent.dim.window.


            //TODEL
            Ple_GamePad.tmp_Main();
        }
    }
}
