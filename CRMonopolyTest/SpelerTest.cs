using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein.gebeurtenis;
using System.Collections.Generic;
using CRMonopoly.builders;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for SpelerTest and is intended
    ///to contain all SpelerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SpelerTest
    {


        private TestContext testContextInstance;
        private int startBedrag = 1500;


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
        ///A test for Speler Constructor
        ///</summary>
        [TestMethod()]
        public void SpelerConstructorTest()
        {
            string name = "TestSpeler";
            Speler target = new Speler(name);
            Assert.AreSame(name, target.Name, String.Format("De naam van de speler zou {0} moeten zijn.", name));
            Assert.IsTrue(startBedrag == target.Geldeenheden, String.Format("Het startbedrag van een nieuwe speler zou {0} moeten zijn.", startBedrag));
        }

        /// <summary>
        ///A test for Betaal
        ///</summary>
        [TestMethod()]
        public void BetaalTest()
        {
            string nameBetalendeSpeler = "BetalendeSpeler";
            Speler betaler = new Speler(nameBetalendeSpeler);
            string nameOntvangenSpeler = "OntvangendeSpeler";
            Speler ontvanger = new Speler(nameOntvangenSpeler);
            int bedrag = 100;
            bool actual = betaler.Betaal(bedrag, ontvanger);
            Assert.IsTrue(actual, String.Format("De betaling van {0} zou geen probleem moeten zijn.", bedrag));
            Assert.IsTrue((startBedrag - bedrag) == betaler.Geldeenheden, String.Format("De betalende spelers zou nu {0} in geld moeten hebben.", (startBedrag - bedrag)));
            Assert.IsTrue((startBedrag + bedrag) == ontvanger.Geldeenheden, String.Format("De ontvangende spelers zou nu {0} in geld moeten hebben.", (startBedrag + bedrag)));
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            string name = "TestSpeler";
            Speler target = new Speler(name);
            Straat straat = StadBuilder.Instance.BuildAmsterdam().getStraatByIndex(0);
            target.Add(straat);
            Assert.IsTrue(target.getStraten().Count == 1, "De Speler zou nu 1 straat in bezit moeten hebben.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddMultipleStreetsTest()
        {
            string name = "TestSpeler";
            Speler target = new Speler(name);
            target.Add(StadBuilder.Instance.BuildAmsterdam().getStraatByIndex(0));
            target.Add(StadBuilder.Instance.BuildArnhem().getStraatByIndex(2));
            target.Add(StadBuilder.Instance.BuildOnsDorp().getStraatByIndex(1));
            Assert.IsTrue(target.getStraten().Count == 3, "De Speler zou nu 3 straat in bezit moeten hebben.");
        }

        /// <summary>
        ///A test for Ontvang
        ///</summary>
        [TestMethod()]
        public void OntvangTest()
        {
            string name = "TestSpeler";
            Speler target = new Speler(name);
            int bedrag = 250;
            target.Ontvang(bedrag);
            int expected = (startBedrag + bedrag);
            Assert.IsTrue(expected == target.Geldeenheden, String.Format("De speler zou nu {0} aan geld moeten hebben.", expected));
            int tweedeBedrag = 195;
            target.Ontvang(tweedeBedrag);
            expected = (startBedrag + bedrag + tweedeBedrag);
            Assert.IsTrue(expected == target.Geldeenheden, String.Format("De speler zou nu {0} aan geld moeten hebben.", expected));
        }

        /// <summary>
        ///A test for Verplaats
        ///</summary>
        [TestMethod()]
        public void VerplaatsTest()
        {
            string name = "TestSpeler";
            Speler target = new Speler(name);
            Worp worp = Worp.GooiDobbelstenen();
            worp.Gedobbeldeworp1 = 1;
            worp.Gedobbeldeworp1 = 2;
            Gebeurtenis expected = null; // TODO: Initialize to an appropriate value
            Gebeurtenis actual;
            actual = target.Verplaats(worp);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Verplaats
        ///</summary>
        [TestMethod()]
        public void VerplaatsTest1()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            Speler target = new Speler(name); // TODO: Initialize to an appropriate value
            Veld nieuwVeld = null; // TODO: Initialize to an appropriate value
            Gebeurtenis expected = null; // TODO: Initialize to an appropriate value
            Gebeurtenis actual;
            actual = target.Verplaats(nieuwVeld);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Bord
        ///</summary>
        [TestMethod()]
        public void BordTest()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            Speler target = new Speler(name); // TODO: Initialize to an appropriate value
            Monopolybord expected = null; // TODO: Initialize to an appropriate value
            Monopolybord actual;
            target.Bord = expected;
            actual = target.Bord;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Geldeenheden
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void GeldeenhedenTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Speler_Accessor target = new Speler_Accessor(param0); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Geldeenheden = expected;
            actual = target.Geldeenheden;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HuidigePositie
        ///</summary>
        [TestMethod()]
        public void HuidigePositieTest()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            Speler target = new Speler(name); // TODO: Initialize to an appropriate value
            Veld expected = null; // TODO: Initialize to an appropriate value
            Veld actual;
            target.HuidigePositie = expected;
            actual = target.HuidigePositie;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            Speler target = new Speler(name); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StratenInBezit
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CRMonopoly.exe")]
        public void StratenInBezitTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Speler_Accessor target = new Speler_Accessor(param0); // TODO: Initialize to an appropriate value
            List<Straat> expected = null; // TODO: Initialize to an appropriate value
            List<Straat> actual;
            target.StratenInBezit = expected;
            actual = target.StratenInBezit;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
