using System.Text;

namespace FR_1915_Numeration
{
    internal abstract class PortionMultiplePuiss10 : PortionPuissanceDe10
    {
        public PortionMultiplePuiss10(long puissance, PortionNombre suivant) : base(puissance, suivant)
        {

        }
        protected override void EpelerLaPuissance(long nombre, StringBuilder sortie)
        {
            long multiple = nombre / Puissance;

            if (multiple > 1)
            {
                base.Epeler(multiple, sortie);
                sortie.Append("-");
            }
            sortie.Append(GetNom(nombre));
        }
        protected abstract string GetNom(long nombre);
    }
}
