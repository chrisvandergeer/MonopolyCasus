using CRMonopoly.domein.gebeurtenis.kans;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.builders;
using CRMonopoly.domein.velden;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for GaNaarGebeurtenisTest and is intended
    ///to contain all GaNaarGebeurtenisTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GaNaarGebeurtenisTest
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
        ///A test for GaNaarGebeurtenis Constructor
        ///</summary>
        [TestMethod()]
        public void GaNaarGebeurtenisConstructorTest()
        {
            string bestemmingVeldnaam = "GaNaarGebeurtenis Bestemming";
            string gebeurtenisnaam = "GaNaarGebeurtenisConstructorTest";
            GaNaarGebeurtenis target = new GaNaarGebeurtenis(bestemmingVeldnaam, gebeurtenisnaam);
            Assert.IsNotNull(target, "De GaNaarGebeurtenis instance mag niet null zijn.");
            Assert.AreEqual(true, target.IsVerplicht(), "De GaNaarGebeurtenis moet verplicht zijn.");
        }

        /// <summary>
        ///A test for Bestemming
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void PropertyTest()
        {
            string gebeurtenisnaam = "GaNaarGebeurtenisConstructorTest_PropertyTest";
            GaNaarGebeurtenis target = createGaNaarGebeurtenis(gebeurtenisnaam, "GaNaarGebeurtenis_PropertyTest Bestemming");
            Assert.AreEqual(gebeurtenisnaam, target.Gebeurtenisnaam,
                String.Format("De gebeurtenisnaam is niet correct (Exp: {0}; Act. {1}).", gebeurtenisnaam, target.Gebeurtenisnaam));
        }

        /// <summary>
        ///A test for VoerUit
        ///</summary>
        [TestMethod()]
        public void VoerUitTest()
        {
            String bestemming = HaarlemBuilder.HOUTSTRAAT;
            GaNaarGebeurtenis target = createGaNaarGebeurtenis("VoerUitTest", bestemming);
            Speler speler = new Speler("VoerUitTestSpeler");
            Monopolyspel spel = new Monopolyspel();
            // Changes after Unity implementation.
            spel.Bord = new Monopolybord();

            spel.Add(speler);
            spel.Add(new Speler("DummySpeler"));
            GebeurtenisResult actual = target.VoerUit(speler);
            Assert.AreEqual(true, actual.IsUitgevoerd, "De GaNaarGebeurtenis gebeurtenis zou uitgevoerd moeten zijn.");
            Veld expectedPos = speler.Bord.GeefVeld(bestemming);
            Assert.AreEqual(expectedPos, speler.HuidigePositie,
                String.Format("De speler zou verplaatst moeten zijn. (Exp: {0}; Act: {1})", expectedPos, speler.HuidigePositie));
        }

        /// <summary>
        ///A test for KomtLangsStart
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void KomtLangsStartTest()
        {
            String bestemming = OnsDorpBuilder.DORPSSTRAAT;
            GaNaarGebeurtenis target = createGaNaarGebeurtenis("VoerUitTest", bestemming);
            Speler speler = new Speler("KomtLangsStartTestSpeler");
            Monopolyspel spel = new Monopolyspel();
            // Changes after Unity implementation.
            spel.Bord = new Monopolybord();

            spel.Add(speler);
            spel.Add(new Speler("DummySpeler"));
            // Putting the player just before start.
            speler.HuidigePositie = speler.Bord.GeefVeld(AmsterdamBuilder.LEIDSESTRAAT);
            Veld expectedPos = speler.Bord.GeefVeld(bestemming);
            // Moving the player past Start
            GebeurtenisResult actual = target.VoerUit(speler);
            TestContext.WriteLine(actual.Melding);
            Assert.AreEqual(true, actual.IsUitgevoerd, "De GaNaarGebeurtenis gebeurtenis zou uitgevoerd moeten zijn.");
            Assert.AreEqual(expectedPos, speler.HuidigePositie,
                String.Format("De speler zou verplaatst moeten zijn. (Exp: {0}; Act: {1})", expectedPos, speler.HuidigePositie));
            // Checking if the text "Langs Start ontvangt u" can be found in the results text.
            String expected = String.Format("Speler '{0}' komt langs start en ontvangt", speler.Name);
            Assert.IsTrue(actual.Melding.IndexOf(expected) > 0, "De speler zou langs start gekomen moeten zijn.");
        }

        private static GaNaarGebeurtenis createGaNaarGebeurtenis(String gebeurtenisnaam, String bestemming)
        {
            GaNaarGebeurtenis target = new GaNaarGebeurtenis(bestemming, gebeurtenisnaam);
            return target;
        }
    }
}
