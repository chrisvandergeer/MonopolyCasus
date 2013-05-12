using CRMonopoly.domein.gebeurtenis.creator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for GooiDobbelstenenGebeurteniscreatorTest and is intended
    ///to contain all GooiDobbelstenenGebeurteniscreatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GooiDobbelstenenGebeurteniscreatorTest
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
        ///A test for GooiDobbelstenenGebeurteniscreator Constructor
        ///</summary>
        [TestMethod()]
        public void GooiDobbelstenenGebeurteniscreatorConstructorTest()
        {
            GooiDobbelstenenGebeurtenisCreator target = new GooiDobbelstenenGebeurtenisCreator();
            Assert.IsNotNull(target, "De GooiDobbelstenenGebeurteniscreator instance mag niet null zijn.");
        }

        /// <summary>
        ///A test for IsGebeurtenisVoorSpeler
        ///</summary>
        [TestMethod()]
        public void IsGebeurtenisVoorSpelerTest()
        {
            GooiDobbelstenenGebeurtenisCreator target = new GooiDobbelstenenGebeurtenisCreator();
            Speler speler = null;
            bool actual = target.IsGebeurtenisVoorSpeler(speler);
            Assert.IsTrue(actual, "Standaard moet de GooiDobbelstenen Gebeurtenissen voor de Speler zijn.");
        }

        /// <summary>
        ///A test for MaakGebeurtenis
        ///</summary>
        [TestMethod()]
        public void MaakGebeurtenisTest()
        {
            GooiDobbelstenenGebeurtenisCreator target = new GooiDobbelstenenGebeurtenisCreator();
            Speler speler = null;
            Gebeurtenis actual = target.MaakGebeurtenis(speler);
            Assert.IsNotNull(actual, "De creator moet altijd een valide object teruggeven.");
            Assert.IsTrue(actual is GooiDobbelstenenGebeurtenis, "De creator moet altijd een valide GooiDobbelstenenGebeurtenis teruggeven.");
        }
    }
}
