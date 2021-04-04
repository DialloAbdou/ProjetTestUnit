using System;
using System.Text;

namespace FR_1915_Numeration
{
    internal abstract class PortionPuissanceDe10 : IPortionNombre
    {
        private long seuil, puissance;

        public PortionPuissanceDe10(long puissance)
        {
            seuil = this.puissance = puissance;
        }

        public PortionPuissanceDe10(long puissance, long seuil)
        {
            this.puissance = puissance;
            this.seuil = seuil;
        }
        public long Epeler(long nombre, StringBuilder sortie)
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
            return nombre;
        }

        protected virtual string GetSeparateur(long nombre)
        {
            return "-";
        }

        protected abstract void EpelerLaPuissance(long nombre, StringBuilder sortie);
    }
}
