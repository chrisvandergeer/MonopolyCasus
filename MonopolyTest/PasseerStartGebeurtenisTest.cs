using Monopoly.domein.gebeurtenissen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly.domein.velden;
using Monopoly.domein;
using Monopoly.domein.labels;

namespace MonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for PasseerStartGebeurtenisTest and is intended
    ///to contain all PasseerStartGebeurtenisTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PasseerStartGebeurtenisTest
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
        ///A test for Voeruit
        ///</summary>
        [TestMethod()]
        public void VoeruitPasseerStartTest()
        {
            Monopolyspel spel = new Monopolyspel();
            Speler speler = spel.VoegSpelerToe("Speler X");
            int kasgeld = speler.Bezittingen.Kasgeld;
            speler.Positie = spel.Bord.GeefVeld(Veldnamen.DORPSSTRAAT);
            PasseerStartGebeurtenis passeerStart = new PasseerStartGebeurtenis(spel.Bord.GeefVeld(Veldnamen.LEIDSCHESTRAAT));
            passeerStart.Voeruit(speler);
            Assert.AreEqual(kasgeld + 200, speler.Bezittingen.Kasgeld);
        }

        /// <summary>
        ///A test for Voeruit
        ///</summary>
        [TestMethod()]
        public void VoeruitPasseerStartNietTest()
        {
            Monopolyspel spel = new Monopolyspel();
            Speler speler = spel.VoegSpelerToe("Speler X");
            int kasgeld = speler.Bezittingen.Kasgeld;
            speler.Positie = spel.Bord.GeefVeld(Veldnamen.DORPSSTRAAT);
            PasseerStartGebeurtenis passeerStart = new PasseerStartGebeurtenis(spel.Bord.GeefVeld(Veldnamen.START));
            passeerStart.Voeruit(speler);
            Assert.AreEqual(kasgeld, speler.Bezittingen.Kasgeld);
        }

    }
}
