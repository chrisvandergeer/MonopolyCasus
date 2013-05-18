using CRMonopoly.builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;

namespace CRMonopolyTest.builders
{
    
    
    /// <summary>
    ///This is a test class for GroningenBuilderTest and is intended
    ///to contain all GroningenBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GroningenBuilderTest
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
        ///A test for GroningenBuilder Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void GroningenBuilderConstructorTest()
        {
            GroningenBuilder target = GroningenBuilder.Instance;
            Assert.IsNotNull(target, "GroningenBuilder Instance mag niet null zijn.");
        }

        /// <summary>
        ///A test for Groningen
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void GroningenTest()
        {
            Stad groningen = GroningenBuilder.Instance.Groningen;
            Assert.IsNotNull(groningen, "De stad Groningen mag niet null zijn.");
            Assert.AreSame(GroningenBuilder.GRONINGEN, groningen.Naam,
                String.Format("De naam van amsterdam moet '{0}'  zijn maar is '{1}'.", GroningenBuilder.GRONINGEN, groningen.Naam));
        }
    }
}
