using CRMonopoly.domein.gebeurtenis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for GaNaarGevangenisTest and is intended
    ///to contain all GaNaarGevangenisTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GaNaarGevangenisTest
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
        ///A test for GaNaarGevangenis Constructor
        ///</summary>
        [TestMethod()]
        public void GaNaarGevangenisConstructorTest()
        {
            GaNaarGevangenis target = new GaNaarGevangenis();
            Assert.IsNotNull(target, "GaNaarGevangenis instance mag niet null zijn.");
        }

        /// <summary>
        ///A test for IsVerplicht
        ///</summary>
        [TestMethod()]
        public void IsVerplichtTest()
        {
            GaNaarGevangenis target = new GaNaarGevangenis();
            Assert.IsTrue(target.IsVerplicht(), "GaNaarGevangenis gebeurtenis moet verplicht zijn.");
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTest()
        {
            GaNaarGevangenis target = new GaNaarGevangenis();
            Speler speler = new Speler("GaNaarGevangenis_VoerUitTest_01");
            Monopolyspel spel = new Monopolyspel();
            // Changes after Unity implementation.
            spel.Bord = new Monopolybord();

            spel.Add(speler);
            Veld gevangenis = speler.Bord.GeefVeld(CRMonopoly.domein.velden.Gevangenis.VELD_NAAM);
            GebeurtenisResult actual = target.VoerUit(speler);
            // Checking that the player has ended up in jail.
            Assert.AreEqual(gevangenis, speler.HuidigePositie, "De speler zou nu op Veld Gevangenis moeten staan.");
            Assert.AreEqual(true, speler.InGevangenis, "De speler zou als gevangene geboekt moeten zijn, niet als bezoeker.");
        }

    }
}
