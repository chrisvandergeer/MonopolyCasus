using CRMonopoly.domein.gebeurtenis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CRMonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for GebeurtenisResultTest and is intended
    ///to contain all GebeurtenisResultTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GebeurtenisResultTest
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
        ///A test for Uitgevoerd
        ///</summary>
        [TestMethod()]
        public void UitgevoerdTest()
        {
            GebeurtenisResult target = GebeurtenisResult.Uitgevoerd("Some message.");
            Assert.IsNotNull(target, "De GebeurtenisResult methode Uitgevoerd moet altijd een GebeurtenisResult instance teruggeven.");
            Assert.IsTrue(target.IsUitgevoerd, "De GebeurtenisResult methode Uitgevoerd moet 'Uitgevoerd' zijn.");
            Assert.AreEqual("Some message. ", target.Melding, String.Format("De message is niet als verwacht (Exp: '{0}'; Act: '{1}').", "Some message. ", target.Melding));
        }

        /// <summary>
        ///A test for NietUitgevoerd
        ///</summary>
        [TestMethod()]
        public void NietUitgevoerdTest()
        {
            GebeurtenisResult target = GebeurtenisResult.NietUitgevoerd("Some message.");
            Assert.IsNotNull(target, "De GebeurtenisResult methode NietUitgevoerd moet altijd een GebeurtenisResult instance teruggeven.");
            Assert.IsFalse(target.IsUitgevoerd, "De GebeurtenisResult methode Uitgevoerd moet 'Niet Uitgevoerd' zijn.");
            Assert.AreEqual("Some message. ", target.Melding, String.Format("De message is niet als verwacht (Exp: '{0}'; Act: '{1}').", "Some message. ", target.Melding));
        }

        /// <summary>
        ///A test for Uitgevoerd
        ///</summary>
        [TestMethod()]
        public void UitgevoerdTestMetArgumentenArray()
        {
            String regel1 = "Test linepart 1.";
            String regel2 = "Test linepart 2.";
            String regel3 = "Test linepart 3.";
            GebeurtenisResult target = GebeurtenisResult.Uitgevoerd(regel1, regel2, regel3);
            String expected = regel1 + " " + regel2 + " " + regel3 + " ";
            Assert.AreEqual(expected, target.Melding, String.Format("De message is niet als verwacht (Exp: '{0}'; Act: '{1}').", expected, target.Melding));
        }

        /// <summary>
        ///A test for NietUitgevoerd
        ///</summary>
        [TestMethod()]
        public void NietUitgevoerdTestMetArgumentenArray()
        {
            String regel1 = "Test linepart nietUitgevoerd 1.";
            String regel2 = "Test linepart nietUitgevoerd 2.";
            String regel3 = "Test linepart nietUitgevoerd 3.";
            GebeurtenisResult target = GebeurtenisResult.NietUitgevoerd(regel1, regel2, regel3);
            String expected = regel1 + " " + regel2 + " " + regel3 + " ";
            Assert.AreEqual(expected, target.Melding, String.Format("De message is niet als verwacht (Exp: '{0}'; Act: '{1}').", expected, target.Melding));
        }

        /// <summary>
        ///A test for Append
        ///</summary>
        [TestMethod()]
        public void AppendTest()
        {
            String regel1 = "Message_regel 1";
            String regel2 = "Message_regel 2";
            GebeurtenisResult target = GebeurtenisResult.NietUitgevoerd(regel1);
            target.Append(regel2);
            String expected = regel1 + " " + Environment.NewLine + regel2;
            Assert.AreEqual(expected, target.Melding, 
                String.Format("De samengestelde melding is niet correct (Exp: '{0}'; Act: '{1}'.", expected, target.Melding));
        }
    }
}
