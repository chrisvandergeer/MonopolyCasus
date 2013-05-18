using CRMonopoly.builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;

namespace CRMonopolyTest.builders
{
    
    
    /// <summary>
    ///This is a test class for BelastingVeldenBuilderTest and is intended
    ///to contain all BelastingVeldenBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BelastingVeldenBuilderTest
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
        ///A test for BelastingVeldenBuilder Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void BelastingVeldenBuilderConstructorTest()
        {
            BelastingVeldenBuilder target = BelastingVeldenBuilder.Instance;
            Assert.IsNotNull(target, "BelastingVeldenBuilder Instance mag niet null zijn.");
        }

        /// <summary>
        ///A test for BelastingVelden
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void BelastingVeldenTest()
        {
            Stad amsterdam = AmsterdamBuilder.Instance.Amsterdam;
            Assert.IsNotNull(BelastingVeldenBuilder.Instance.BelastingVelden, "De BelastingVelden lijst mag niet null zijn.");
            int expectedCnt = 2;
            Assert.IsTrue(expectedCnt == BelastingVeldenBuilder.Instance.BelastingVelden.AlleBelastingVelden.Count,
                String.Format("Het aantal belastingvelden moet {0} zijn, maar is {1}.", expectedCnt, 
                        BelastingVeldenBuilder.Instance.BelastingVelden.AlleBelastingVelden.Count));
        }
    }
}
