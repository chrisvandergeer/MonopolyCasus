using Monopoly.logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly.domein;
using System.Text;
using System.IO;
using Monopoly.domein.velden;

namespace MonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for XmlLoggerTest and is intended
    ///to contain all XmlLoggerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class XmlLoggerTest
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
        ///A test for XmlLogger Constructor
        ///</summary>
        [TestMethod()]
        public void XmlLoggerConstructorTest()
        {
            XmlLogger target = new XmlLogger();
            Assert.IsNotNull(target, "XmlLogger should have been instantiated");
        }

        /// <summary>
        ///A test for initialize
        ///</summary>
        [TestMethod()]
        public void initializeAndFinalizeTest()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            XmlLogger target = new XmlLogger();
            target.writer = writer;
            target.initialize();
            Assert.AreEqual(1, target.structure.Count, "There should be 1 element on the stack.");
            target.finalize();
            Assert.AreEqual(0, target.structure.Count, "There should be no element on the stack now.");
            Assert.IsTrue(sb.ToString().IndexOf("<monopolyspel>") > 0);
            Assert.IsTrue(sb.ToString().IndexOf("</monopolyspel>") > 0);
            Assert.IsTrue(sb.ToString().IndexOf("<monopolyspel>") < sb.ToString().IndexOf("</monopolyspel>"));
        }

        /// <summary>
        ///A test for logGebeurtenis
        ///</summary>
        [TestMethod()]
        public void logGebeurtenisTest()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            XmlLogger target = new XmlLogger();
            target.writer = writer;
            target.initialize();
            String p = "TestGebeurtenisText";
            target.logGebeurtenis(p);
            target.finalize();
            String expected = String.Format("<gebeurtenis>{0}</gebeurtenis>", p);
            Assert.IsTrue(sb.ToString().IndexOf(expected) > 0);
        }

        /// <summary>
        ///A test for rondeInfo
        ///</summary>
        [TestMethod()]
        public void rondeInfoTest()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            XmlLogger target = new XmlLogger();
            target.writer = writer;
            target.initialize();
            int p = 1;
            target.rondeInfo(p);
            target.finalize();
            String expected = String.Format("<ronde nr='{0}'>", p);
            Assert.IsTrue(sb.ToString().IndexOf(expected) > 0);
        }

        /// <summary>
        ///A test for spelerBeurt
        ///</summary>
        [TestMethod()]
        public void spelerBeurtTest()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            XmlLogger target = new XmlLogger();
            target.writer = writer;
            target.initialize();
            String p = "SpelerNaam";
            target.spelerBeurt(p);
            target.finalize();
            String expected = String.Format("<beurt speler='{0}'>", p);
            Assert.IsTrue(sb.ToString().IndexOf(expected) > 0);
        }

        /// <summary>
        ///A test for spelerTussenstand
        ///</summary>
        [TestMethod()]
        public void spelerTussenstandTest()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            XmlLogger target = new XmlLogger();
            target.writer = writer;
            target.initialize();
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
            target.finalize();
            String expected = "<speler naam='" + s + "'>" +
                "<kasgeld>" + s.Bezittingen.Kasgeld + "</kasgeld>" +
                "<straten>" + s.Bezittingen.AantalHypotheekvelden() + "</straten>" +
                "<hypotheken>" + s.Bezittingen.AantalVeldenMetHypotheek() + "</hypotheken>" +
                "<huizen>" + s.Bezittingen.AantalHuizen() + "</huizen>" +
                "</speler>";
            Assert.IsTrue(sb.ToString().IndexOf("<stand>") > 0);
            Assert.IsTrue(sb.ToString().IndexOf("</stand>") > 0);
            Assert.IsTrue(sb.ToString().IndexOf("</stand>") > sb.ToString().IndexOf("<stand>"));

            Assert.IsTrue(sb.ToString().IndexOf(expected) > 0);
            Assert.IsTrue(sb.ToString().IndexOf("<stand>") < sb.ToString().IndexOf(expected));
            Assert.IsTrue(sb.ToString().IndexOf("</stand>") > sb.ToString().IndexOf(expected));

        }

    }
}
