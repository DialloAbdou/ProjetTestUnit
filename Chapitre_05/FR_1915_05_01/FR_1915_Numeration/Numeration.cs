using System;
using System.Text;

namespace FR_1915_Numeration
{
    public class Numeration
    {
        private static readonly string[] noms = "zéro,un,deux,trois,quatre,cinq,six,sept,huit,neuf,dix,onze,douze,treize,quatorze,quinze,seize".Split(',');
        private static readonly string[] nomsDizaines = "dix,vingt,trente,quarante,cinquante,soixante,septante,huitante,nonante".Split(',');

        public static string Epeler(long valeur)
        {
            StringBuilder sortie = new StringBuilder();

            if (valeur>16)
            {
                sortie.Append(nomsDizaines[valeur / 10 - 1]);
                valeur %= 10;
                if (valeur > 0)
                {
                    sortie.Append('-');
                }
            }
            if(valeur > 0 || sortie.Length == 0)
            {
                sortie.Append(noms[valeur]);
            }
            return sortie.ToString();
        }
    }
}
