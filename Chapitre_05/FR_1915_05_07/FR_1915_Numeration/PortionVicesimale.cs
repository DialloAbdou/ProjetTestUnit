using System.Text;

namespace FR_1915_Numeration
{
    internal class PortionVicesimale : PortionNombre
    {
        private static readonly string[] noms = "zéro,un,deux,trois,quatre,cinq,six,sept,huit,neuf,dix,onze,douze,treize,quatorze,quinze,seize".Split(',');

        public PortionVicesimale() : base(null)
        {
        }
        public override long Epeler(long nombre, StringBuilder sortie)
        {
            if (nombre > 0 || sortie.Length == 0)
            {
                sortie.Append(noms[nombre]);
            }
            return 0;
        }
    }
}
