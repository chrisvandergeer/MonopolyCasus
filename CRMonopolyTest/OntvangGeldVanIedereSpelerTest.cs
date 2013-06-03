using CRMonopoly.domein.gebeurtenis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for OntvangGeldVanIedereSpelerTest and is intended
    ///to contain all OntvangGeldVanIedereSpelerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OntvangGeldVanIedereSpelerTest
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
        ///A test for IsVerplicht
        ///</summary>
        [TestMethod()]
        public void IsVerplichtTest()
        {
            Assert.IsTrue(new OntvangGeldVanIedereSpeler(new Monopolyspel(), 0).IsVerplicht());
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTest()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.Bord = new Monopolybord();
            Speler piet = new Speler("Piet");
            spel.Add(piet);
            spel.Add(new Speler("Klaas"));
            spel.Add(new Speler("Jan"));
            spel.Add(new Speler("Karel"));
            Assert.AreEqual(4, spel.Spelers.FindAll(speler => speler.Geldeenheden == 1500).Count);
            new OntvangGeldVanIedereSpeler(spel, 100).VoerUit(piet);
            Assert.AreEqual(3, spel.Spelers.FindAll(speler => speler.Geldeenheden == 1400).Count);
            Assert.AreEqual(1800, piet.Geldeenheden);
        }
    }
}
