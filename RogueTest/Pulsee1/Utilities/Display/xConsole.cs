using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsee1.Utilities.Display
{
    public class xConsole
    {
        public static void Write(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
            return;
        }

        public static void WriteLine(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
            return;
        }

        public static int Read()
        {
            return Console.Read();
        }

        public static string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
