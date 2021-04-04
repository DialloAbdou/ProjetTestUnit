using System;
using System.Text;

namespace FR_1915_Numeration
{
    public class Numeration
    {
        private PortionNombre top;

        public Numeration(OptionNumeration options)
        {
            top = new PortionDizaines(new PortionVicesimale());
            if (options.HasFlag(OptionNumeration.SoixanteDix))
            {
                top = new PortionSoixanteDix(top);
            }
            if (options.HasFlag(OptionNumeration.QuatreVingts))
            {
                top = new PortionQuatreVingts(options.HasFlag(OptionNumeration.QuatreVingtDix), top);
            }
            top = new PortionMilliers(new PortionCentaines(top));

            var listePrefixes = "m,b,tr".Split(',');
            var listeSuffixes = "on,ard".Split(',');
            var puissance = 1_000_000L;

            foreach (var prefixe in listePrefixes)
            {
                foreach (var suffixe in listeSuffixes)
                {
                    top = new PortionMillionsATrillions($"{prefixe}illi{suffixe}", puissance, top);
                    puissance *= 1000;
                }
            }
        }
        public string Epeler(long valeur)
        {
            StringBuilder sortie = new StringBuilder();
            top.Epeler(valeur, sortie);
            return sortie.ToString();
        }
    }
}
