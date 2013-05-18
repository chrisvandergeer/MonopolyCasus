using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for HuurTest and is intended
    ///to contain all HuurTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HuurTest
    {


        private TestContext testContextInstance;
        private int huurOnbebouwd = 10;
        private int huurMet1Huis = 20;
        private int huurMet2Huizen = 30;
        private int huurMet3Huizen = 40;
        private int huurMet4Huizen = 50;
        private int huurMetHotel = 60;

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
        ///A test for GeefTeBetalenHuur
        ///</summary>
        [TestMethod()]
        public void GeefTeBetalenHuurOnbebouwdTest()
        {
            Huur target = new Huur(huurOnbebouwd, huurMet1Huis, huurMet2Huizen, huurMet3Huizen, huurMet4Huizen, huurMetHotel);
            Straat straat = new Straat("straat", 150, target);
            int expected = huurOnbebouwd;
            int actual = target.GeefTeBetalenHuur(straat);
            Assert.AreEqual(expected, actual, string.Format("De initiele huur zou {0} moeten zijn, niet {1}", expected, actual));
        }

        /// <summary>
        ///A test for GeefTeBetalenHuur
        ///</summary>
        [TestMethod()]
        public void GeefTeBetalenHuurBebouwdTest()
        {
            Huur target = new Huur(huurOnbebouwd, huurMet1Huis, huurMet2Huizen, huurMet3Huizen, huurMet4Huizen, huurMetHotel);
            Stad stad = new Stad("Stad", 1);
            Straat straat = new Straat("straat", 150, target);
            Speler speler = new Speler("Eigenaar");
            straat.Eigenaar = speler;
            stad.Add(straat);
            straat.KoopHuis();
            int expected = huurMet1Huis;
            int actual = target.GeefTeBetalenHuur(straat);
            Assert.AreEqual(expected, actual, string.Format("De huur met 1 huis zou {0} moeten zijn, niet {1}", expected, actual));
            // Adding another house
            straat.KoopHuis();
            expected = huurMet2Huizen;
            actual = target.GeefTeBetalenHuur(straat);
            Assert.AreEqual(expected, actual, string.Format("De huur met 2 huizen zou {0} moeten zijn, niet {1}", expected, actual));
            // Adding another house
            straat.KoopHuis();
            expected = huurMet2Huizen;
            actual = target.GeefTeBetalenHuur(straat);
            Assert.AreNotEqual(expected, actual, string.Format("De huur met 3 huizen zou niet {0} moeten zijn, maar {1}", actual, huurMet3Huizen));
            expected = huurMet3Huizen;
            Assert.AreEqual(expected, actual, string.Format("De huur met 3 huizen zou {0} moeten zijn, niet {1}", expected, actual));
            // Adding the last house
            straat.KoopHuis();
            expected = huurMet4Huizen;
            actual = target.GeefTeBetalenHuur(straat);
            Assert.AreEqual(expected, actual, string.Format("De huur met 4 huizen zou {0} moeten zijn, niet {1}", expected, actual));
            // Adding the hotel
            straat.KoopHotel();
            expected = huurMetHotel;
            actual = target.GeefTeBetalenHuur(straat);
            Assert.AreEqual(expected, actual, string.Format("De huur met hotel zou {0} moeten zijn, niet {1}", expected, actual));
        }

        /// <summary>
        ///A test for Huur Constructor
        ///</summary>
        [TestMethod()]
        public void HuurConstructorTest()
        {
            Huur target = new Huur(huurOnbebouwd, huurMet1Huis, huurMet2Huizen, huurMet3Huizen, huurMet4Huizen, huurMetHotel);
            Assert.IsNotNull(target, "De huur zou geinstantieerd moeten zijn op dit punt.");
        }
    }
}
