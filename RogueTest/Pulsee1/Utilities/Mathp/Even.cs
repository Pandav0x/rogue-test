using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsee1.Utilities.Mathp
{
    static class Even
    {
        public static bool IsEven(int numberToTest)
        {
            return numberToTest % 2 == 0;
        }

        public static bool IsEven(float numberToTest)
        {
            return numberToTest % 2f == 0f;
        }

        public static bool IsEven(double numberToTest)
        {
            return numberToTest % 2d == 0d;
        }
    }
}
