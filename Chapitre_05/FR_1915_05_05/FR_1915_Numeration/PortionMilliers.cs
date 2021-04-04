using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_1915_Numeration
{
    internal class PortionMilliers : PortionPuissanceDe10
    {
        private IPortionNombre[] nomsMultiples = {
            new PortionCentaines(),
            new PortionDizaines(),
            new PortionVicesimale()
        };
        public PortionMilliers() : base(1000)
        {

        }
        protected override void EpelerLaPuissance(long nombre, StringBuilder sortie)
        {
            long multiple = nombre / 1000;

            if (multiple > 1)
            {
                foreach (var portion in nomsMultiples)
                {
                    multiple = portion.Epeler(multiple, sortie);
                }
                sortie.Append("-");
            }
            sortie.Append("mille");
        }
    }
}
