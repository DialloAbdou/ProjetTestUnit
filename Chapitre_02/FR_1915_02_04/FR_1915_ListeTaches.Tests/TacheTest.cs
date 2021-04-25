using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace FR_1915_ListeTaches.Tests
{
    [TestClass]
    public class TacheTest
    {
        private readonly TimeSpan _3j_ = TimeSpan.FromDays(3);
        private readonly TimeSpan _2j_ = TimeSpan.FromDays(2);
        private readonly TimeSpan _1j_ = TimeSpan.FromDays(1);
        private readonly TimeSpan _0j_ = TimeSpan.FromDays(0);

        private Tache  tache1erAvril3j;
        private DateTime dateDebut = new DateTime(2018, 4, 1);
        [TestInitialize]
        public void initTest()
        {
          //  var dateDebut = new DateTime(2018, 4, 1);
            tache1erAvril3j = new Tache("Poisson d'avril", dateDebut, _3j_);
        }

        private Tache NouvelleTacheAVril(string titre="Poison d'avril",int duree = 3)
        {    
            return new Tache(titre, dateDebut, TimeSpan.FromDays(duree));
        }
        private Tache NouvelleTacheEntame(int duree, int fait)
        {
            var tacherAvril = NouvelleTacheAVril(duree: duree);
            tacherAvril.Effectuer(TimeSpan.FromDays(fait));
            return tacherAvril;

        }
      
        [TestMethod]
        public void Initialiser_3jAu1erAvril_DefinitTitreDureeResteAFaireNonTerminee()
        {
            Assert.AreEqual("Poisson d'avril", tache1erAvril3j.Titre);
            Assert.AreEqual(_3j_, tache1erAvril3j.Duree);
            Assert.AreEqual(_3j_, tache1erAvril3j.ResteAFaire);
            Assert.IsFalse (tache1erAvril3j.EstTerminee);
        }
        [TestMethod]
        public void effectuer_2JourTravail_TacheNonTerminee()
        {
            var tacheEntame = NouvelleTacheEntame(duree:3, fait:2);
            Assert.AreEqual(_1j_, tacheEntame.ResteAFaire);
            Assert.IsFalse(tacheEntame.EstTerminee);
        }
        [TestMethod]
        public void effectuer_1JourTravail_TacheNonTerminee()
        {
            var tacheEntame = NouvelleTacheEntame(duree: 3, fait: 1);
            Assert.AreEqual(_2j_, tacheEntame.ResteAFaire);
            Assert.IsFalse(tacheEntame.EstTerminee);
        }

        [TestMethod]
        public void effectuer_3JourTravail_TacheTerminee()
        {
            var tacheEntame = NouvelleTacheEntame(duree: 3, fait: 3);
            Assert.AreEqual(_0j_, tacheEntame.ResteAFaire);
            Assert.IsTrue(tacheEntame.EstTerminee);
        }
        /**
         *  Utilisation des Parametre*
         */
        [DataTestMethod]
        [DataRow(1, 2, 3)]
        public void effectuer_2JourTravail_TacheNonTermineeAVecParametre(double restAffaire, int fait, int totalJours)
        {
            var tacheAvril = NouvelleTacheEntame(duree: totalJours, fait: fait);
            Assert.AreEqual(TimeSpan.FromDays(restAffaire), tacheAvril.ResteAFaire);
            Assert.IsFalse(tacheAvril.EstTerminee);
        }

        /**
         * =====Utilisation Exception===*
         * **/

        [TestMethod]
        public void effectuer_JourTravailAvecException_TacheTerminee()
        {
            var tacheEntame = NouvelleTacheEntame(duree: 3, fait: 2);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => tacheEntame.Effectuer(_2j_));
        }

        /*
         * ==========Utilisation des Collection dans les Test*
         */


        [TestMethod]
        public void effectuer_JourTravailEnCollection_TacheTerminee()
        {
            var tacheEntameA = NouvelleTacheEntame(duree: 3, fait: 3);
            var tacheEntameB = NouvelleTacheEntame(duree:3,fait:2);
            var tacheEntameC = NouvelleTacheEntame(duree: 1, fait: 1);
            var tacheEntameD = NouvelleTacheAVril(duree: 2);
            var tacheListes = new Tache[] { tacheEntameA, tacheEntameB, tacheEntameC, tacheEntameD };
            var tacheAttendues = new Tache[] { tacheEntameA, tacheEntameC };
            var tacheObtenues = Tache.FiltrerTerminees(tacheListes);
            CollectionAssert.AreEqual(tacheAttendues, tacheObtenues.ToList()); 
        }

        [TestMethod]
        public void effectuer_JourCs_TacheFormat()
        {
            var tacheAvril = NouvelleTacheAVril("Poisson Avril", duree: 2);
            var subtitudeFormat = Substitute.For<IFormatProvider>();
            subtitudeFormat.GetFormat(Arg.Any<Type>()).Returns(DateTimeFormatInfo.InvariantInfo);
            tacheAvril.Effectuer(_1j_);
            string attendu = "Poisson d'avril;04/16/2021;2.00:00:00;1.00:00:00;1.00:00:00;1.00:00:00";
            var obtenue =   tacheAvril.LigneCSV(subtitudeFormat);
            Assert.AreEqual(attendu, obtenue);
        }
    }
}
