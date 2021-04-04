using System;

namespace FR_1915_Numeration
{
    public class Numeration
    {
        private static readonly string[] noms = "zéro,un,deux,trois,quatre,cinq,six,sept,huit,neuf,dix,onze,douze,treize,quatorze,quinze,seize".Split(',');

        public static string Epeler(long valeur)
        {
            return noms[valeur];
        }
    }
}
