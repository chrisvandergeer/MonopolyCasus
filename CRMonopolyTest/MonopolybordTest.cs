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
            Worp worp = Worp.GooiDobbelstenen();
            worp.Gedobbeldeworp1 = 1;
            worp.Gedobbeldeworp2 = 1;
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

        /// <summary>
        ///A test for Monopolybord Constructor
        ///</summary>
        [TestMethod()]
        public void MonopolybordConstructorTest()
        {
            Monopolybord target = new Monopolybord();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GeefVeld
        ///</summary>
        [TestMethod()]
        public void GeefVeldTest1()
        {
            Monopolybord target = new Monopolybord(); // TODO: Initialize to an appropriate value
            Veld veld = null; // TODO: Initialize to an appropriate value
            Worp worp = null; // TODO: Initialize to an appropriate value
            Veld expected = null; // TODO: Initialize to an appropriate value
            Veld actual;
            actual = target.GeefVeld(veld, worp);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StartVeld
        ///</summary>
        [TestMethod()]
        public void StartVeldTest1()
        {
            Monopolybord target = new Monopolybord(); // TODO: Initialize to an appropriate value
            Veld expected = null; // TODO: Initialize to an appropriate value
            Veld actual;
            actual = target.StartVeld();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
