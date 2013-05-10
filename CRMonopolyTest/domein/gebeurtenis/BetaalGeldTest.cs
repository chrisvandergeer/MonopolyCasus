using CRMonopoly.domein.gebeurtenis.kans;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for BetaalGeldTest and is intended
    ///to contain all BetaalGeldTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BetaalGeldTest
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
        ///A test for BetaalGeld Constructor
        ///</summary>
        [TestMethod()]
        public void BetaalGeldConstructorTest()
        {
            int bedrag = 110;
            string gebeurtenisnaam = "BetaalGeldConstructorTest";
            BetaalGeld target = new BetaalGeld(bedrag, gebeurtenisnaam);
            Assert.IsNotNull(target, "De BetaalGeld gebeurtenis instance mag niet null zijn.");
        }

        //TODO: BetaalGeldTest verder implementeren.

        ///// <summary>
        /////A test for IsVerplicht
        /////</summary>
        //[TestMethod()]
        //public void IsVerplichtTest()
        //{
        //    int bedrag = 0; // TODO: Initialize to an appropriate value
        //    string gebeurtenisnaam = string.Empty; // TODO: Initialize to an appropriate value
        //    BetaalGeld target = new BetaalGeld(bedrag, gebeurtenisnaam); // TODO: Initialize to an appropriate value
        //    bool expected = false; // TODO: Initialize to an appropriate value
        //    bool actual;
        //    actual = target.IsVerplicht();
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for VoerUit
        /////</summary>
        //[TestMethod()]
        //public void VoerUitTest()
        //{
        //    int bedrag = 0; // TODO: Initialize to an appropriate value
        //    string gebeurtenisnaam = string.Empty; // TODO: Initialize to an appropriate value
        //    BetaalGeld target = new BetaalGeld(bedrag, gebeurtenisnaam); // TODO: Initialize to an appropriate value
        //    Speler speler = null; // TODO: Initialize to an appropriate value
        //    GebeurtenisResult expected = null; // TODO: Initialize to an appropriate value
        //    GebeurtenisResult actual;
        //    actual = target.VoerUit(speler);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for Bedrag
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem("CRMonopoly.exe")]
        //public void BedragTest()
        //{
        //    PrivateObject param0 = null; // TODO: Initialize to an appropriate value
        //    BetaalGeld_Accessor target = new BetaalGeld_Accessor(param0); // TODO: Initialize to an appropriate value
        //    int expected = 0; // TODO: Initialize to an appropriate value
        //    int actual;
        //    target.Bedrag = expected;
        //    actual = target.Bedrag;
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}
    }
}
