using CRMonopoly.domein.velden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for GevangenisOpBezoekTest and is intended
    ///to contain all GevangenisOpBezoekTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GevangenisOpBezoekTest
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
        ///A test for GevangenisOpBezoek Constructor
        ///</summary>
        [TestMethod()]
        public void GevangenisOpBezoekConstructorTest()
        {
            GevangenisOpBezoek target = new GevangenisOpBezoek();
            Assert.IsNotNull(target, "Het veld Opbezoek in de gevangenis zou nu geinstantieerd moeten zijn.");
        }

        /// <summary>
        ///A test for bepaalGebeurtenis
        ///</summary>
        [TestMethod()]
        public void bepaalGebeurtenisTest()
        {
            GevangenisOpBezoek target = new GevangenisOpBezoek();
            Speler speler = new Speler("TestSpeler");
            string expectedName = Gebeurtenisnamen.VRIJ;
            Gebeurtenis gebeurtenis = target.bepaalGebeurtenis(speler);
            Assert.AreEqual(expectedName, gebeurtenis.Gebeurtenisnaam);
        }
    }
}
