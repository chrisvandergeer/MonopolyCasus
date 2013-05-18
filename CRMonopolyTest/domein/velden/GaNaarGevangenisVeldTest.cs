using CRMonopoly.domein.velden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for GaNaarGevangenisVeldTest and is intended
    ///to contain all GaNaarGevangenisVeldTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GaNaarGevangenisVeldTest
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
        ///A test for GaNaarGevangenisVeld Constructor
        ///</summary>
        [TestMethod()]
        public void GaNaarGevangenisVeldConstructorTest()
        {
            GaNaarGevangenisVeld target = new GaNaarGevangenisVeld();
            Assert.IsNotNull(target, "De GaNaarGevangenisVeld instance mag niet null zijn.");
        }

        /// <summary>
        ///A test for bepaalGebeurtenis
        ///</summary>
        [TestMethod()]
        public void bepaalGebeurtenisTest()
        {
            GaNaarGevangenisVeld target = new GaNaarGevangenisVeld();
            Speler speler = new Speler("GaNaarGevangenisVeldTest_bepaalGebeurtenisTest_01");
            Gebeurtenis actual = target.bepaalGebeurtenis(speler);
            Assert.IsNotNull(actual, "De Gebeurtenis 'GaNaarGevangenis' mag niet null zijn.");
            Assert.IsTrue(actual is GaNaarGevangenis, "De voeruit methode moet een GaNaarGevangenis gebeurtenis teruggeven.");
        }
    }
}
