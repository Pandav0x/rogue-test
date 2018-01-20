using System;
using OpenTK;
using OpenTK.Graphics;

namespace Pulsee1.Display.GUI
{
    class Window : GameWindow
    {
        private GameManager _parent;

        public Window(GameManager parent_) : base(854, 480, GraphicsMode.Default, "GUI Window", GameWindowFlags.Default, DisplayDevice.Default, 3, 0, GraphicsContextFlags.ForwardCompatible)
        {
            this._parent = parent_;

            return;
        }

#region Changing Stuff
        public void ChangeResolution(int width_, int height_)
        {
            Width = width_;
            Height = height_;
            return;
        }

        public void ChangeTitle(string title_)
        {
            Title = title_;
            return;
        }

        public void ChangeIco(System.Drawing.Icon icon_)
        {
            Icon = icon_ ;
            return;
        }

        public void ChangeVSync(bool on_)
        {
            VSync = (!on_)? VSyncMode.Off : VSyncMode.On;
            return;
        }
#endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ChangeResolution(854, 480);
            ChangeVSync(false);

            WindowBorder = WindowBorder.Resizable;

            return;
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            // this is called every frame, put game logic here
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            

            this.SwapBuffers();

            return;
        }

        protected override void OnResize(EventArgs e)
        {
            return;
        }

        public void Run_More(double clock_)
        {
            this.Run(clock_);
            return;
        }
    }
}
