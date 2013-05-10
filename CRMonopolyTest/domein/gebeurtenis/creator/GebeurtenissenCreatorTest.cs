using CRMonopoly.domein.gebeurtenis.creator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

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

        // TODO: GebeurtenissenCreatorTest verder implementeren.

        ///// <summary>
        /////A test for Instance
        /////</summary>
        //[TestMethod()]
        //public void InstanceTest()
        //{
        //    GebeurtenissenCreator expected = null; // TODO: Initialize to an appropriate value
        //    GebeurtenissenCreator actual;
        //    actual = GebeurtenissenCreator.Instance();
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for createGebeurtenissen
        /////</summary>
        //[TestMethod()]
        //public void createGebeurtenissenTest()
        //{
        //    GebeurtenissenCreator_Accessor target = new GebeurtenissenCreator_Accessor(); // TODO: Initialize to an appropriate value
        //    Speler speler = null; // TODO: Initialize to an appropriate value
        //    Gebeurtenissen expected = null; // TODO: Initialize to an appropriate value
        //    Gebeurtenissen actual;
        //    actual = target.createGebeurtenissen(speler);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}
    }
}
