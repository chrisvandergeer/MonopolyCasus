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
        private List<Gebeurtenis> _kaarten = null;
        public KaartenBuilder Builder { get; set; }

        public List<Gebeurtenis> Kaarten { 
            get {
                if (_kaarten == null)
                {
                    _kaarten = Builder.getStapelKaarten();
                }
                return _kaarten;
            }
            internal set {
                _kaarten = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public KansEnAlgemeenfondsVeld(string naam)
            : base(naam) { }
    
        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            Gebeurtenis kanskaart = Kaarten[0];
            Kaarten.Remove(kanskaart);
            if (! (kanskaart is VerlaatDeGevangenis) )
                Kaarten.Add(kanskaart);
            return kanskaart;
        }
    }
}
