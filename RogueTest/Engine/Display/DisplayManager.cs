using System;
using RogueTest.Engine.Display.Container;
using RogueTest.Engine.Display.Content;

namespace RogueTest.Engine.Display
{
    class DisplayManager
    {
        private GameManager _parent;

        public Window window;
        public Camera camera;

        private double clockTime = 60.0d;

        public DisplayManager(GameManager parent_)
        {
            this.window = new Window();
            this.camera = new Camera();
            this._parent = parent_;
        }

        public void changeWindowName(string title_)
        {
            this.window.changeTitle(title_);
            return;
        }

        public void changeWindowIco(string path_)
        {
            this.window.changeIco(new System.Drawing.Icon(path_));
            return;
        }

        internal void startWindow()
        {
            this.changeWindowName("This's gonna be sooooooo shitty bro");
            this.window.Run_More(this.clockTime, this._parent);
            return;
        }
    }
}
