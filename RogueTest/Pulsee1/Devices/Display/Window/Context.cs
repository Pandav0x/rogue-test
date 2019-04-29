using System;
using OpenTK;
using OpenTK.Graphics;
using Pulsee1.Graphics;
using RogueTest.Pulsee1.Devices.Display.Window;

namespace Pulsee1.Devices.Display.Window
{
    class Context : Ple_GameWindow
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

        public void ChangeResizable(bool on_)
        {

            return;
        }
        #endregion

        #region Window Events

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
            // TODO: physic input manager update with pressed buttons (inputMgrPhysic)
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // TODO: render input manager update with pressed buttons (inputMgrRender)
            this.SwapBuffers();
            PulseGL.GLDrawScene();

            this.ChangeTitle("GUI Window - " + Math.Round(Math.Ceiling(this.RenderFrequency), 0) + " ~~ " + Width + "x" + Height);
            return;
        }

        protected override void OnResize(EventArgs e)
        {
            #region Trying to maintain the ratio (but whatever)
            /**
             * Trying to maintain the size ratio when the window is resized
             * 
             * WHAT IF JUST REMOVE THAT FEATURE ? JUST MAKE IT NON RESIZABLE AND ALL WILL BE FINE
             * jesus !
             * 
             * */

            /*
            if (this.Width > this.oldWidth || this.Width < this.oldWidth)
            {
                this.Height = (int)Math.Ceiling((double) this.Width * 
                    (this.Height / this._actualResolution.Item1));
            }
                
            if (this.Height > this.oldHeight)
            {
                this.Width = (int)Math.Floor((double) this.Height *
                    (this._actualResolution.Item1 / this._actualResolution.Item2));
            }*/
            #endregion

            PulseGL.GLOnResize();
            return;
        }

        protected override void OnDisposed(EventArgs e)
        {
            Console.ReadLine();
            base.OnDisposed(e);
        }

        #endregion


        public void Run_More(double clock_)
        {
            this.Run(clock_);
            return;
        }

    }
}
