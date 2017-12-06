using System;
using RogueTest.Engine;
using System.Runtime.InteropServices;
using RogueTest.Engine.Utilities.Display;
using RogueTest.Engine.Utilities.Mathp;

namespace RogueTest
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        [STAThread]
        static void Main(string[] args)
        {      
            var handle = GetConsoleWindow();
            Console.Title = "Only output console (don)";
            xConsole.Write("Initializing shit ...\n");
            xConsole.Write("Starting all the mess\n", ConsoleColor.Cyan);
            GameManager game = new GameManager();
            FloorTest.FloorGenTest();
            game.Run();
            //ShowWindow(handle, SW_HIDE);
        }


    }
}
