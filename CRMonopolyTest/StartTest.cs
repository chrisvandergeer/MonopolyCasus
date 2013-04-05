using CRMonopoly.domein.velden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for StartTest and is intended
    ///to contain all StartTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StartTest
    {
        /// <summary>
        ///A test for bepaalGebeurtenis
        ///</summary>
        [TestMethod()]
        public void bepaalGebeurtenisTest()
        {
            Start start = new Start();
            Gebeurtenis gebeurtenis = start.bepaalGebeurtenis(new Speler("Chris"));
            Assert.AreEqual("Ontvang geld", gebeurtenis.Gebeurtenisnaam());
        }
    }
}
