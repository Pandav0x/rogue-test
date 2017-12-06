using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace RogueTest.Engine.Utilities.Mathp
{
    static class xRandom
    {
        public static readonly Random random = new Random();

        public static float GetRandomNumber()
        {
            return xRandom.random.Next(0, 1);
        }

        public static Vector2 GetRandomSize(int min, int max)
        {
            Vector2 ret = new Vector2(xRandom.random.Next(min, max), xRandom.random.Next(min, max)); //floor min-max size
            return ret;
        }
    }    
}
