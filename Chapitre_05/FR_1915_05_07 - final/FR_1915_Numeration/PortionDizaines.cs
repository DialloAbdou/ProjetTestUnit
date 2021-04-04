using System.Text;

namespace FR_1915_Numeration
{
    internal class PortionDizaines : PortionPuissanceDe10
    {
        private static readonly string[] nomsDizaines = "dix,vingt,trente,quarante,cinquante,soixante,septante,huitante,nonante".Split(',');

        public PortionDizaines(PortionNombre suivant) : base(10, seuil: 17, suivant:suivant)
        {

        }
        protected override void EpelerLaPuissance(long nombre, StringBuilder sortie)
        {
            sortie.Append(nomsDizaines[nombre / 10 - 1]);
        }
        protected override string GetSeparateur(long nombre)
        {
            return nombre == 1
                ? "-et-"
                : base.GetSeparateur(nombre);
        }
    }
}
