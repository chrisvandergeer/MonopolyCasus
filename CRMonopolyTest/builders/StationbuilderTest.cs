using CRMonopoly.builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein.velden;
using System.Collections.Generic;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for StationbuilderTest and is intended
    ///to contain all StationbuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StationbuilderTest
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
        ///A test for Noord
        ///</summary>
        [TestMethod()]
        public void NoordTest()
        {
            Assert.AreEqual("Station Noord", Stationbuilder.Instance.Noord().Naam);
        }

        /// <summary>
        ///A test for Oost
        ///</summary>
        [TestMethod()]
        public void OostTest()
        {
            Assert.AreEqual("Station Oost", Stationbuilder.Instance.Oost().Naam);
        }

        /// <summary>
        ///A test for West
        ///</summary>
        [TestMethod()]
        public void WestTest()
        {
            Assert.AreEqual("Station West", Stationbuilder.Instance.West().Naam);
        }

        /// <summary>
        ///A test for Zuid
        ///</summary>
        [TestMethod()]
        public void ZuidTest()
        {
            Assert.AreEqual("Station Zuid", Stationbuilder.Instance.Zuid().Naam);
        }

        /// <summary>
        ///A test for Stations
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void StationsTest()
        {
            Assert.AreEqual(4, Stationbuilder.Instance.Noord().Stations.Count);
        }
    }
}
