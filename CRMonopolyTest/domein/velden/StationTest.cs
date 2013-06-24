using CRMonopoly.domein.velden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CRMonopoly.builders;
using CRMonopoly.domein;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for StationTest and is intended
    ///to contain all StationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StationTest
    {

        private int[] huurprijzenPerStationsInBezit = { 0, 25, 50, 100, 200 };

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
        ///A test for GeefTeBetalenHuur
        ///</summary>
        [TestMethod()]
        public void GeefTeBetalenHuurTest()
        {
            Stationbuilder builder = Stationbuilder.Instance;
            Station noord = builder.Noord();
            Speler spelerX = new Speler("spelerX", null);
            noord.Eigenaar = spelerX;
            Assert.AreEqual(huurprijzenPerStationsInBezit[1], noord.GeefTeBetalenHuur(spelerX));
            builder.Oost().Eigenaar = spelerX;
            Assert.AreEqual(huurprijzenPerStationsInBezit[2], noord.GeefTeBetalenHuur(spelerX));
            builder.Zuid().Eigenaar = spelerX;
            Assert.AreEqual(huurprijzenPerStationsInBezit[3], noord.GeefTeBetalenHuur(spelerX));
            builder.West().Eigenaar = spelerX;
            Assert.AreEqual(huurprijzenPerStationsInBezit[4], noord.GeefTeBetalenHuur(spelerX));
        }

        /// <summary>
        ///A test for HuurChangeListener
        ///</summary>
        [TestMethod()]
        public void HuurChangeListenerTest()
        {
            Dictionary<string, Station> _stations = new Dictionary<string,Station>();
            Station firstStation = new Station("Station_01", _stations);
            Station secondStation = new Station("Station_02", _stations);
            Station thirdStation = new Station("Station_03", _stations);
            Station fourthStation = new Station("Station_04", _stations);
            _stations.Add(firstStation.Naam, firstStation);
            _stations.Add(secondStation.Naam, secondStation);
            _stations.Add(thirdStation.Naam, thirdStation);
            _stations.Add(fourthStation.Naam, fourthStation);

            TestHuurChangeListener listener = new TestHuurChangeListener();
            firstStation.addHuurChangeListener(listener);

            int expected = huurprijzenPerStationsInBezit[0];
            Assert.AreEqual(expected, listener.huurprijsFromVeld,
                String.Format("In het begin moet de huurprijs {0} zijn. (Actual: {1})", expected, listener.huurprijsFromVeld));
            Speler eigenaar = new Speler("Eigenaar", null);
//            eigenaar.Add(firstStation);
            firstStation.Eigenaar = eigenaar;
            expected = huurprijzenPerStationsInBezit[1];
            Assert.AreEqual(expected, listener.huurprijsFromVeld,
                String.Format("De huurprijs moet nu {0} zijn. (Actual: {1})", expected, listener.huurprijsFromVeld));

            secondStation.addHuurChangeListener(listener);
//            eigenaar.Add(secondStation);
            secondStation.Eigenaar = eigenaar;
            expected = huurprijzenPerStationsInBezit[2];
            Assert.AreEqual(expected, listener.huurprijsFromVeld,
                String.Format("De huurprijs moet nu {0} zijn. (Actual: {1})", expected, listener.huurprijsFromVeld));

            thirdStation.addHuurChangeListener(listener);
//            eigenaar.Add(thirdStation);
            thirdStation.Eigenaar = eigenaar;
            expected = huurprijzenPerStationsInBezit[3];
            Assert.AreEqual(expected, listener.huurprijsFromVeld,
                String.Format("De huurprijs moet nu {0} zijn. (Actual: {1})", expected, listener.huurprijsFromVeld));

            fourthStation.addHuurChangeListener(listener);
//            eigenaar.Add(fourthStation);
            fourthStation.Eigenaar = eigenaar;
            expected = huurprijzenPerStationsInBezit[4];
            Assert.AreEqual(expected, listener.huurprijsFromVeld,
                String.Format("De huurprijs moet nu {0} zijn. (Actual: {1})", expected, listener.huurprijsFromVeld));
        }

    }
}
