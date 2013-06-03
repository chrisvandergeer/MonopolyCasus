using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class OntvangGeldVanIedereSpeler : AbstractGebeurtenis
    {
        private Monopolyspel _spel;
        private int _bedrag;

        public OntvangGeldVanIedereSpeler(Monopolyspel spel, int bedrag) : base("Ontvang " + bedrag + " van iedere speler")
        {
            _spel = spel;
            _bedrag = bedrag;
        }

        public override GebeurtenisResult VoerUit(Speler speler)
        {
            _spel.Spelers.FindAll(s => !s.Equals(speler)).ForEach(s => s.Betaal(_bedrag, speler));
            return GebeurtenisResult.Uitgevoerd(speler, "heeft van iedere speler", _bedrag, "ontvangen");
        }

        public override bool IsVerplicht()
        {
            return true;
        }
    }
}
