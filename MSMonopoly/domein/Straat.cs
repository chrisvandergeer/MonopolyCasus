using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSMonopoly.domein.acties;

namespace MSMonopoly.domein
{
    public class Straat : Veld
    {
        public string Straatnaam    { get; set; }
        public int Aankoopprijs     { get; set; }
        public int HuurOnbebouwd    { get; set; }
        public Stad Stad            { get; set; }
        public Speler Eigenaar      { get; set; }

        public bool IsTekoop()
        {
            return Eigenaar != null;
        }

        public string Naam()
        {
            return Straatnaam;
        }

        public Actie BepaalActie(Beurt huidigeBeurt)
        {
            if (IsTekoop())
            {
                return new KoopStraat(huidigeBeurt.HuidigeSpeler, this);
            }
            else
            {
                return new BetaalHuur(huidigeBeurt.HuidigeSpeler, this);
            }
        }

        public void Verkoop(Speler koper)
        {
            koper.Betaal(Aankoopprijs);
            Eigenaar = koper;
            koper.Straten.Add(this);
        }

        public int BepaalHuur()
        {
            return HuurOnbebouwd;
        }
    }
}
