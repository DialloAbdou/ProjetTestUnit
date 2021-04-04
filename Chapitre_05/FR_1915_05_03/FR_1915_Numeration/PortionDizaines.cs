using System.Text;

namespace FR_1915_Numeration
{
    internal class PortionDizaines : IPortionNombre
    {
        private static readonly string[] nomsDizaines = "dix,vingt,trente,quarante,cinquante,soixante,septante,huitante,nonante".Split(',');

        public long Epeler(long valeur, StringBuilder sortie)
        {
            if (valeur > 16)
            {
                sortie.Append(nomsDizaines[valeur / 10 - 1]);
                valeur %= 10;
                if (valeur == 1)
                {
                    sortie.Append("-et-");
                }
                else if (valeur > 0)
                {
                    sortie.Append('-');
                }
            }
            return valeur;
        }
    }
}
