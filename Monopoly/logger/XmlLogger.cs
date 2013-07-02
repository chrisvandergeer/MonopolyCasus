using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;

namespace Monopoly.logger
{
    class XmlLogger :ILogger
    {
        Stack<String> structure = new Stack<string>();
        public void initialize()
        {
            Console.WriteLine("<?xml version=\"1.0\"?>");
            Console.WriteLine("<?xml-stylesheet type=\"text/xml\" href=\"monopoly.xsl\"?>");
            openTag("monopolyspel");
        }
        public void finalize()
        {
            sluitVorigeStructuurAfTot(new String[] { "" });
        }
        public void rondeInfo(int p)
        {
            sluitVorigeStructuurAfTot(new String[] { "monopolyspel" });
            Console.Write(String.Format("<ronde nr='{0}'>", p));
            structure.Push("ronde");
        }
        public void spelerTussenstand(Speler s)
        {
            sluitVorigeStructuurAfTot(new String[] { "monopolyspel", "ronde", "stand" });
            openTagIfNotYetOpened("stand");
            Console.Write("<speler naam='" + s + "'>" +
                "<kasgeld>" + s.Bezittingen.Kasgeld + "</kasgeld>" +
                "<straten>" + s.Bezittingen.AantalHypotheekvelden() + "</straten>" +
                "<hypotheken>" + s.Bezittingen.AantalVeldenMetHypotheek() + "</hypotheken>" +
                "<huizen>" + s.Bezittingen.AantalHuizen() + "</huizen>" +
                "</speler>");
        }
        public void spelerBeurt(string p)
        {
            sluitVorigeStructuurAfTot(new String[] { "monopolyspel", "ronde" });
            Console.Write("<beurt speler='" + p + "'>");
            structure.Push("beurt");
        }

        public void logGebeurtenis(string p)
        {
            Console.Write(String.Format("<gebeurtenis>{0}</gebeurtenis>", p));
        }



        private void sluitVorigeStructuurAfTot(String[] openTags)
        {
            while (structure.Count() > 0 && thisTagNotIn(structure.Peek(), openTags))
            {
                String openstaandeTag = structure.Pop();
                Console.Write(String.Format("</{0}>", openstaandeTag));
            }
        }
        private bool thisTagNotIn(string p, string[] openTags)
        {
            return !(openTags.Contains(p));
        }
        private void openTag(String tagName)
        {
            Console.Write(String.Format("<{0}>", tagName));
            structure.Push(tagName);
        }
        private void openTagIfNotYetOpened(String tagName)
        {
            if (structure.Peek() != tagName)
            {
                openTag(tagName);
            }
        }

    }
}
