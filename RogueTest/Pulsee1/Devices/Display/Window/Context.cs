using System;
using OpenTK;
using OpenTK.Graphics;
using Pulsee1.Graphics;
using System.Threading;
using Pulsee1.Utils.Display;

namespace Pulsee1.Devices.Display.Window
{
    class Context : GameWindow
    {
        private GameManager _parent;
        private Tuple<int, int> _actualResolution;

        public Context(GameManager parent_) 
            : base(854, 480, GraphicsMode.Default, "GUI Window",
                  GameWindowFlags.Default, DisplayDevice.Default, 3, 0,
                  GraphicsContextFlags.ForwardCompatible)
        {
            this._parent = parent_;
            this._actualResolution = Resolutions.allResolution[(int)Resolutions.ResolutionType.StdResolution];
            ChangeIco(new System.Drawing.Icon(@"Pulsee1\KernelContent\Pictures\Icos\build.ico"));

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

        public void ChangeCursorVisible(bool on_)
        {
            CursorVisible = on_;
            return;
        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ChangeResolution(640, Resolutions.HDResolution[640]);
            ChangeVSync(true);
            ChangeCursorVisible(true);

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
            PulseGL.GLDrawScene();
            this.ChangeTitle("GUI Window - " + Math.Round(Math.Ceiling(this.RenderFrequency), 0) + " ~~ " + Width + "x" + Height);
            return;
        }

        protected override void OnResize(EventArgs e)
        {
            PulseGL.GLOnResize();
            return;
        }

        public void Run_More(double clock_)
        {
            this.Run(clock_);
            return;
        }
    }
}
