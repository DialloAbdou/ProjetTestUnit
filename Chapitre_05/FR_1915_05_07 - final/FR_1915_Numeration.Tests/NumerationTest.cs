using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FR_1915_Numeration.Tests
{
    [TestClass]
    public class NumerationTest
    {
        private void AssertEpeler(string attendu, long nombre, OptionNumeration options = 0)
        {
            Numeration test = new Numeration(options);

            Assert.AreEqual(attendu, test.Epeler(nombre));
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
        [TestMethod]
        public void Epeler_20a99()
        {
            AssertEpeler("vingt", 20);
            AssertEpeler("vingt-trois", 23);
            AssertEpeler("trente-six", 36);
            AssertEpeler("quarante-deux", 42);
            AssertEpeler("cinquante-huit", 58);
            AssertEpeler("soixante-neuf", 69);
            AssertEpeler("septante-sept", 77);
            AssertEpeler("huitante-cinq", 85);
            AssertEpeler("nonante-quatre", 94);
        }
        [TestMethod]
        public void Epeler_DizainesTermineesPar1()
        {
            AssertEpeler("vingt-et-un", 21);
            AssertEpeler("septante-et-un", 71);
            AssertEpeler("huitante-et-un", 81);
        }
        [TestMethod]
        public void Epeler_100a199()
        {
            AssertEpeler("cent", 100);
            AssertEpeler("cent-vingt-trois", 123);
        }
        [TestMethod]
        public void Epeler_200a999()
        {
            AssertEpeler("deux-cents", 200);
            AssertEpeler("deux-cent-vingt-trois", 223);
            AssertEpeler("neuf-cents", 900);
            AssertEpeler("neuf-cent-nonante-neuf", 999);
        }

        [TestMethod]
        public void Epeler_Milliers()
        {
            AssertEpeler("mille-cinquante", 1050);
            AssertEpeler("deux-mille", 2000);
            AssertEpeler("quatorze-mille-trois-cents", 14300);
            AssertEpeler("deux-cents-mille-six-cents", 200600);
        }
        [TestMethod]
        public void Epeler_MillionsATrillions()
        {
            AssertEpeler("un-million"                ,                 1_000_000);
            AssertEpeler("deux-cents-milliards-quatre-millions-treize-mille-six-cent-cinquante"
                                                     ,           200_004_013_650);
            AssertEpeler("quatre-cent-douze-billions",       412_000_000_000_000);
            AssertEpeler("vingt-et-un-billiards"     ,    21_000_000_000_000_000);
            AssertEpeler("trois-trillions"           , 3_000_000_000_000_000_000);
        }
        [TestMethod]
        public void Epeler_SoixanteDixQuatreVingtQuatreVingtDix()
        {
            AssertEpeler("soixante-et-onze"             ,         71, OptionNumeration.SoixanteDix);
            AssertEpeler("deux-cent-quatre-vingts"      ,        280, OptionNumeration.QuatreVingts);
            AssertEpeler("quatre-vingt-un-mille"        ,     81_000, OptionNumeration.QuatreVingts);
            AssertEpeler("quatre-vingt-quatre-millions" , 84_000_000, OptionNumeration.QuatreVingts);
            AssertEpeler("nonante-et-un"                ,         91, OptionNumeration.QuatreVingts);
            AssertEpeler("douze-mille-quatre-vingt-onze",     12_091, OptionNumeration.QuatreVingtDix);
            AssertEpeler("quatre-vingt-dix-neuf"        ,         99, OptionNumeration.QuatreVingtDix);
        }
    }
}
