using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.gebeurtenis.kans;

namespace MSMonopoly.builders
{
    class KanskaartBuilder
    {
        private Monopolyspel _spel;

        public KanskaartBuilder(Monopolyspel spel)
        {
            _spel = spel;
        }

        public List<Gebeurtenis> build()
        {
            List<Gebeurtenis> kaarten = new List<Gebeurtenis>();
            kaarten.Add(new BetaalSchoolgeld());
            kaarten.Add(new BoeteVoorTeSnelRijden());
            kaarten.Add(new GaNaarBartiljorisstraat(_spel.Bord));
            return kaarten;
        }
    }
}
