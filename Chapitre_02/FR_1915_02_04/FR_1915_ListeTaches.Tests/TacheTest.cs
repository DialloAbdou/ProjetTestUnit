using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FR_1915_ListeTaches.Tests
{
    [TestClass]
    public class TacheTest
    {
        private readonly TimeSpan _3j_ = TimeSpan.FromDays(3);

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
    }
}
