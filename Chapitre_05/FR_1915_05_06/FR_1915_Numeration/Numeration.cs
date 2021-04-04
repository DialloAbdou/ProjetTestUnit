using System;
using System.Text;

namespace FR_1915_Numeration
{
    public class Numeration
    {
        public static string Epeler(long valeur)
        {
            StringBuilder sortie = new StringBuilder();
            PortionNombre top = new PortionMilliers(
                new PortionCentaines(
                    new PortionDizaines(
                        new PortionVicesimale()
                    )
                )
            );
            top.Epeler(valeur, sortie);
            return sortie.ToString();
        }
    }
}
