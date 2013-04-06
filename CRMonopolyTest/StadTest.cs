using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for StadTest and is intended
    ///to contain all StadTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StadTest
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
        ///A test for Stad Constructor
        ///</summary>
        [TestMethod()]
        public void StadConstructorTest()
        {
            string naam = string.Empty; // TODO: Initialize to an appropriate value
            int huisprijs = 0; // TODO: Initialize to an appropriate value
            Stad target = new Stad(naam, huisprijs);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            string naam = string.Empty; // TODO: Initialize to an appropriate value
            int huisprijs = 0; // TODO: Initialize to an appropriate value
            Stad target = new Stad(naam, huisprijs); // TODO: Initialize to an appropriate value
            Straat straat = null; // TODO: Initialize to an appropriate value
            target.Add(straat);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Huisprijs
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void HuisprijsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Stad_Accessor target = new Stad_Accessor(param0); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Huisprijs = expected;
            actual = target.Huisprijs;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Naam
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void NaamTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Stad_Accessor target = new Stad_Accessor(param0); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Naam = expected;
            actual = target.Naam;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Straten
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void StratenTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Stad_Accessor target = new Stad_Accessor(param0); // TODO: Initialize to an appropriate value
            List<Straat> expected = null; // TODO: Initialize to an appropriate value
            List<Straat> actual;
            target.Straten = expected;
            actual = target.Straten;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
