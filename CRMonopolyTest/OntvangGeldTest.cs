using CRMonopoly.domein.gebeurtenis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for OntvangGeldTest and is intended
    ///to contain all OntvangGeldTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OntvangGeldTest
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
        ///A test for OntvangGeld Constructor
        ///</summary>
        [TestMethod()]
        public void OntvangGeldConstructorTest()
        {
            Speler speler = null; // TODO: Initialize to an appropriate value
            int bedrag = 0; // TODO: Initialize to an appropriate value
            OntvangGeld target = new OntvangGeld(speler, bedrag);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Gebeurtenisnaam
        ///</summary>
        [TestMethod()]
        public void GebeurtenisnaamTest()
        {
            Speler speler = null; // TODO: Initialize to an appropriate value
            int bedrag = 0; // TODO: Initialize to an appropriate value
            OntvangGeld target = new OntvangGeld(speler, bedrag); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Gebeurtenisnaam();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsVerplicht
        ///</summary>
        [TestMethod()]
        public void IsVerplichtTest()
        {
            Speler speler = null; // TODO: Initialize to an appropriate value
            int bedrag = 0; // TODO: Initialize to an appropriate value
            OntvangGeld target = new OntvangGeld(speler, bedrag); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsVerplicht();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTest()
        {
            Speler speler = null; // TODO: Initialize to an appropriate value
            int bedrag = 0; // TODO: Initialize to an appropriate value
            OntvangGeld target = new OntvangGeld(speler, bedrag); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.VoerUit();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Bedrag
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void BedragTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            OntvangGeld_Accessor target = new OntvangGeld_Accessor(param0); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Bedrag = expected;
            actual = target.Bedrag;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Geldontvanger
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void GeldontvangerTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            OntvangGeld_Accessor target = new OntvangGeld_Accessor(param0); // TODO: Initialize to an appropriate value
            Speler expected = null; // TODO: Initialize to an appropriate value
            Speler actual;
            target.Geldontvanger = expected;
            actual = target.Geldontvanger;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
