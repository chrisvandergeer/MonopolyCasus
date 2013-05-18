using CRMonopoly.builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;

namespace CRMonopolyTest.builders
{
    
    
    /// <summary>
    ///This is a test class for OnsDorpBuilderTest and is intended
    ///to contain all OnsDorpBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OnsDorpBuilderTest
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
        ///A test for OnsDorpBuilder Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void OnsDorpBuilderConstructorTest()
        {
            OnsDorpBuilder target = OnsDorpBuilder.Instance;
            Assert.IsNotNull(target, "OnsDorpBuilder Instance mag niet null zijn.");
        }

        /// <summary>
        ///A test for OnsDorp
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void OnsDorpTest()
        {
            Stad onsDorp = OnsDorpBuilder.Instance.OnsDorp;
            Assert.IsNotNull(onsDorp, "De stad OnsDorp mag niet null zijn.");
            Assert.AreSame(OnsDorpBuilder.ONS_DORP, onsDorp.Naam,
                String.Format("De naam van OnsDorp moet '{0}'  zijn maar is '{1}'.", OnsDorpBuilder.ONS_DORP, onsDorp.Naam));
        }
    }
}
