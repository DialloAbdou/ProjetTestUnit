using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FR_1915_Numeration.Tests
{
    [TestClass]
    public class NumerationTest
    {
        private void AssertEpeler(string attendu, long valeur)
        {
            Assert.AreEqual(attendu, Numeration.Epeler(valeur));
        }
        [TestMethod]
        public void Epeler_0a16_RetourneZeroASeize()
        {
            AssertEpeler("zéro" , 0);
            AssertEpeler("un"   , 1);
            AssertEpeler("deux" , 2);
            AssertEpeler("trois", 3);
            AssertEpeler("quatre", 4);
            AssertEpeler("cinq", 5);
            AssertEpeler("six", 6);
            AssertEpeler("sept", 7);
            AssertEpeler("huit", 8);
            AssertEpeler("neuf", 9);
            AssertEpeler("dix", 10);
            AssertEpeler("onze", 11);
            AssertEpeler("douze", 12);
            AssertEpeler("treize", 13);
            AssertEpeler("quatorze", 14);
            AssertEpeler("quinze", 15);
            AssertEpeler("seize", 16);
        }
        [TestMethod]
        public void Epeler_17a19()
        {
            AssertEpeler("dix-sept", 17);
            AssertEpeler("dix-huit", 18);
            AssertEpeler("dix-neuf", 19);
        }
    }
}
