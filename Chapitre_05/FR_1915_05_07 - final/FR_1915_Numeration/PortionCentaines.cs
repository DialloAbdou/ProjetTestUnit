using System.Text;

namespace FR_1915_Numeration
{
    internal class PortionCentaines : PortionMultiplePuiss10
    {
        public PortionCentaines(PortionNombre suivant) : base(100, suivant)
        {

        }
        protected override string GetNom(long nombre) =>
            nombre < 200 || nombre % 100 > 0
                ? "cent"
                : "cents";
        
    }
}
