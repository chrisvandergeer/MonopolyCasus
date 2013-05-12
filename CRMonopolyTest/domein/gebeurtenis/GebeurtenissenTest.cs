using CRMonopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopolyTest
{
    
    /// <summary>
    ///This is a test class for GebeurtenissenTest and is intended
    ///to contain all GebeurtenissenTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GebeurtenissenTest
    {

        [TestInitialize]
        public void setup()
        {
        }

        /// <summary>
        ///A test for Gebeurtenissen Constructor
        ///</summary>
        [TestMethod()]
        public void GebeurtenissenConstructorTest()
        {
            Gebeurtenissen gebeurtenissen = new Gebeurtenissen();
            Assert.IsNotNull(gebeurtenissen, "De gebeurtenissen instance mag niet null zijn.");
        }

        /// <summary>
        ///A test for Gebeurtenissen
        ///</summary>
        [TestMethod()]
        public void GebeurtenissenAddGebeurtenisTest()
        {
            Gebeurtenissen gebeurtenissen = new Gebeurtenissen();
            gebeurtenissen.Add(new BetaalHuur(new Straat("straat 1", 0, new Huur(0, 0, 0, 0, 0, 0))));
            int expected = 1;
            Assert.AreEqual(expected, gebeurtenissen.GebeurtenissenCount(), "Er zou op dit moment maar 1 element in de gebeurtenissen moeten zitten.");
            gebeurtenissen.Add(new BetaalHuur(new Straat("straat 2", 0, new Huur(0, 0, 0, 0, 0, 0))));
            gebeurtenissen.Add(new BetaalHuur(new Straat("straat 3", 0, new Huur(0, 0, 0, 0, 0, 0))));
            expected = 3;
            Assert.AreEqual(expected, gebeurtenissen.GebeurtenissenCount(), "Er zou op dit moment 3 elementen in de gebeurtenissen moeten zitten.");
        }

        /// <summary>
        ///A test for Gebeurtenissen
        ///</summary>
        [TestMethod()]
        public void GebeurtenissenAddGebeurtenissenTest()
        {
            Gebeurtenissen gebeurtenissen = new Gebeurtenissen();
            gebeurtenissen.Add(new BetaalHuur(new Straat("straat 1", 0, new Huur(0, 0, 0, 0, 0, 0))));
            gebeurtenissen.Add(new BetaalHuur(new Straat("straat 2", 0, new Huur(0, 0, 0, 0, 0, 0))));
            gebeurtenissen.Add(new BetaalHuur(new Straat("straat 3", 0, new Huur(0, 0, 0, 0, 0, 0))));
            int expected = 3;
            Gebeurtenissen gebeurtenissenUnderTest = new Gebeurtenissen();
            gebeurtenissenUnderTest.Add(gebeurtenissen);
            Assert.AreEqual(expected, gebeurtenissenUnderTest.GebeurtenissenCount(), "Er zou op dit moment 3 elementen in de gebeurtenissen moeten zitten.");
        }

        /// <summary>
        ///A test for Gebeurtenissen
        ///</summary>
        [TestMethod()]
        public void GebeurtenissenAddGebeurtenissenResultTest()
        {
            GebeurtenisResult gebeurtenisResult = GebeurtenisResult.Uitgevoerd("Some message 01.");
            int expected = 1;
            Gebeurtenissen gebeurtenissenUnderTest = new Gebeurtenissen();
            gebeurtenissenUnderTest.Add(gebeurtenisResult);
            Assert.AreEqual(expected, gebeurtenissenUnderTest.GebeurtenissenResultCount(), "Er zou op dit moment 1 element in de gebeurtenissenResult moeten zitten.");
            gebeurtenisResult = GebeurtenisResult.Uitgevoerd("Some message 02.");
            gebeurtenissenUnderTest.Add(gebeurtenisResult);
            gebeurtenisResult = GebeurtenisResult.Uitgevoerd("Some message 03.");
            gebeurtenissenUnderTest.Add(gebeurtenisResult);
            expected = 3;
            Assert.AreEqual(expected, gebeurtenissenUnderTest.GebeurtenissenResultCount(), "Er zou op dit moment 3 elementen in de gebeurtenissenResult moeten zitten.");
        }

        /// <summary>
        ///A test for Gebeurtenissen
        ///</summary>
        [TestMethod()]
        public void GebeurtenissenBevatEnGeefGebeurtenissenTest()
        {
            Gebeurtenissen gebeurtenissen = new Gebeurtenissen();
            gebeurtenissen.Add(new BetaalHuur(new Straat("straat 1", 0, new Huur(0, 0, 0, 0, 0, 0))));
            Assert.IsTrue(gebeurtenissen.bevatGebeurtenis(Gebeurtenisnamen.BETAAL_HUUR), "Er zou op dit moment een BetaalHuur gebeurtenis in moeten zitten.");
            Assert.IsNotNull(gebeurtenissen.GeefGebeurtenis(Gebeurtenisnamen.BETAAL_HUUR), "Er zou een Gebeurtenis teruggegeven moeten worden.");
            Assert.IsInstanceOfType(gebeurtenissen.GeefGebeurtenis(Gebeurtenisnamen.BETAAL_HUUR), typeof(BetaalHuur), "Er zou een BetaalHuur Gebeurtenis teruggegeven moeten worden.");

            Assert.IsFalse(gebeurtenissen.bevatGebeurtenis(Gebeurtenisnamen.BETAAL_BELASTING), "Er zou op dit moment geen BetaalBelasting gebeurtenis in moeten zitten.");
            Assert.IsNull(gebeurtenissen.GeefGebeurtenis(Gebeurtenisnamen.BETAAL_BELASTING), "Er zou geen object teruggegeven moeten worden.");
            Assert.IsFalse(gebeurtenissen.bevatGebeurtenis(Gebeurtenisnamen.KOOP_STRAAT), "Er zou op dit moment geen KoopStraat gebeurtenis in moeten zitten.");
            Assert.IsNull(gebeurtenissen.GeefGebeurtenis(Gebeurtenisnamen.KOOP_STRAAT), "Er zou geen object teruggegeven moeten worden.");

            gebeurtenissen.Add(new BetaalBelasting(Gebeurtenisnamen.BETAAL_BELASTING, 123));
            gebeurtenissen.Add(new KoopStraat(new Straat("SomeStreet", 123, new Huur(0,0,0,0,0,0))));
            Assert.IsTrue(gebeurtenissen.bevatGebeurtenis(Gebeurtenisnamen.BETAAL_HUUR), "Er zou op dit moment een BetaalHuur gebeurtenis in moeten zitten.");
            Assert.IsNotNull(gebeurtenissen.GeefGebeurtenis(Gebeurtenisnamen.BETAAL_HUUR), "Er zou een Gebeurtenis teruggegeven moeten worden.");
            Assert.IsInstanceOfType(gebeurtenissen.GeefGebeurtenis(Gebeurtenisnamen.BETAAL_HUUR), typeof(BetaalHuur), "Er zou een BetaalHuur Gebeurtenis teruggegeven moeten worden.");

            Assert.IsTrue(gebeurtenissen.bevatGebeurtenis(Gebeurtenisnamen.BETAAL_BELASTING), "Er zou op dit moment een BetaalBelasting gebeurtenis in moeten zitten.");
            Assert.IsNotNull(gebeurtenissen.GeefGebeurtenis(Gebeurtenisnamen.BETAAL_BELASTING), "Er zou een Gebeurtenis teruggegeven moeten worden.");
            Assert.IsInstanceOfType(gebeurtenissen.GeefGebeurtenis(Gebeurtenisnamen.BETAAL_BELASTING), typeof(BetaalBelasting), "Er zou een BetaalBelasting Gebeurtenis teruggegeven moeten worden.");

            Assert.IsTrue(gebeurtenissen.bevatGebeurtenis(Gebeurtenisnamen.KOOP_STRAAT), "Er zou op dit moment een KoopStraat gebeurtenis in moeten zitten.");
            Assert.IsNotNull(gebeurtenissen.GeefGebeurtenis(Gebeurtenisnamen.KOOP_STRAAT), "Er zou een Gebeurtenis teruggegeven moeten worden.");
            Assert.IsInstanceOfType(gebeurtenissen.GeefGebeurtenis(Gebeurtenisnamen.KOOP_STRAAT), typeof(KoopStraat), "Er zou een KoopStraat Gebeurtenis teruggegeven moeten worden.");
        }

        /// <summary>
        ///A test for Gebeurtenissen
        ///</summary>
        [TestMethod()]
        public void GebeurtenissenBevatEnGeefVerplichteGebeurtenissenTest()
        {
            Gebeurtenissen gebeurtenissen = new Gebeurtenissen();
            Assert.IsFalse(gebeurtenissen.BevatVerplichteGebeurtenis(), "Er zou op dit moment geen verplichte gebeurtenis in moeten zitten.");
            Gebeurtenissen actual = gebeurtenissen.GeefVerplichteGebeurtenissen();
            Assert.IsNotNull(actual, "Er zou altijd een gebeurtenissen object terug gegeven moeten worden.");
            Assert.AreEqual(0, actual.GebeurtenissenCount(), "Er zouden geen elementen in het resultaat mogen zitten.");
            
            gebeurtenissen.Add(new KoopStraat(new Straat("SomeStreet", 123, new Huur(0, 0, 0, 0, 0, 0))));
            Assert.IsFalse(gebeurtenissen.BevatVerplichteGebeurtenis(), "Er zou op dit moment geen verplichte gebeurtenis in moeten zitten.");
            actual = gebeurtenissen.GeefVerplichteGebeurtenissen();
            Assert.IsNotNull(actual, "Er zou altijd een gebeurtenissen object terug gegeven moeten worden.");
            Assert.AreEqual(0, actual.GebeurtenissenCount(), "Er zouden geen elementen in het resultaat mogen zitten.");

            gebeurtenissen.Add(new BetaalHuur(new Straat("straat 1", 0, new Huur(0, 0, 0, 0, 0, 0))));
            Assert.IsTrue(gebeurtenissen.BevatVerplichteGebeurtenis(), "Er zou op dit moment wel een verplichte gebeurtenis in moeten zitten.");
            actual = gebeurtenissen.GeefVerplichteGebeurtenissen();
            Assert.IsNotNull(actual, "Er zou altijd een gebeurtenissen object terug gegeven moeten worden.");
            Assert.AreEqual(1, actual.GebeurtenissenCount(), "Er zou nu wel een elementen in het resultaat moet zitten.");
        }

        /// <summary>
        ///A test for Gebeurtenissen
        ///</summary>
        [TestMethod()]
        public void GebeurtenissenBevatEnGeefGooiDobbelStenenGebeurtenissenTest()
        {
            Gebeurtenissen gebeurtenissen = new Gebeurtenissen();
            Assert.IsFalse(gebeurtenissen.BevatGooiDobbelstenenGebeurtenis(), "Er zou op dit moment geen GooiDobbelstenen gebeurtenis in moeten zitten.");
            Assert.IsNull(gebeurtenissen.GeefDobbelstenenGebeurtenis(), "Er zou op dit moment geen GooiDobbelstenen gebeurtenis in moeten zitten.");
            gebeurtenissen.Add(new KoopStraat(new Straat("SomeStreet", 123, new Huur(0, 0, 0, 0, 0, 0))));
            Assert.IsFalse(gebeurtenissen.BevatGooiDobbelstenenGebeurtenis(), "Er zou op dit moment geen GooiDobbelstenen gebeurtenis in moeten zitten.");
            Assert.IsNull(gebeurtenissen.GeefDobbelstenenGebeurtenis(), "Er zou op dit moment geen GooiDobbelstenen gebeurtenis in moeten zitten.");
            gebeurtenissen.Add(new GooiDobbelstenenGebeurtenis());
            Assert.IsTrue(gebeurtenissen.BevatGooiDobbelstenenGebeurtenis(), "Er zou op dit moment wel een GooiDobbelstenen gebeurtenis in moeten zitten.");
            Assert.IsNotNull(gebeurtenissen.GeefDobbelstenenGebeurtenis(), "Er zou op dit moment wel een GooiDobbelstenen gebeurtenis in moeten zitten.");
            Assert.IsTrue(gebeurtenissen.GeefDobbelstenenGebeurtenis() is GooiDobbelstenenGebeurtenis, "De return van methode GeefDobbelstenenGebeurtenis moet een GooiDobbelstenenGebeurtenis zijn.");
        }

        /// <summary>
        ///A test for Gebeurtenissen
        ///</summary>
        [TestMethod()]
        public void GebeurtenissenGeefOptioneleGebeurtenissenTest()
        {
            Gebeurtenissen gebeurtenissen = new Gebeurtenissen();
            Gebeurtenissen actual = gebeurtenissen.GeefOptioneleGebeurtenissen();
            Assert.IsNotNull(actual, "Er zou altijd een gebeurtenissen object terug gegeven moeten worden.");
            Assert.AreEqual(0, actual.GebeurtenissenCount(), "Er zouden geen elementen in het resultaat mogen zitten.");

            gebeurtenissen.Add(new BetaalHuur(new Straat("straat 1", 0, new Huur(0, 0, 0, 0, 0, 0))));
            actual = gebeurtenissen.GeefOptioneleGebeurtenissen();
            Assert.IsNotNull(actual, "Er zou altijd een gebeurtenissen object terug gegeven moeten worden.");
            Assert.AreEqual(0, actual.GebeurtenissenCount(), "Er zouden geen elementen in het resultaat mogen zitten.");

            gebeurtenissen.Add(new KoopStraat(new Straat("SomeStreet", 123, new Huur(0, 0, 0, 0, 0, 0))));
            actual = gebeurtenissen.GeefOptioneleGebeurtenissen();
            Assert.IsNotNull(actual, "Er zou altijd een gebeurtenissen object terug gegeven moeten worden.");
            Assert.AreEqual(1, actual.GebeurtenissenCount(), "Er zou nu wel een elementen in het resultaat moet zitten.");
        }

        // Methods nog te doen: GetEnumerator, log, ??VoerUit
    }
}
