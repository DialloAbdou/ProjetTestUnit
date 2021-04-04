﻿using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

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
        public void Effectuer_Tout_ResteAFaireVaut0_EstTermineEstVrai_EvenementTerminee()
        {
            var tache3j = NouvelleTache1erAvril(duree: 3);
            var nDeclenchementTerminee = 0;

            tache3j.Terminee += (sender, e) => nDeclenchementTerminee++; 
            tache3j.Effectuer(_3j_);
            Assert.AreEqual(_0j_, tache3j.ResteAFaire);
            Assert.IsTrue(tache3j.EstTerminee);
            Assert.AreEqual(1, nDeclenchementTerminee);
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
        [TestMethod]
        public void FiltrerTerminees_TachesABCDavecACterminees_RetourneAC()
        {
            var tacheA = NouvelleTache1erAvrilEntamee(duree: 1, fait: 1);
            var tacheB = NouvelleTache1erAvril(duree: 1);
            var tacheC = NouvelleTache1erAvrilEntamee(duree: 2, fait: 2);
            var tacheD = NouvelleTache1erAvrilEntamee(duree: 2, fait: 1);

            var tachesABCD = new Tache[] { tacheA, tacheB, tacheC, tacheD };
            var attendu = new Tache[] { tacheA, tacheC };
            var obtenu = Tache.FiltrerTerminees(tachesABCD);

            CollectionAssert.AreEqual(attendu, obtenu.ToList());
        }
        private (Tache, IFormatProvider) PreparerTestCSV()
        {
            var tache1erAvril2j = NouvelleTache1erAvril(titre: "Poisson d'avril", duree: 2);
            var stubFormat = Substitute.For<IFormatProvider>();

            stubFormat.GetFormat(Arg.Any<Type>()).Returns(DateTimeFormatInfo.InvariantInfo);
            tache1erAvril2j.Effectuer(_1j_);

            return (tache1erAvril2j, stubFormat);
        }
        [TestMethod]
        public void LigneCSV_Standard_RetourneLigne()
        {
            (var tache1erAvril1jSur2j, var stubFormat) = PreparerTestCSV();
            string attendu = "Poisson d'avril;04/01/2018;2.00:00:00;1.00:00:00;1.00:00:00",
                   obtenu = tache1erAvril1jSur2j.LigneCSV(stubFormat);

            Assert.AreEqual(attendu, obtenu);
        }
        [TestMethod]
        public void FinEstimee_1TierTache3jEn2j_Retourne6jApresDebut()
        {
            var tache1erAvril3j = NouvelleTache1erAvril(duree: 3);
            var stubHorloge = Substitute.For<IHorloge>();

            stubHorloge.Maintenant.Returns(new DateTime(2018, 4, 3));
            tache1erAvril3j.HorlogePourTests = stubHorloge;
            tache1erAvril3j.Effectuer(_1j_);
            Assert.AreEqual(new DateTime(2018, 4, 7), tache1erAvril3j.FinEstimee);
        }
        [TestMethod]
        public void Suivi_2Effectuer_2Appels()
        {
            var mockProgress = Substitute.For<IProgress<TimeSpan>>();
            var tache4j = NouvelleTache1erAvril(duree: 4);

            tache4j.AjouterSuiviProgression(mockProgress);
            tache4j.Effectuer(_2j_);
            tache4j.Effectuer(_1j_);
            mockProgress.Received().Report(_2j_);
            mockProgress.Received().Report(_1j_);
        }
        [TestMethod]
        public void ExporterCSV_Standard_Ecrit1Ligne()
        {
            (var tache1erAvril1jSur2j, var stubFormat) = PreparerTestCSV();
            var attendu = "Poisson d'avril;04/01/2018;2.00:00:00;1.00:00:00;1.00:00:00\r\n";
            var mockStream = Substitute.For<Stream>();

            mockStream.CanWrite.Returns(true);
            tache1erAvril1jSur2j.ExporterCSV(mockStream, stubFormat);
            mockStream.Received().Write(
                Arg.Is<Byte[]>(buffer => Encoding.Default.GetString(buffer).StartsWith(attendu)),
                0,
                attendu.Length
            );
        }
    }
}
