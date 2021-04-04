using System;

namespace FR_1915_ListeTaches
{
    public class HorlogeSysteme : IHorloge
    {
        public DateTime Maintenant => DateTime.Now;        
    }
}
