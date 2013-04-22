using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for VeldTest and is intended
    ///to contain all VeldTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VeldTest
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


        internal virtual Veld CreateVeld()
        {
            // TODO: Instantiate an appropriate concrete class.
            return new TestVeld();
        }

        /// <summary>
        ///A test for bepaalGebeurtenis
        ///</summary>
        [TestMethod()]
        public void bepaalGebeurtenisTest()
        {
            Veld target = CreateVeld();
            Speler speler = new Speler("TestSpeler");
            string expectedNaam = "TestGebeurtenis";
            Gebeurtenis actual = target.bepaalGebeurtenis(speler);
            Assert.AreEqual(expectedNaam, actual.Gebeurtenisnaam);
        }

        /// <summary>
        ///A test for Naam
        ///</summary>
        [TestMethod()]
        public void NaamTest()
        {
            Veld target = CreateVeld();
            string expected = "TestVeld";
            target.Naam = expected;
            string actual = target.Naam;
            Assert.AreEqual(expected, actual);
        }
    }

    class TestVeld : Veld
    {
        internal TestVeld() : base("TestVeld") {
        }
        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            return new TestGebeurtenis();
        }

    }
    class TestGebeurtenis : AbstractGebeurtenis
    {
        internal TestGebeurtenis()
            : base("TestGebeurtenis") { }
        
        public override bool VoerUit(Speler speler)
        {
            return true;
        }
        public override bool IsVerplicht()
        {
            return false;
        }

    }
}
