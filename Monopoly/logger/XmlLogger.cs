using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;
using System.IO;
using Microsoft.Practices.Unity;

namespace Monopoly.logger
{
    class XmlLogger :ILogger
    {
        internal Stack<String> structure = new Stack<string>();

        [Dependency]
        public TextWriter writer {get; set;}

        public void initialize()
        {
            write("<?xml version=\"1.0\"?>");
            write("<?xml-stylesheet type=\"text/xml\" href=\"monopoly.xsl\"?>");
            openTag("monopolyspel");
        }
        public void finalize()
        {
            sluitVorigeStructuurAfTot(new String[] { "" });
        }
        public void rondeInfo(int p)
        {
            sluitVorigeStructuurAfTot(new String[] { "monopolyspel" });
            write(String.Format("<ronde nr='{0}'>", p));
            structure.Push("ronde");
        }
        public void spelerTussenstand(Speler s)
        {
            sluitVorigeStructuurAfTot(new String[] { "monopolyspel", "ronde", "stand" });
            openTagIfNotYetOpened("stand");
            write("<speler naam='" + s + "'>" +
                "<kasgeld>" + s.Bezittingen.Kasgeld + "</kasgeld>" +
                "<straten>" + s.Bezittingen.AantalHypotheekvelden() + "</straten>" +
                "<hypotheken>" + s.Bezittingen.AantalVeldenMetHypotheek() + "</hypotheken>" +
                "<huizen>" + s.Bezittingen.AantalHuizen() + "</huizen>" +
                "</speler>");
        }
        public void spelerBeurt(string p)
        {
            sluitVorigeStructuurAfTot(new String[] { "monopolyspel", "ronde" });
            write("<beurt speler='" + p + "'>");
            structure.Push("beurt");
        }

        public void logGebeurtenis(string p)
        {
            write(String.Format("<gebeurtenis>{0}</gebeurtenis>", p));
        }

        private void sluitVorigeStructuurAfTot(String[] openTags)
        {
            while (structure.Count() > 0 && thisTagNotIn(structure.Peek(), openTags))
            {
                String openstaandeTag = structure.Pop();
                write(String.Format("</{0}>", openstaandeTag));
            }
        }
        private bool thisTagNotIn(string p, string[] openTags)
        {
            return !(openTags.Contains(p));
        }
        private void openTag(String tagName)
        {
            write(String.Format("<{0}>", tagName));
            structure.Push(tagName);
        }
        private void openTagIfNotYetOpened(String tagName)
        {
            if (structure.Peek() != tagName)
            {
                openTag(tagName);
            }
        }
        private void write(String s) {
            if (writer == null)
            {
                writer = Console.Out;
            }
            writer.WriteLine(s);
        }
    }
}
