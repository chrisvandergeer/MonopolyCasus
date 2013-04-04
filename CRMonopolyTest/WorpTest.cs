using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for WorpTest and is intended
    ///to contain all WorpTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WorpTest
    {
        /// <summary>
        ///A test for GooiDobbelstenen
        ///</summary>
        [TestMethod()]
        public void GooiDobbelstenenTest()
        {
            Worp worp = Worp.GooiDobbelstenen();
            Assert.IsNotNull(worp.ToString());
        }

        /// <summary>
        ///A test for Totaal
        ///</summary>
        [TestMethod()]
        public void TotaalTest()
        {
            Worp worp = Worp.GooiDobbelstenen();
            Assert.AreEqual(worp.Totaal(), worp.Gedobbeldeworp1 + worp.Gedobbeldeworp2);
        }

        /// <summary>
        ///A test for isDubbelGegooid
        ///</summary>
        [TestMethod()]
        public void isDubbelGegooidTest()
        {
            Worp worp = Worp.GooiDobbelstenen();
            while (!worp.isDubbelGegooid())
            {
                worp = Worp.GooiDobbelstenen();
            }
            Assert.AreEqual(worp.Gedobbeldeworp1, worp.Gedobbeldeworp2);
        }

        /// <summary>
        ///A test for isDubbelGegooid
        ///</summary>
        [TestMethod()]
        public void isDubbelGegooidTestNietDubbel()
        {
            Worp worp = Worp.GooiDobbelstenen();
            while (worp.isDubbelGegooid())
            {
                worp = Worp.GooiDobbelstenen();
            }
            Assert.AreNotEqual(worp.Gedobbeldeworp1, worp.Gedobbeldeworp2);
        }

    }
}
