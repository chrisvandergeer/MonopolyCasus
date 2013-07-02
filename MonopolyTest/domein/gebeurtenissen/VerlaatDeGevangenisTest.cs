using Monopoly.domein.gebeurtenissen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly.domein;
using Monopoly.domein.labels;

namespace MonopolyTest.domein.gebeurtenissen
{
    
    
    /// <summary>
    ///This is a test class for VerlaatDeGevangenisTest and is intended
    ///to contain all VerlaatDeGevangenisTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VerlaatDeGevangenisTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for VerlaatDeGevangenis Constructor
        ///</summary>
        [TestMethod()]
        public void VerlaatDeGevangenisConstructorTest()
        {
            VerlaatDeGevangenis target = new VerlaatDeGevangenis();
            Assert.IsNotNull("VerlaatGevangenis zou nu geinstantieerd moeten zijn.");
        }

        /// <summary>
        ///A test for IsUitvoerbaar
        ///</summary>
        [TestMethod()]
        public void IsUitvoerbaarTest_01()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Bord = new Spelbord();
            spel.VoegSpelerToe("GaNaarDeGevangenis_01");
            Speler speler = spel.Spelers[0];
            VerplaatsSpeler.CreateVerplaatsVooruit("Testing_01", spel.Bord.GeefVeld(Veldnamen.STATION_NOORD)).Voeruit(speler);
            Assert.AreEqual(Veldnamen.STATION_NOORD, speler.Positie.Naam, "Speler zou nu op Station noord moeten staan.");
            VerplaatsSpeler.CreateVerplaatsVooruit("Testing_02", 5).Voeruit(speler);
            Assert.AreEqual(Veldnamen.GEVANGENIS, speler.Positie.Naam, "Speler zou nu op Gevangenis moeten staan.");
            VerlaatDeGevangenis target = new VerlaatDeGevangenis();
            Assert.IsTrue(target.IsUitvoerbaar(speler), "De Verlaat gevangenis gebeurtenis zou nu uit te voeren moeten zijn.");
        }

        ///// <summary>
        /////A test for IsVerplicht
        /////</summary>
        //[TestMethod()]
        //public void IsVerplichtTest()
        //{
        //    VerlaatDeGevangenis target = new VerlaatDeGevangenis(); // TODO: Initialize to an appropriate value
        //    bool expected = false; // TODO: Initialize to an appropriate value
        //    bool actual;
        //    actual = target.IsVerplicht();
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for Voeruit
        /////</summary>
        //[TestMethod()]
        //public void VoeruitTest()
        //{
        //    VerlaatDeGevangenis target = new VerlaatDeGevangenis(); // TODO: Initialize to an appropriate value
        //    Speler speler = null; // TODO: Initialize to an appropriate value
        //    target.Voeruit(speler);
        //    Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}
    }
}
