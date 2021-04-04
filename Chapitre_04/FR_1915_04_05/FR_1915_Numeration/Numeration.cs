using System;

namespace FR_1915_Numeration
{
    public class Numeration
    {
        private static readonly string[] noms = "zéro,un,deux,trois,quatre,cinq,six,sept,huit,neuf,dix,onze,douze,treize,quatorze,quinze,seize".Split(',');
        private static readonly string[] nomsDizaines = "dix,vingt,trente,quarante,cinquante,soixante,septante,huitante,nonante".Split(',');

        public static string Epeler(long valeur)
        {
            if(valeur>16)
            {
                if (valeur % 10 == 0)
                    return nomsDizaines[valeur / 10 - 1];
                else
                    return $"{ nomsDizaines[valeur/10-1] }-{ noms[valeur%10] }";
            }
            return noms[valeur];
        }
    }
}
