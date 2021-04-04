using System;

namespace FR_1915_Numeration
{
    [Flags]
    public enum OptionNumeration
    {
        Septante = 0,
        SoixanteDix = 1,

        Huitante = 0,
        QuatreVingts = 2,

        Nonante = 0,
        QuatreVingtDix = 4 | QuatreVingts,
    }
}