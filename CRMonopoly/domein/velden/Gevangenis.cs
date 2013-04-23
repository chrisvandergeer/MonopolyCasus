using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein.velden
{
    public class Gevangenis : Veld
    {
        private Dictionary<Speler, int> Gevangenen { get; set; }
        public Gevangenis() : base("Gevangenis") 
        {
            Gevangenen = new Dictionary<Speler, int>();
        }

        public override gebeurtenis.Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            return new GevangenisGebeurtenis(this);
        }

        public bool IsGevangene(Speler speler)
        {
            return Gevangenen.ContainsKey(speler);
        }

        public void LaatVrij(Speler speler)
        {
            Gevangenen.Remove(speler);
        }

        public int WachtBeurt(Speler speler)
        {
            int aantalBeurten = Gevangenen[speler];
            Gevangenen[speler] = aantalBeurten + 1;
            return Gevangenen[speler];
        }

        public void NieuweGevangene(Speler speler)
        {
            Gevangenen.Add(speler, 0);
            speler.HuidigePositie = this;

        }
    }
}
