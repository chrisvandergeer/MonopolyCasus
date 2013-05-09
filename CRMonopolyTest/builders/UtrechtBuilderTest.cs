using CRMonopoly.builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;

namespace CRMonopolyTest.builders
{
    
    
    /// <summary>
    ///This is a test class for UtrechtBuilderTest and is intended
    ///to contain all UtrechtBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UtrechtBuilderTest
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
        ///A test for UtrechtBuilder Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void UtrechtBuilderConstructorTest()
        {
            UtrechtBuilder target = UtrechtBuilder.Instance;
            Assert.IsNotNull(target, "UtrechtBuilder Instance mag niet null zijn.");
        }

        /// <summary>
        ///A test for Utrecht
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void UtrechtTest()
        {
            Stad utrecht = UtrechtBuilder.Instance.Utrecht;
            Assert.IsNotNull(utrecht, "De stad Utrecht mag niet null zijn.");
            Assert.AreSame(UtrechtBuilder.UTRECHT, utrecht.Naam,
                String.Format("De naam van utrecht moet '{0}'  zijn maar is '{1}'.", UtrechtBuilder.UTRECHT, utrecht.Naam));
        }
    }
}
