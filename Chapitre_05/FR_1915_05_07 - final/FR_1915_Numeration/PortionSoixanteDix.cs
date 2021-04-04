using System.Text;

namespace FR_1915_Numeration
{
    internal class PortionSoixanteDix : PortionPuissanceDe10
    {
        public PortionSoixanteDix(PortionNombre suivant) : base(20, seuil: 60, suivant: suivant)
        {

        }
        protected override void EpelerLaPuissance(long nombre, StringBuilder sortie)
        {
            sortie.Append("soixante");
            if (nombre % 10 == 1)
            {
                sortie.Append("-et");
            }
        }
    }
}
