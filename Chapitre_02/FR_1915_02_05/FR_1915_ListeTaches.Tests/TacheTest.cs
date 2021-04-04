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

        [TestMethod]
        public void Initialiser_3jAu1erAvril_DefinitTitreDureeResteAFaireNonTerminee()
        {
            Tache tache1erAvril3j;
            
            tache1erAvril3j = new Tache("Poisson d'avril", new DateTime(2018, 4, 1), _3j_);
            Assert.AreEqual("Poisson d'avril", tache1erAvril3j.Titre);
            Assert.AreEqual(_3j_, tache1erAvril3j.Duree);
            Assert.AreEqual(_3j_, tache1erAvril3j.ResteAFaire);
            Assert.IsFalse (tache1erAvril3j.EstTerminee);
        }
        [TestMethod]
        public void Effectuer_1Tier_ResteAFaireVaut2Tiers_EstTermineEstFaux()
        {
            var tache3j = new Tache("Poisson d'avril", new DateTime(2018, 4, 1), _3j_);

            tache3j.Effectuer(_1j_);
            Assert.AreEqual(_2j_, tache3j.ResteAFaire);
            Assert.IsFalse(tache3j.EstTerminee);
        }
        [TestMethod]
        public void Effectuer_Tout_ResteAFaireVaut0_EstTermineEstVrai()
        {
            var tache3j = new Tache("Poisson d'avril", new DateTime(2018, 4, 1), _3j_);

            tache3j.Effectuer(_3j_);
            Assert.AreEqual(_0j_, tache3j.ResteAFaire);
            Assert.IsTrue(tache3j.EstTerminee);
        }
        [TestMethod]
        public void Effectuer_Trop_LeveUneException()
        {
            Assert.Fail("Non implémentée");
        }
    }
}
