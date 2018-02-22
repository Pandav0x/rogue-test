using System;
using Pulsee1.Devices.Display.Window;
using Pulsee1.Devices.Display.VirtualDevice;

namespace Pulsee1.Devices.Display
{
    class DisplayManager
    {
        private GameManager _parent;

        public Context window;
        public Camera camera;

        private double clockTime = 60.0d;

        public DisplayManager(GameManager parent_)
        {
            this.window = new Context(this._parent);
            this.camera = new Camera();
            this._parent = parent_;
        }

        public void ChangeWindowName(string title_)
        {
            this.window.ChangeTitle(title_);
            return;
        }

        public void ChangeWindowIco(string path_)
        {
            this.window.ChangeIco(new System.Drawing.Icon(path_));
            return;
        }

        internal void StartWindow()
        {
            this.ChangeWindowName("GUI Window");
            this.window.Run_More(this.clockTime);
            return;
        }
    }
}
