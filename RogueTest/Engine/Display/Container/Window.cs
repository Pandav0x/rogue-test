using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES20;

namespace RogueTest.Engine.Display.Container
{
    class Window : GameWindow
    {
        private GameManager parent;

        public void changeResolution(int width_, int height_)
        {
            Width = width_;
            Height = height_;
            return;
        }

        public void changeTitle(string title_)
        {
            Title = title_;
            return;
        }

        public void changeIco(System.Drawing.Icon icon_)
        {
            Icon = icon_ ;
            return;
        }

        public void changeVSync(bool on_)
        {
            VSync = (!on_)? VSyncMode.Off : VSyncMode.On;
            return;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color4.Black);

            changeResolution(854, 480);
            changeVSync(false);

            WindowBorder = WindowBorder.Fixed;

            return;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //display tiles here 

            SwapBuffers();

            return;
        }

        public void Run_More(double clock_, GameManager game_)
        {
            this.parent = game_;
            this.Run(clock_);
            return;
        }
    }
}
