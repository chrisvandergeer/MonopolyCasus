using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CRMonopolyTest
{

    /// <summary>
    ///This is a test class for MonopolybordTest and is intended
    ///to contain all MonopolybordTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MonopolybordTest
    { 

        /// <summary>
        ///A test for GeefVeld
        ///</summary>
        [TestMethod()]
        public void GeefVeldTest()
        {
            Monopolybord bord = new Monopolybord();
            Veld start = bord.StartVeld();
            Worp worp = new Worp() { Gedobbeldeworp1 = 1, Gedobbeldeworp2 = 1 };
            Veld veld = bord.GeefVeld(start, worp);
            Assert.AreEqual("Leidsestraat", veld.Naam);
        }

        /// <summary>
        ///A test for StartVeld
        ///</summary>
        [TestMethod()]
        public void StartVeldTest()
        {
            Assert.AreEqual("Start", new Monopolybord().StartVeld().Naam);
        }
    }
}
