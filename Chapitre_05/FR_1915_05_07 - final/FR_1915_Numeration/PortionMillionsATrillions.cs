namespace FR_1915_Numeration
{
    internal class PortionMillionsATrillions : PortionMultiplePuiss10
    {
        private string nom;

        public PortionMillionsATrillions(string nom, long puissance, PortionNombre suivant) : base(puissance, suivant)
        {
            this.nom = nom;
        }
        protected override string GetNom(long nombre)
        {
            return nombre / Puissance == 1
                ? $"un-{ nom }"
                : $"{ nom }s";
        }
    }
}
