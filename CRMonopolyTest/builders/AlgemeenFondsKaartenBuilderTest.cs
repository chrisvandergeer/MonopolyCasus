using CRMonopoly.builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein.gebeurtenis;
using System.Collections.Generic;
using CRMonopoly.domein;

namespace CRMonopolyTest.builders
{
    
    
    /// <summary>
    ///This is a test class for AlgemeenFondsKaartenBuilderTest and is intended
    ///to contain all AlgemeenFondsKaartenBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AlgemeenFondsKaartenBuilderTest
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
        ///A test for AlgemeenFondsKaartenBuilder Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void AlgemeenFondsKaartenBuilderConstructorTest()
        {
            AlgemeenFondsKaartenBuilder target = AlgemeenFondsKaartenBuilder.Instance;
            Assert.IsNotNull(target, "De AlgemeenFondsKaartenBuilder instance mag niet null zijn.");
        }

        /// <summary>
        ///A test for getStapelKaarten
        ///</summary>
        [TestMethod()]
        public void getStapelKaartenTest()
        {
            List<Gebeurtenis> actual = AlgemeenFondsKaartenBuilder.Instance.getStapelKaarten();
            Assert.IsNotNull(actual, "De stapel kaarten mag niet null zijn.");
            // At the moment we limit the number of card to 11.
            // There will be twelf to start, but the VerlaatGevangenis card will have been moved to the player.
            int expectedMinimumCount = 11;
            Assert.IsTrue(actual.Count >= expectedMinimumCount, String.Format("De stapel kaarten moet meer dan {0} kaarten bevatten, maar er zijn er maar {1}."
                , 12, actual.Count));
        }
    }
}
