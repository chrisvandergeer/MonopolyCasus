using CRMonopoly.domein.gebeurtenis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein.velden;
using CRMonopoly.domein;

namespace CRMonopolyTest
{
    /// <summary>
    ///This is a test class for GevangenisGebeurtenisTest and is intended
    ///to contain all GevangenisGebeurtenisTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GevangenisGebeurtenisTest
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
            Assert.IsTrue(new GevangenisGebeurtenis(new Gevangenis()).IsVerplicht());
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTest2eBeurtInGevangenis()
        {
            Gevangenis gevangenis = new Gevangenis();
            Speler speler = new Speler("speler", null);
            gevangenis.NieuweGevangene(speler);
            gevangenis.WachtBeurt(speler);
            Assert.IsTrue(new GevangenisGebeurtenis(gevangenis).VoerUit(speler).IsUitgevoerd);
            Assert.IsTrue(gevangenis.IsGevangene(speler));
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTest3eBeurtInGevangenis()
        {
            Gevangenis gevangenis = new Gevangenis();
            Speler speler = new Speler("speler", null);
            gevangenis.NieuweGevangene(speler);
            gevangenis.WachtBeurt(speler);
            gevangenis.WachtBeurt(speler);
            Assert.IsTrue(new GevangenisGebeurtenis(gevangenis).VoerUit(speler).IsUitgevoerd);
            Assert.IsFalse(gevangenis.IsGevangene(speler));
        }

    }
}
