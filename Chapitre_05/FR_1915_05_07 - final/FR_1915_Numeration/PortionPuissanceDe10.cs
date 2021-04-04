using System;
using System.Text;

namespace FR_1915_Numeration
{
    internal abstract class PortionPuissanceDe10 : PortionNombre
    {
        private long seuil, puissance;

        public PortionPuissanceDe10(long puissance, PortionNombre suivant) : base(suivant)
        {
            seuil = this.puissance = puissance;
        }
        
        public PortionPuissanceDe10(long puissance, long seuil, PortionNombre suivant) : base(suivant)
        {
            this.puissance = puissance;
            this.seuil = seuil;
        }
        protected long Puissance { get => puissance; }
        public override long Epeler(long nombre, StringBuilder sortie)
        {
            if (nombre >= seuil)
            {
                EpelerLaPuissance(nombre, sortie);
                nombre %= puissance;
                if (nombre > 0)
                {
                    sortie.Append(GetSeparateur(nombre));
                }
            }
            return AppelerSuivant(nombre, sortie);
        }

        protected virtual string GetSeparateur(long nombre)
        {
            return "-";
        }

        protected abstract void EpelerLaPuissance(long nombre, StringBuilder sortie);
    }
}
