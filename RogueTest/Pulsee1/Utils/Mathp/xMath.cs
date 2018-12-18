using OpenTK;
using System;

namespace RogueTest.Pulsee1.Utils.Mathp
{
    static class xMath
    {
        public static Vector2 Abs(Vector2 value)
        {
            return new Vector2(Math.Abs(value.X), Math.Abs(value.Y));
        }

        public static bool Vector2GreaterThan(Vector2 a, Vector2 b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2)) > 0;
        }
    }
}
