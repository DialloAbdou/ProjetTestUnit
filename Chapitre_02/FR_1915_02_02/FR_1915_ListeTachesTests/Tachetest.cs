using FR_1915_ListeTaches;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FR_1915_ListeTachesTests
{
    [TestClass]
    public class Tachetest
    {
        private readonly TimeSpan
            _3j_ = TimeSpan.FromDays(3),
            _2j_ = TimeSpan.FromDays(2),
           _1J_ = TimeSpan.FromDays(1),
           _0J_ = TimeSpan.FromDays(0);
       
        [TestInitialize]
        public void InitTest()
        {
            DateTime deb1avril3j = new DateTime(2014, 4, 1);
            Tache tacheAvril = new Tache("Poisson Avril", deb1avril3j, _3j_);
        }

        private Tache NouvelleTache1erAvril(string titre ="Poisson Avril", int duree = 3)
        {
            return new Tache(titre, new DateTime(2014, 4, 1),TimeSpan.FromDays(duree));
        }
        private Tache NouvelleTache1erAvrilEntame(int duree, int fait)
        {
            var tache1erAvril = NouvelleTache1erAvril(duree: duree);
            tache1erAvril.Effectuer(TimeSpan.FromDays(fait));
            return tache1erAvril;
        }

        [TestMethod]
        public void Initialiser_3JourAudebutAvril_DefinirTitre_ResterAfaire_NonTerminer()
        {

            var tache1erAvril = NouvelleTache1erAvril("Poisson Avril", 3);
            Assert.AreEqual("Poisson Avril", tache1erAvril.Titre);
            Assert.AreEqual(_3j_, tache1erAvril.Duree);
            Assert.AreEqual(_3j_, tache1erAvril.ResteAFaire);
        }

        [TestMethod]
        public void effectuer_2JTraivailResteAfaire_NonTerminer()
        {
            //var tacheAvril = NouvelleTache1erAvrilEntame(duree: 3, fait: 2);
            var tacheAvril = NouvelleTache1erAvril("Poisson Avril", 3);
            Assert.AreEqual("Poisson Avril", tacheAvril.Titre);
            tacheAvril.Effectuer(_2j_);
            Assert.AreEqual(_1J_, tacheAvril.ResteAFaire);
            Assert.IsFalse(tacheAvril.EstTerminee);
        }

        [TestMethod]
        public void effectuer_3JTraivail_TravailEstTerminer()
        {
           //var tacheAvril = NouvelleTache1erAvrilEntame(duree: 3, fait: 3);
            var tacheAvril = NouvelleTache1erAvril("Poisson Avril", 3);
            Assert.AreEqual("Poisson Avril", tacheAvril.Titre);
            tacheAvril.Effectuer(_3j_);
            Assert.AreEqual(_0J_, tacheAvril.ResteAFaire);
            Assert.IsTrue(tacheAvril.EstTerminee);
        }

        [TestMethod]
        public void effectuer_Trop_LeverUneException()
        {
            var tachesAvril = NouvelleTache1erAvrilEntame(duree: 3, fait: 2);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => tachesAvril.Effectuer(_2j_));
        }
    }
}
