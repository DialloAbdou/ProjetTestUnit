using System.Text;

namespace FR_1915_Numeration
{
    internal class PortionCentaines : PortionPuissanceDe10
    {
        public PortionCentaines(PortionNombre suivant) : base(100, suivant)
        {

        }
        protected override void EpelerLaPuissance(long nombre, StringBuilder sortie)
        {
            long multiple = nombre / 100;
            string nom = "cent";

            if (multiple > 1)
            {
                AppelerSuivant(multiple, sortie);
                sortie.Append("-");
                if (nombre % 100 == 0)
                {
                    nom = "cents";
                }
            }
            sortie.Append(nom);
        }
    }
}
