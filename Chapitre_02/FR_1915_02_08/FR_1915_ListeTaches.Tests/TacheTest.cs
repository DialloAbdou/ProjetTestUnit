using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FR_1915_ListeTaches.Tests
{
    [TestClass]
    public class TacheTest
    {
        private readonly TimeSpan
            _0j_ = TimeSpan.Zero,
            _1j_ = TimeSpan.FromDays(1),
            _2j_ = TimeSpan.FromDays(2),
            _3j_ = TimeSpan.FromDays(3);

        private Tache tache1erAvril3j;

        [TestInitialize]
        public void InitTests()
        {
            tache1erAvril3j = new Tache("Poisson d'avril", new DateTime(2018, 4, 1), _3j_);
        }
        private Tache NouvelleTache1erAvril(string titre = "Poisson d'avril", int duree = 3)
        {
            return new Tache(titre, new DateTime(2018, 4, 1), TimeSpan.FromDays(duree));
        }
        private Tache NouvelleTache1erAvrilEntamee(int duree, int fait)
        {
            var tache1erAvril = NouvelleTache1erAvril(duree: duree);

            tache1erAvril.Effectuer(TimeSpan.FromDays(fait));
            return tache1erAvril;
        }

        [TestMethod]
        public void Initialiser_3jAu1erAvril_DefinitTitreDureeResteAFaireNonTerminee()
        {
            var tache1erAvril3j = NouvelleTache1erAvril("Poisson d'avril", duree: 3);

            Assert.AreEqual("Poisson d'avril", tache1erAvril3j.Titre);
            Assert.AreEqual(_3j_, tache1erAvril3j.Duree);
            Assert.AreEqual(_3j_, tache1erAvril3j.ResteAFaire);
            Assert.IsFalse(tache1erAvril3j.EstTerminee);
        }
        [TestMethod]
        public void Effectuer_1Tier_ResteAFaireVaut2Tiers_EstTermineEstFaux()
        {
            var tache1jSur3j = NouvelleTache1erAvrilEntamee(duree: 3, fait: 1);

            Assert.AreEqual(_2j_, tache1jSur3j.ResteAFaire);
            Assert.IsFalse(tache1jSur3j.EstTerminee);
        }
        [DataTestMethod]
        [DataRow(2, 1, 3, DisplayName = "Effectuer_1Tier_ResteAFaireVaut2Tiers_EstTermineEstFaux")]
        [DataRow(1, 1, 2, DisplayName = "Effectuer_Motie_ResteAFaireVautMoitie_EstTermineEstFaux")]
        public void Effectuer_Partiellement_EstTermineEstFaux(double attenduResteAFaire, int fait, int totalJours)
        {
            var tachePartielle = NouvelleTache1erAvrilEntamee(duree: totalJours, fait: fait);

            Assert.AreEqual(TimeSpan.FromDays(attenduResteAFaire), tachePartielle.ResteAFaire);
            Assert.IsFalse(tachePartielle.EstTerminee);
        }
        [TestMethod]
        public void Effectuer_Tout_ResteAFaireVaut0_EstTermineEstVrai()
        {
            var tache3jSur3j = NouvelleTache1erAvrilEntamee(duree: 3, fait: 3);

            Assert.AreEqual(_0j_, tache3jSur3j.ResteAFaire);
            Assert.IsTrue(tache3jSur3j.EstTerminee);
        }
        [TestMethod]
        [Ignore("Eviter ExpectedException : Test valide quelle que soit la ligne levant l'exception")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Effectuer_Trop_LeveUneException_DECONSEILLE()
        {
            var tache2jSur3j = NouvelleTache1erAvrilEntamee(duree: 3, fait: 2);

            tache2jSur3j.Effectuer(_2j_);
        }
        [TestMethod]
        public void Effectuer_Trop_LeveUneException_CONSEILLE()
        {
            var tache2jSur3j = NouvelleTache1erAvrilEntamee(duree: 3, fait: 2);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => tache2jSur3j.Effectuer(_2j_));
        }
    }
}
