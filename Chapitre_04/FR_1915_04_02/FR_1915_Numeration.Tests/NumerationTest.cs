using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FR_1915_Numeration.Tests
{
    [TestClass]
    public class NumerationTest
    {
        [TestMethod]
        public void Epeler_0_RetourneZero()
        {
            Assert.AreEqual("zéro", Numeration.Epeler(0));
        }
    }
}
