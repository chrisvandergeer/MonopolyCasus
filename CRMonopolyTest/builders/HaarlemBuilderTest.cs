using CRMonopoly.builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;

namespace CRMonopolyTest.builders
{
    
    
    /// <summary>
    ///This is a test class for HaarlemBuilderTest and is intended
    ///to contain all HaarlemBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HaarlemBuilderTest
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
        ///A test for HaarlemBuilder Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void HaarlemBuilderConstructorTest()
        {
            HaarlemBuilder target = HaarlemBuilder.Instance;
            Assert.IsNotNull(target, "HaarlemBuilder Instance mag niet null zijn.");
        }

        /// <summary>
        ///A test for Haarlem
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void HaarlemTest()
        {
            HaarlemBuilder_Accessor target = new HaarlemBuilder_Accessor(); // TODO: Initialize to an appropriate value
            Stad expected = null; // TODO: Initialize to an appropriate value
            Stad actual;
            target.Haarlem = expected;
            actual = target.Haarlem;

            Stad haarlem = HaarlemBuilder.Instance.Haarlem;
            Assert.IsNotNull(haarlem, "De stad Haarlem mag niet null zijn.");
            Assert.AreSame(HaarlemBuilder.HAARLEM, haarlem.Naam,
                String.Format("De naam van haarlem moet '{0}'  zijn maar is '{1}'.", HaarlemBuilder.HAARLEM, haarlem.Naam));
        }
    }
}
