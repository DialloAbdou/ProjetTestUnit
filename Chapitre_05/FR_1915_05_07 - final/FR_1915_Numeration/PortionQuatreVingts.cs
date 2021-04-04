using System.Text;

namespace FR_1915_Numeration
{
    internal class PortionQuatreVingts : PortionPuissanceDe10
    {
        public PortionQuatreVingts(bool vicesimal, PortionNombre suivant) : base(vicesimal ? 20 : 10, seuil: 80, suivant: suivant)
        {

        }
        public override long Epeler(long nombre, StringBuilder sortie)
        {
            return Puissance == 10 && nombre >= 90
                ? AppelerSuivant(nombre, sortie)
                : base.Epeler(nombre, sortie);
        }
        protected override void EpelerLaPuissance(long nombre, StringBuilder sortie)
        {
            sortie.Append(nombre > 80 ? "quatre-vingt" : "quatre-vingts");
        }
    }
}
