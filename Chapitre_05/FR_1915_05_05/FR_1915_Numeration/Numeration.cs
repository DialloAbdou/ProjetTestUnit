using System;
using System.Text;

namespace FR_1915_Numeration
{
    public class Numeration
    {
        public static string Epeler(long valeur)
        {
            StringBuilder sortie = new StringBuilder();
            IPortionNombre[] portions = {
                new PortionMilliers  (),
                new PortionCentaines (),
                new PortionDizaines  (),
                new PortionVicesimale()
            };
            foreach (var portion in portions)
            {
                valeur = portion.Epeler(valeur, sortie);
            }
            return sortie.ToString();
        }
    }
}
