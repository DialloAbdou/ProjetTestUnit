using System;
using System.Text;

namespace FR_1915_Numeration
{
    public class Numeration
    {
        public static string Epeler(long valeur)
        {
            StringBuilder sortie = new StringBuilder();
            PortionNombre top =
                new PortionMillionsATrillions("trillion", 1_000_000_000_000_000_000,
                    new PortionMillionsATrillions("billiard", 1_000_000_000_000_000,
                        new PortionMillionsATrillions("billion" , 1_000_000_000_000,
                            new PortionMillionsATrillions("milliard", 1_000_000_000,
                                new PortionMillionsATrillions("million" , 1_000_000,
                                    new PortionMilliers(
                                        new PortionCentaines(
                                            new PortionDizaines(
                                                new PortionVicesimale()
                                            )
                                        )
                                    )
                                )
                            )
                        )
                    )
                );
            top.Epeler(valeur, sortie);
            return sortie.ToString();
        }
    }
}
