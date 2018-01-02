using System;
using RogueTest.Engine;
using System.Runtime.InteropServices;
using RogueTest.Engine.Utilities.Display;
using OpenTK;

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
            xConsole.WriteLine(AppData.name + " - v" + AppData.version + " (build from " + AppData.buildDate + ")\n");
            xConsole.Write("Initializing shit ...\n", ConsoleColor.Cyan);

            //for a 30x x 20y matrix
            Vector2 gridSize = new Vector2(30, 20);
            Vector2 startPos = new Vector2(((int)Math.Floor(gridSize.X / 2.0)) - 1, ((int)Math.Floor(gridSize.Y / 2.0)) - 1);

            for (int i = 0; i < (gridSize.X * gridSize.Y); i++)
            {

            }

            /*for (int k = 1; k <= (sizeX - 1); k++)
            {
                xConsole.WriteLine(initialX + "-" + initialY);
                for (int j = 0; j < (k < (sizeY - 1) ? 2 : 3); j++)
                {
                    for (int u = 0; u < s; u++)
                    {
                        c++;

                        switch (d)
                        {
                            case 0: y = y + 1; break;
                            case 1: x = x + 1; break;
                            case 2: y = y - 1; break;
                            case 3: x = x - 1; break;
                        }
                    }
                    d = (d + 1) % 4;
                }
                s = s + 1;
            }*/

            GameManager game = new GameManager();
            FloorTest.FloorGenTest();
            game.Run();
            //ShowWindow(handle, SW_HIDE);
        }


    }
}
