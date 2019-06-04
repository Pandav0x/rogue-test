using OpenTK;

namespace RogueTest.Pulsee.Utilities.Math
{
    static class MathHelper
    {
        public static Vector2 Abs(Vector2 vect)
        {
            return new Vector2(System.Math.Abs(vect.X), System.Math.Abs(vect.Y));
        }

        public static float Lerp(float x, float y, float s)
        {
            return x * (1 - s) + y * s;
        }
    }
}
