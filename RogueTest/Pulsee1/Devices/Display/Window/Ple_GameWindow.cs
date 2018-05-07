using OpenTK;
using OpenTK.Graphics;
using System;

namespace RogueTest.Pulsee1.Devices.Display.Window
{
    class Ple_GameWindow : GameWindow
    {
        public Ple_GameWindow(int width, int height, GraphicsMode mode, string title, GameWindowFlags options, DisplayDevice device, int major, int minor, GraphicsContextFlags flags) 
            : base(width, height, mode, title, options, device, major, minor, flags)
        { }

        #region Events on Gamepad

        public event EventHandler GamepadEvent;

        //public

        #endregion
    }
}
