using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;
using Microsoft.Practices.Unity;
using System.IO;

namespace Monopoly.logger
{
    class PlainTextLogger : ILogger
    {

        [Dependency]
        public TextWriter writer { get; set; }

        public void initialize()
        {
        }
        public void finalize()
        {
        }
        public void rondeInfo(int p)
        {
            write(String.Format("Ronde {0}:", p));
        }
        public void spelerTussenstand(Speler s)
        {
            write("speler naam=" + s +
                ", kasgeld=" + s.Bezittingen.Kasgeld +
                ", straten=" + s.Bezittingen.AantalHypotheekvelden() +
                ", hypotheken=" + s.Bezittingen.AantalVeldenMetHypotheek() +
                ", huizen=" + s.Bezittingen.AantalHuizen());
        }
        public void spelerBeurt(string p)
        {
            write("beurt speler=" + p);
        }
        public void logGebeurtenis(string p)
        {
            write(String.Format(" gebeurtenis: {0}", p));
        }
        private void write(String s)
        {
            if (writer == null)
            {
                writer = Console.Out;
            }
            writer.WriteLine(s);
        }
    }
}
