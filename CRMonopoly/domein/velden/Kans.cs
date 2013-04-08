using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.gebeurtenis.kans;
using MSMonopoly.builders;

namespace CRMonopoly.domein.velden
{
    class Kans : Veld 
    {
        private List<Gebeurtenis> _kanskaarten;

        /// <summary>
        /// Constructor
        /// </summary>
        public Kans(Monopolyspel spel) : base("Kans") {
            _kanskaarten = new KanskaartBuilder(spel).build();
        }
    
        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            Gebeurtenis kanskaart = _kanskaarten[0];
            _kanskaarten.Remove(kanskaart);
            // todo check Gevangeniskaart 
            _kanskaarten.Add(kanskaart);
            return kanskaart;
        }
    }
}
