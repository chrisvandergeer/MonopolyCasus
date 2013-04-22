using CRMonopoly.domein.gebeurtenis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.builders;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for KoopStraatTest and is intended
    ///to contain all KoopStraatTest Unit Tests
    ///</summary>
    [TestClass()]
    public class KoopStraatTest
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
        ///A test for KoopStraat Constructor
        ///</summary>
        [TestMethod()]
        public void KoopStraatConstructorTest()
        {
            Speler koper = new Speler("koper");
            Straat straat = AmsterdamBuilder.Instance.Amsterdam.getStraatByIndex(0);
            KoopStraat target = new KoopStraat(straat);
            Assert.IsNotNull(target, "Het KoopStraat object mag niet nul zijn.");
        }

        /// <summary>
        ///A test for Gebeurtenisnaam
        ///</summary>
        [TestMethod()]
        public void GebeurtenisnaamTest()
        {
            Speler koper = new Speler("koper");
            Straat straat = AmsterdamBuilder.Instance.Amsterdam.getStraatByIndex(0);
            KoopStraat target = new KoopStraat(straat);
            string expected = Gebeurtenisnamen.KOOP_STRAAT;
            string actual = target.Gebeurtenisnaam;
            Assert.AreSame(expected, actual, String.Format("De naam van de KopStraat is niet als verwacht (Exp: {0}, Act: {1}).", expected, actual));
        }

        //        /// <summary>
        //        ///A test for IsVerplicht
        //        ///</summary>
        //        [TestMethod()]
        //        public void IsVerplichtTest()
        //        {
        //            // Testing not needed
        //        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTest()
        {
            Speler koper = new Speler("koper");
            Straat straat = AmsterdamBuilder.Instance.Amsterdam.getStraatByIndex(0);
            KoopStraat target = new KoopStraat(straat);
            bool expected = true;
            bool actual = target.VoerUit(koper);
            Assert.IsTrue(expected == actual, "De koper moet de straat kunnen komen.");
        }
    }
}
