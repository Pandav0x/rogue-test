using System;
using OpenTK;
using OpenTK.Input;
using Pulsee1.Binding.Controls;
using Pulsee1.Utilities.Display;

namespace Pulsee1.Controls.Events.DeviceEventHandler.Keyboard
{
    class KeyboardEventHandler
    {
        public bool IsBinded(KeyboardKeyEventArgs e)
        {
            return KeyBinding.keyboardBind.TryGetValue(e.Key, out string a);
        }
        
        public void ExtendedEvent()
        {
            return;
        }

        public void Keh_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (this.IsBinded(e))
                Console.Write("Binded - " + KeyBinding.keyboardBind[e.Key] + "\n");
            xConsole.Write(e.Key.ToString()+" ", ConsoleColor.Red);
            return;
        }

        public void Keh_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            return;
        }

        public void Keh_KeyPress(object sender, KeyPressEventArgs e)
        {
            return;
        }
    }
}
