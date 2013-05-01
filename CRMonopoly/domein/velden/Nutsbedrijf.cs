using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.builders;

namespace CRMonopoly.domein.velden
{
    public class Nutsbedrijf : Veld, VerkoopbaarVeld
    {
        public Speler Eigenaar { get; set; }

        public Nutsbedrijf(string naam) : base(naam) 
        {
        }


        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            if (isVerkocht())
            {
                return new BetaalHuur(this);
            }
            return new KoopStraat(this);
        }

        private bool isVerkocht()
        {
            return Eigenaar != null;
        }

        /// <summary>
        /// Geeft de te betalen huur, afhankelijk van hoeveel Nutsbedrijven de Speler in bezit heeft
        /// en de worp (aantal ogen van de worp)
        /// Wanneer één nutsbedrijf in bezit is, bedraagt de huur 4 keer het gegooide aantal ogen
        /// Wanneer beide nutsbedrijven in bezit zijn, bedraagt de huur 10 keer het gegooide aantal ogen
        /// TODO: Methode werkt, maar kan veel korter
        /// </summary>
        /// <returns>te betalen huur</returns>
        public int GeefTeBetalenHuur()
        {
            int multiplier = getMultiplier();
            int worp = Eigenaar.getAantalOgenDezeBeurt();
            return multiplier * worp;
        }
        private int getMultiplier()
        {
            return Eigenaar.AantalNutsbedrijven() == 1 ? 4 : 10;
        }

        public int GeefAankoopprijs()
        {
            return 150;
        }

        public Speler GeefEigenaar()
        {
            return Eigenaar;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (! (obj is Nutsbedrijf)) return false;

            Nutsbedrijf nutsBedrijf = (Nutsbedrijf)obj;
            return Naam.Equals(nutsBedrijf.Naam);
        }

        public override int GetHashCode()
        {
            return Naam.GetHashCode();
        }
    }
}
