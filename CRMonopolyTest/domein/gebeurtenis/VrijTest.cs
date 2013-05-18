using CRMonopoly.domein.gebeurtenis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for VrijTest and is intended
    ///to contain all VrijTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VrijTest
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
        ///A test for Vrij Constructor
        ///</summary>
        [TestMethod()]
        public void VrijConstructorTest()
        {
            Vrij target = new Vrij();
            Assert.IsNotNull(target, "De instance van de Vrij gebeurtenis mag niet null zijn.");
        }

        /// <summary>
        ///A test for IsVerplicht
        ///</summary>
        [TestMethod()]
        public void IsVerplichtTest()
        {
            Vrij target = new Vrij();
            bool expected = true;
            bool actual = target.IsVerplicht();
            Assert.AreEqual(expected, actual, "De Vrij gebeurtenis is verplicht.");
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTest()
        {
            Vrij target = new Vrij();
            Speler speler = null;
            GebeurtenisResult actual = target.VoerUit(speler);
            Assert.IsNotNull(actual, "De GebeurtenisResult instance mag niet null zijn.");
        }
    }
}
