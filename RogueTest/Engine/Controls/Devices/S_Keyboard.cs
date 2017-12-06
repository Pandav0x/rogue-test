using OpenTK.Input;

namespace RogueTest.Engine.Controls.Devices
{
    class S_Keyboard
    {
        private static S_Keyboard instance;

        private S_Keyboard()
        {
            return;
        }

        public static S_Keyboard GetInstance()
        {
            if (S_Keyboard.instance == null)
                S_Keyboard.instance = new S_Keyboard();
            return S_Keyboard.instance;
        }

    }
}
