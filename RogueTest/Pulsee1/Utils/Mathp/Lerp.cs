using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsee1.Utilities.Mathp
{
    //It really bothers me that there is no easy LERPing methods available in C# / or math method
    class Lerp
    {
        public static float LerpThatAss(float x, float y, float s) 
        {
            return x * (1 - s) + y * s;
        }
    }
}
