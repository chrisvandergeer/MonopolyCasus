using CRMonopoly.domein.gebeurtenis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for OntvangGeldTest and is intended
    ///to contain all OntvangGeldTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OntvangGeldTest
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
        ///A test for OntvangGeld Constructor
        ///</summary>
        [TestMethod()]
        public void OntvangGeldConstructorTest()
        {
            Speler speler = new Speler("Ontvanger");
            int bedrag = 200;
            OntvangGeld target = new OntvangGeld(bedrag);
            Assert.IsNotNull(target, "De gebeurtenis OntvangenGeld zou nu geinstantieerd moeten zijn.");
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTest()
        {
            Speler speler = new Speler("Ontvanger");
            int bedrag = 200;
            OntvangGeld target = new OntvangGeld(bedrag);
            bool expected = true;
            bool actual = target.VoerUit(speler);
            Assert.IsTrue(expected == actual, "De Speler had het geld moet ontvangen.");
            Assert.IsTrue((Speler.SPELER_START_BEDRAG + bedrag) == speler.Geldeenheden,
                String.Format("De Speler had nu {0} aan geld moet hebben, maar hij heeft {1}.", (Speler.SPELER_START_BEDRAG + bedrag), speler.Geldeenheden));
        }
    }
}
