using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ExoTestUnit
namespace TestTaches
{
    [TestClass]
    public class TacheTest
    {
        private readonly TimeSpan _3j = TimeSpan.FromDays(3);
        [TestInitialize]
        public void InitTest()
        {

            var debut = new DateTime(2014, 4, 1);
            var tacheAvril = new Tache("Poisson d'avril", debut, _3j);
      

        }
    }
}
