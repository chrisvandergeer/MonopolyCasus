using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.gebeurtenis.kans;
using CRMonopoly.builders;

namespace CRMonopoly.domein.velden
{
    public class KansEnAlgemeenfondsVeld : Veld 
    {
        public List<Gebeurtenis> Kaarten { get; internal set; }
        private string p;

        /// <summary>
        /// Constructor
        /// </summary>
        public KansEnAlgemeenfondsVeld(string naam)
            : base(naam)
        {
            
        }
    
        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            Gebeurtenis kanskaart = Kaarten[0];
            Kaarten.Remove(kanskaart);
            // todo check Gevangeniskaart 
            Kaarten.Add(kanskaart);
            return kanskaart;
        }
    }
}
