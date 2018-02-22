using System;

namespace Pulsee1.Utils.Display
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

        public static void Write(string text, MessageType mt)
        {
            xConsole.Write(text, ColorMessageType(mt));
            return;
        }

        public static void WriteLine(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
            return;
        }

        public static void WriteLine(string text, MessageType mt)
        {
            xConsole.WriteLine(text, ColorMessageType(mt));
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

        public static void ClearLine(int num = 1)
        {
            Console.Write(new String('\r', num));
            return;
        }

        private static ConsoleColor ColorMessageType(MessageType mt)
        {
            switch (mt)
            {
                case MessageType.Warning:
                    return ConsoleColor.Yellow;
                case MessageType.Error:
                    return ConsoleColor.Red;
                case MessageType.Info:
                    return ConsoleColor.Cyan;
                default:
                    return ConsoleColor.White;
            }
        }
    }

    public enum MessageType
    {
        Warning,
        Error,
        Info
    }
}
