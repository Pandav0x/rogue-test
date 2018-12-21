using OpenTK;
using System;

namespace RogueTest.Pulsee1.Utils.Mathp
{
    static class xMath
    {
        public static Vector2 Abs(Vector2 vect)
        {
            return new Vector2(Math.Abs(vect.X), Math.Abs(vect.Y));
        }
    }
}
