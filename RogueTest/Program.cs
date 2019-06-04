using System;
using System.Runtime.InteropServices;
using Pulsee.Utilities.Display;
using Pulsee;

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
            Console.Title = "Debug console (" + AppData.version + " - " + AppData.buildName + ")";
            xConsole.WriteLine(AppData.name + " - v" + AppData.version + " (build from " + AppData.buildDate + ")\n");
            xConsole.Write("Initializing...\n");
            GameManager game = new GameManager();
            game.Run();
            //ShowWindow(handle, SW_HIDE); // technically hides the console window, but not quite lately... 
        }
    }
}
