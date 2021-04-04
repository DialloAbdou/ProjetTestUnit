using System.Text;

namespace FR_1915_Numeration
{
    internal abstract class PortionNombre
    {
        private PortionNombre suivant;

        public PortionNombre(PortionNombre suivant)
        {
            this.suivant = suivant;
        }
        public abstract long Epeler(long nombre, StringBuilder sortie);

        protected long AppelerSuivant(long nombre, StringBuilder sortie)
        {
            return suivant.Epeler(nombre, sortie);
        }
    }
}
