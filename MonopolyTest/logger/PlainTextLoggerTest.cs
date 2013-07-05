using Monopoly.logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly.domein;
using System.IO;
using System.Text;
using Monopoly.domein.velden;

namespace MonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for PlainTextLoggerTest and is intended
    ///to contain all PlainTextLoggerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PlainTextLoggerTest
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
        ///A test for PlainTextLogger Constructor
        ///</summary>
        [TestMethod()]
        public void PlainTextLoggerConstructorTest()
        {
            PlainTextLogger target = new PlainTextLogger();
            Assert.IsNotNull(target, "PlainTextLogger should have been instantiated.");
        }

        /// <summary>
        ///A test for finalize
        ///</summary>
        [TestMethod()]
        public void initializeFinalizeTest()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            PlainTextLogger target = new PlainTextLogger();
            target.writer = writer;
            target.initialize();
            target.finalize();
            Assert.AreEqual("", sb.ToString());
        }

        /// <summary>
        ///A test for rondeInfo
        ///</summary>
        [TestMethod()]
        public void rondeInfoTest()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            PlainTextLogger target = new PlainTextLogger();
            target.writer = writer;
            int p = 1;
            target.rondeInfo(p);
            String expected = String.Format("Ronde {0}:\r\n", p);
            Assert.AreEqual(expected, sb.ToString());
        }

        /// <summary>
        ///A test for logGebeurtenis
        ///</summary>
        [TestMethod()]
        public void logGebeurtenisTest()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            PlainTextLogger target = new PlainTextLogger();
            target.writer = writer;
            String testTxt = "GebeurtenisText";
            target.logGebeurtenis(testTxt);
            String expected = String.Format(" gebeurtenis: {0}\r\n", testTxt);
            Assert.AreEqual(expected, sb.ToString());
        }

        /// <summary>
        ///A test for spelerBeurt
        ///</summary>
        [TestMethod()]
        public void spelerBeurtTest()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            PlainTextLogger target = new PlainTextLogger();
            target.writer = writer;
            String p = "TestPlayer";
            target.spelerBeurt(p);
            String expected = String.Format("beurt speler={0}\r\n", p);
            Assert.AreEqual(expected, sb.ToString());
        }

        /// <summary>
        ///A test for spelerTussenstand
        ///</summary>
        [TestMethod()]
        public void spelerTussenstandTest()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            PlainTextLogger target = new PlainTextLogger();
            target.writer = writer;
            Speler s = new Speler("jan", null, null);
            Bezittingen b = new Bezittingen();

            b.Hypotheekvelden.Add(new Straat("test", 120, null));
            Straat hypotheekStraat = new Straat("hypotheek straat", 100, null);
            hypotheekStraat.Verkoop(s);
            hypotheekStraat.Hypotheek.NeemHypotheek();
            b.Hypotheekvelden.Add(hypotheekStraat);
            Straat straatMetHuis = new Straat("straat met huis", 100, null);
            straatMetHuis.Verkoop(s);
            straatMetHuis.Bebouw();
            b.Hypotheekvelden.Add(straatMetHuis);

            target.spelerTussenstand(s);
            String expected = String.Format("speler naam={0}, kasgeld={1}, straten={2}, hypotheken={3}, huizen={4}\r\n",
                  s, s.Bezittingen.Kasgeld, s.Bezittingen.AantalHypotheekvelden()
                , s.Bezittingen.AantalVeldenMetHypotheek(), s.Bezittingen.AantalHuizen());

            Assert.AreEqual(expected, sb.ToString());
        }
    }
}
