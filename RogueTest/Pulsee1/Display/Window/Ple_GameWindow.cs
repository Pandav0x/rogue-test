using OpenTK;
using OpenTK.Graphics;
using Pulsee1.Utils.Display;
using Pulsee1.Controls.Gamepad;
using System;

namespace RogueTest.Pulsee1.Devices.Display.Window
{
    class Ple_GameWindow : GameWindow, IDisposable
    {
        private Type NativeWindow;

        public Ple_GameWindow(int width, int height, GraphicsMode mode, string title, GameWindowFlags options, 
            DisplayDevice device, int major, int minor, GraphicsContextFlags flags) 
            : base(width, height, mode, title, options, device, major, minor, flags)
        {
            xConsole.WriteLine(new String('-', 20), ConsoleColor.Cyan);

            GamepadListener.Start(this);

            xConsole.WriteLine(new String('-', 20), ConsoleColor.Cyan);
            return;
        }        

        #region Events on Gamepad

        public event EventHandler<GamepadEventArgs> ButtonDown = delegate { };
        public event EventHandler<GamepadEventArgs> ButtonUp = delegate { };
        public event EventHandler<GamepadEventArgs> ButtonPressed = delegate { };

        public event EventHandler<GamepadEventArgs> TriggerDown = delegate { };
        public event EventHandler<GamepadEventArgs> TriggerUp = delegate { };

        public event EventHandler<GamepadEventArgs> LeftStickMove = delegate { };
        public event EventHandler<GamepadEventArgs> RightStickMove = delegate { };

        public virtual void OnButtonDown(GamepadEventArgs e)
        {
            ButtonDown(this, e);
        }

        public virtual void OnButtonUp(GamepadEventArgs e)
        {
            ButtonUp(this, e);
        }

        public virtual void OnButtonPressed(GamepadEventArgs e)
        {
            ButtonPressed(this, e);
        }

        public virtual void OnTriggerDown(GamepadEventArgs e)
        {
            TriggerDown(this, e);
        }

        public virtual void OnTriggerUp(GamepadEventArgs e)
        {
            TriggerUp(this, e);
        }

        public virtual void OnLeftStickMove(GamepadEventArgs e)
        {
            LeftStickMove(this, e);
        }

        public virtual void OnRightStickMove(GamepadEventArgs e)
        {
            RightStickMove(this, e);
        }

        #endregion
    }
}
