using CRMonopoly.builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;

namespace CRMonopolyTest.builders
{
    
    
    /// <summary>
    ///This is a test class for RotterdamBuilderTest and is intended
    ///to contain all RotterdamBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RotterdamBuilderTest
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
        ///A test for RotterdamBuilder Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void RotterdamBuilderConstructorTest()
        {
            RotterdamBuilder target = RotterdamBuilder.Instance;
            Assert.IsNotNull(target, "RotterdamBuilder Instance mag niet null zijn.");
        }

        /// <summary>
        ///A test for Rotterdam
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void RotterdamTest()
        {
            Stad rotterdam = RotterdamBuilder.Instance.Rotterdam;
            Assert.IsNotNull(rotterdam, "De stad Rotterdam mag niet null zijn.");
            Assert.AreSame(RotterdamBuilder.ROTTERDAM, rotterdam.Naam,
                String.Format("De naam van rotterdam moet '{0}'  zijn maar is '{1}'.", RotterdamBuilder.ROTTERDAM, rotterdam.Naam));
        }
    }
}
