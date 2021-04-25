using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_1915_ListeTaches
{
    public interface IHorloge
    {
        DateTime Maintenant{ get; }
    }
}
