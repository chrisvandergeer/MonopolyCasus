using CRMonopoly.builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;

namespace CRMonopolyTest.builders
{
    
    
    /// <summary>
    ///This is a test class for KansEnAlgemeenFondsVeldBuilderTest and is intended
    ///to contain all KansEnAlgemeenFondsVeldBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class KansEnAlgemeenFondsVeldBuilderTest
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
        ///A test for KansEnAlgemeenFondsVeldBuilder Constructor
        ///</summary>
        [TestMethod()]
        public void KansEnAlgemeenFondsVeldBuilderConstructorTest()
        {
            KansEnAlgemeenFondsVeldBuilder target = KansEnAlgemeenFondsVeldBuilder.Instance;
            Assert.IsNotNull(target, "KansEnAlgemeenFondsVeldBuilder Instance mag niet null zijn.");
        }

        /// <summary>
        ///A test for getAlgemeenFondsVeld
        ///</summary>
        [TestMethod()]
        public void getAlgemeenFondsVeldTest()
        {
            Veld algemeenFondsVeld01 = KansEnAlgemeenFondsVeldBuilder.Instance.getAlgemeenFondsVeld(null);
            Assert.IsNotNull(algemeenFondsVeld01, "AlgemeenFondsVeld mag niet null zijn.");
            Assert.AreSame(KansEnAlgemeenFondsVeldBuilder.ALGEMEEN_FONDS_NAAM, algemeenFondsVeld01.Naam,
                String.Format("De naam van het algemeenfonds veld moet '{0}' zijn maar is '{1}'.", 
                    KansEnAlgemeenFondsVeldBuilder.ALGEMEEN_FONDS_NAAM, algemeenFondsVeld01.Naam));
            // Checking that a next veld is not the same instance as the first.
            Veld algemeenFondsVeld02 = KansEnAlgemeenFondsVeldBuilder.Instance.getAlgemeenFondsVeld(null);
            Assert.IsNotNull(algemeenFondsVeld02, "AlgemeenFondsVeld mag niet null zijn.");
            Assert.AreNotSame(algemeenFondsVeld01, algemeenFondsVeld02,
                "De twee instances van het algemeenfonds veld moet verschillende instances zijn, maar ze zijn dezelfde instance.");
        }

        /// <summary>
        ///A test for getKansVeld
        ///</summary>
        [TestMethod()]
        public void getKansVeldTest()
        {
            Veld kansVeld01 = KansEnAlgemeenFondsVeldBuilder.Instance.getKansVeld(null);
            Assert.IsNotNull(kansVeld01, "KansVeld mag niet null zijn.");
            Assert.AreSame(KansEnAlgemeenFondsVeldBuilder.KANS_NAAM, kansVeld01.Naam,
                String.Format("De naam van het kans veld moet '{0}' zijn maar is '{1}'.",
                    KansEnAlgemeenFondsVeldBuilder.KANS_NAAM, kansVeld01.Naam));
            // Checking that a next veld is not the same instance as the first.
            Veld kansVeld02 = KansEnAlgemeenFondsVeldBuilder.Instance.getKansVeld(null);
            Assert.IsNotNull(kansVeld02, "KansVeld mag niet null zijn.");
            Assert.AreNotSame(kansVeld01, kansVeld02,
                "De twee instances van het kans veld moet verschillende instances zijn, maar ze zijn dezelfde instance.");
        }
    }
}
