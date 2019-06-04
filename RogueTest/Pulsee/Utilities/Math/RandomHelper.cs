using System;
using OpenTK;

namespace Pulsee.Utilities.Math
{
    static class RandomHelper
    {
        public static readonly Random random = new Random();

        public static float GetRandomNumber()
        {
            return RandomHelper.random.Next(0, 100);
        }

        public static Vector2 RandomVector(int min, int max)
        {
            Vector2 vector = new Vector2(random.Next(min, max), random.Next(min, max)); //floor min-max size
            return vector;
        }
    }    
}
