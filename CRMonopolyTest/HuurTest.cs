using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for HuurTest and is intended
    ///to contain all HuurTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HuurTest
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
        ///A test for GeefTeBetalenHuur
        ///</summary>
        [TestMethod()]
        public void GeefTeBetalenHuurTest()
        {
            int huurOnbebouwd = 0; // TODO: Initialize to an appropriate value
            int huurMet1Huis = 0; // TODO: Initialize to an appropriate value
            int huurMet2Huizen = 0; // TODO: Initialize to an appropriate value
            int huurMet3Huizen = 0; // TODO: Initialize to an appropriate value
            int huurMet4Huizen = 0; // TODO: Initialize to an appropriate value
            int huurMetHotel = 0; // TODO: Initialize to an appropriate value
            Huur target = new Huur(huurOnbebouwd, huurMet1Huis, huurMet2Huizen, huurMet3Huizen, huurMet4Huizen, huurMetHotel); // TODO: Initialize to an appropriate value
            Straat straat = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GeefTeBetalenHuur(straat);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Huur Constructor
        ///</summary>
        [TestMethod()]
        public void HuurConstructorTest()
        {
            int huurOnbebouwd = 0; // TODO: Initialize to an appropriate value
            int huurMet1Huis = 0; // TODO: Initialize to an appropriate value
            int huurMet2Huizen = 0; // TODO: Initialize to an appropriate value
            int huurMet3Huizen = 0; // TODO: Initialize to an appropriate value
            int huurMet4Huizen = 0; // TODO: Initialize to an appropriate value
            int huurMetHotel = 0; // TODO: Initialize to an appropriate value
            Huur target = new Huur(huurOnbebouwd, huurMet1Huis, huurMet2Huizen, huurMet3Huizen, huurMet4Huizen, huurMetHotel);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
