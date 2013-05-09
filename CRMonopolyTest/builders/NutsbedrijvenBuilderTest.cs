using CRMonopoly.builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;

namespace CRMonopolyTest.builders
{
    
    
    /// <summary>
    ///This is a test class for NutsbedrijvenBuilderTest and is intended
    ///to contain all NutsbedrijvenBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class NutsbedrijvenBuilderTest
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
        ///A test for NutsbedrijvenBuilder Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void NutsbedrijvenBuilderConstructorTest()
        {
            NutsbedrijvenBuilder target = NutsbedrijvenBuilder.Instance;
            Assert.IsNotNull(target, "NutsbedrijvenBuilder Instance mag niet null zijn.");
        }

        /// <summary>
        ///A test for NutsBedrijven
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void NutsBedrijvenTest()
        {
            Nutsbedrijven nutsBedrijven = NutsbedrijvenBuilder.Instance.NutsBedrijven;
            Assert.IsNotNull(nutsBedrijven, "De lijst met nutsBedrijven mag niet null zijn.");
            int expectedCnt = 2;
            Assert.IsTrue(expectedCnt == nutsBedrijven.AlleNutsBedrijven.Count,
                String.Format("De aantal nutsbedrijven moet '{0}'  zijn maar is '{1}'.", expectedCnt, nutsBedrijven.AlleNutsBedrijven.Count));
        }
    }
}
