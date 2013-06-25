using CRMonopoly.domein.gebeurtenis.creator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using System.Collections;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for GebeurtenissenCreatorTest and is intended
    ///to contain all GebeurtenissenCreatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GebeurtenissenCreatorTest
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
        ///A test for GebeurtenissenCreator Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void GebeurtenissenCreatorConstructorTest()
        {
            GebeurtenissenCreator target = GebeurtenissenCreator.Instance();
            Assert.IsNotNull(target, "De GebeurtenissenCreator Instance mag niet null zijn.");
        }

        /// <summary>
        ///A test for createGebeurtenissen
        ///</summary>
        [TestMethod()]
        public void createGebeurtenissenTest()
        {
            int aantalGebeurtenissen = 1;
            Speler speler = new Speler("GebeurtenissenCreatorTest_createGebeurtenissenTest_01", null);
            Gebeurtenissen actual = GebeurtenissenCreator.Instance().createGebeurtenissen(speler);
            Assert.IsNotNull(actual, "De lijst gebeurtenissen mag niet null zijn.");
            int cntGebeurtenissen = actual.GebeurtenissenCount();
            Assert.IsTrue(cntGebeurtenissen >= aantalGebeurtenissen,
                String.Format("Het aantal gebeurtenissen is minder dan verwacht. ({0}).", cntGebeurtenissen));
        }
    }
}
