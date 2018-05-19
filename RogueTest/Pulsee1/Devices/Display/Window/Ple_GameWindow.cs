using OpenTK;
using OpenTK.Graphics;
using Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.GamePad;
using Pulsee1.Utils.Display;
using RogueTest.Pulsee1.Devices.Controls.Peripherals;
using System;

namespace RogueTest.Pulsee1.Devices.Display.Window
{
    class Ple_GameWindow : GameWindow, IDisposable
    {
        private Type nativeWindow;

        public Ple_GameWindow(int width, int height, GraphicsMode mode, string title, GameWindowFlags options, 
            DisplayDevice device, int major, int minor, GraphicsContextFlags flags) 
            : base(width, height, mode, title, options, device, major, minor, flags)
        {
            xConsole.WriteLine(new String('-', 20), System.ConsoleColor.Cyan);

            GamepadListener.Start();

            xConsole.WriteLine(new String('-', 20), System.ConsoleColor.Cyan);
            return;
        }        

        #region Events on Gamepad

        //public GamePadState a = new GamePadState();

        public event EventHandler<GamePadButtonEventArgs> ButtonDown = delegate { };
        public event EventHandler<GamePadButtonEventArgs> ButtonUp = delegate { };
        public event EventHandler<GamePadButtonEventArgs> ButtonPressed = delegate { };

        public event EventHandler<GamePadTriggerEventArgs> TriggerDown = delegate { };
        public event EventHandler<GamePadTriggerEventArgs> TriggerUp = delegate { };
        public event EventHandler<GamePadTriggerEventArgs> TriggerPressed = delegate { };

        public event EventHandler<GamePadStickEventArgs> StickMove = delegate { };

        protected virtual void OnButtonDown(GamePadButtonEventArgs e)
        {
            ButtonDown(this, e);
        }

        protected virtual void OnButtonUp(GamePadButtonEventArgs e)
        {
            ButtonUp(this, e);
        }

        protected virtual void OnButtonPressed(GamePadButtonEventArgs e)
        {
            ButtonPressed(this, e);
        }

        #endregion
    }
}
