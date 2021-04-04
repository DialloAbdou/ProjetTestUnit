using System;

namespace FR_1915_Numeration
{
    public class Numeration
    {
        public static string Epeler(long valeur)
        {
            if (valeur > 1)
            {
                return "deux";
            }
            if (valeur > 0)
            {
                return "un";
            }
            return "zéro";
        }
    }
}
