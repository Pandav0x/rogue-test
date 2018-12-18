using OpenTK.Input;
using Pulsee1.Devices.Controls.Binding;
using Pulsee1.Utils.Display;
using System;

namespace Pulsee1.Devices.Controls.Events.DeviceHandler.Mouse
{
    class MouseEventHandler
    {
        private EventManager _parent;

        public MouseEventHandler(EventManager parent_)
        {
            this._parent = parent_;
            return;
        }

        public bool IsBinded(MouseButtonEventArgs e)
        {
            return KeyBinding.mouseBind.TryGetValue(e.Button, out string a);
        }

        public string GetActionFromKey(MouseButtonEventArgs e)
        {
            if (KeyBinding.mouseBind.ContainsKey(e.Button))
                return KeyBinding.mouseBind[e.Button];
            return "";
        }


        #region Events Handling

        public void Meh_MouseUp(object sender, MouseButtonEventArgs e)
        {
            return;
        }

        public void Meh_MouseDown(object sender, MouseButtonEventArgs e)
        {
            xConsole.WriteLine("Mouse - " + e.Button.ToString() + " ", ConsoleColor.Red);
            return;
        }

        public void Meh_MouseEnter(object sender, EventArgs e)
        {
            return;
        }

        public void Meh_MouseLeave(object sender, EventArgs e)
        {
            return;
        }

        public void Meh_MouseMove(object sender, MouseMoveEventArgs e)
        {
            return;
        }

        public void Meh_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            xConsole.WriteLine("My dick is big like really", ConsoleColor.DarkGreen);
            return;
        }

        #endregion
    }
}
