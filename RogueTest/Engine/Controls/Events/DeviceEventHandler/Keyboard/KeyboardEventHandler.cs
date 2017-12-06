using System;
using OpenTK;
using OpenTK.Input;
using RogueTest.Engine.Binding.Controls;
using RogueTest.Engine.Utilities.Display;

namespace RogueTest.Engine.Controls.Events.DeviceEventHandler.Keyboard
{
    class KeyboardEventHandler
    {
        public bool isBinded(KeyboardKeyEventArgs e)
        {
            return KeyBinding.keyboardBind.TryGetValue(e.Key, out string a);
        }

        public void extendedEvent()
        {
            return;
        }

        public void keh_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (this.isBinded(e))
                Console.Write("Binded - " + KeyBinding.keyboardBind[e.Key] + "\n");
            xConsole.Write(e.Key.ToString()+" ", ConsoleColor.Red);
            return;
        }

        public void keh_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            return;
        }

        public void keh_KeyPress(object sender, KeyPressEventArgs e)
        {
            return;
        }
    }
}
