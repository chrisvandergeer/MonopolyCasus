using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;

namespace Monopoly.logger
{
    class PlainTextLogger : ILogger
    {
        public void initialize()
        {
        }
        public void finalize()
        {
        }
        public void rondeInfo(int p)
        {
            Console.WriteLine(String.Format("Ronde {0}:", p));
        }
        public void spelerTussenstand(Speler s)
        {
            Console.WriteLine("speler naam=" + s +
                ", kasgeld=" + s.Bezittingen.Kasgeld +
                ", straten=" + s.Bezittingen.AantalHypotheekvelden() +
                ", hypotheken=" + s.Bezittingen.AantalVeldenMetHypotheek() +
                ", huizen=" + s.Bezittingen.AantalHuizen());
        }
        public void spelerBeurt(string p)
        {
            Console.WriteLine("beurt speler=" + p);
        }
        public void logGebeurtenis(string p)
        {
            Console.WriteLine(String.Format(" gebeurtenis: {0}", p));
        }

    }
}
