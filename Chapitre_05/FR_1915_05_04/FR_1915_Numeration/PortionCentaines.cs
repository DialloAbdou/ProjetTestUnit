using System.Text;

namespace FR_1915_Numeration
{
    internal class PortionCentaines : PortionPuissanceDe10
    {
        public PortionCentaines() : base(100)
        {

        }
        protected override void EpelerLaPuissance(long nombre, StringBuilder sortie)
        {
            sortie.Append("cent");
        }
    }
}
