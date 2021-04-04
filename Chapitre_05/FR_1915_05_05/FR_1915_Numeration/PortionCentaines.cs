using System.Text;

namespace FR_1915_Numeration
{
    internal class PortionCentaines : PortionPuissanceDe10
    {
        private IPortionNombre nomsMultiples = new PortionVicesimale();

        public PortionCentaines() : base(100)
        {

        }
        protected override void EpelerLaPuissance(long nombre, StringBuilder sortie)
        {
            long multiple = nombre / 100;
            string nom = "cent";

            if (multiple > 1)
            {
                nomsMultiples.Epeler(multiple, sortie);
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
