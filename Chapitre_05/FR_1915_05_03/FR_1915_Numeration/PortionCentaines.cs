using System.Text;

namespace FR_1915_Numeration
{
    internal class PortionCentaines : IPortionNombre
    {
        public long Epeler(long valeur, StringBuilder sortie)
        {
            if (valeur > 99)
            {
                sortie.Append("cent");
                valeur %= 100;
                if (valeur > 0)
                {
                    sortie.Append('-');
                }
            }
            return valeur;
        }
    }
}
