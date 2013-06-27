using CRMonopoly.domein.velden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.AI;

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
            Gebeurtenis gebeurtenis = start.bepaalGebeurtenis(new Speler("Chris", new RiskyStraatKopendePlayerAI()));
            Assert.AreEqual(Start.START_GEBEURTENIS_NAAM, gebeurtenis.Gebeurtenisnaam);
        }

        /// <summary>
        ///A test for Start Constructor
        ///</summary>
        [TestMethod()]
        public void StartConstructorTest()
        {
            Start target = new Start();
            Assert.IsNotNull(target, "Het start veld zou nu geinstantieerd moeten zijn.");
        }
    }
}
