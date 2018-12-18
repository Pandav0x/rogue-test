using OpenTK;
using OpenTK.Graphics;
using Pulsee1.Devices.Controls.Events.DeviceEventHandler.Args.Gamepad;
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

        public event EventHandler<GamepadButtonEventArgs> ButtonDown = delegate { };
        public event EventHandler<GamepadButtonEventArgs> ButtonUp = delegate { };
        public event EventHandler<GamepadButtonEventArgs> ButtonPressed = delegate { };

        public event EventHandler<GamepadTriggerEventArgs> TriggerDown = delegate { };
        public event EventHandler<GamepadTriggerEventArgs> TriggerUp = delegate { };
        public event EventHandler<GamepadTriggerEventArgs> TriggerPressed = delegate { };

        public event EventHandler<GamepadStickEventArgs> StickMove = delegate { };

        protected virtual void OnButtonDown(GamepadButtonEventArgs e)
        {
            ButtonDown(this, e);
        }

        protected virtual void OnButtonUp(GamepadButtonEventArgs e)
        {
            ButtonUp(this, e);
        }

        protected virtual void OnButtonPressed(GamepadButtonEventArgs e)
        {
            ButtonPressed(this, e);
        }

        #endregion
    }
}
