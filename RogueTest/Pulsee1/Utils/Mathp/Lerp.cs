namespace Pulsee1.Utils.Mathp
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
