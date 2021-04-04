using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_1915_Numeration
{
    internal class PortionMilliers : PortionPuissanceDe10
    {
        public PortionMilliers(PortionNombre suivant) : base(1000, suivant)
        {

        }
        protected override void EpelerLaPuissance(long nombre, StringBuilder sortie)
        {
            long multiple = nombre / 1000;

            if (multiple > 1)
            {
                AppelerSuivant(multiple, sortie);
                sortie.Append("-");
            }
            sortie.Append("mille");
        }
    }
}
