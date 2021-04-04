using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_1915_Numeration
{
    internal class PortionMilliers : PortionMultiplePuiss10
    {
        public PortionMilliers(PortionNombre suivant) : base(1000, suivant)
        {

        }

        protected override string GetNom(long nombre) => "mille";
        
    }
}
