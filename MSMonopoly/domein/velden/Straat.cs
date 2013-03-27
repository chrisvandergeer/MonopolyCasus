using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSMonopoly.domein;
using MSMonopoly.domein.gebeurtenis;

namespace MSMonopoly.domein
{
    public class Straat : Veld
    {
        public Stad Stad { get; set; }
        public int Aankoopprijs { get; set; } 
        public int Huurprijs { get; set; }
        public Speler Eigenaar { get; set; }

        public Straat(string naam, int aankoopprijs, int huurprijs) : base(naam)
        {
            Aankoopprijs = aankoopprijs;
            Huurprijs = huurprijs;
        }

        public bool isVerkocht()
        {
            return Eigenaar != null;
        }

        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            if (isVerkocht()) 
            {
                return new BetaalHuur(speler, this);
            }

            return new KoopStraat(speler, this);
        }
    }
}
