using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein
{
    public class Straat : Veld
    {
        /// <summary>
        /// De stad waartoe een straat behoord
        /// </summary>
        public Stad Stad { get; set; }

        /// <summary>
        /// Aanschafwaarde van een straat
        /// </summary>
        public int Aankoopprijs { get; set; } 

        /// <summary>
        /// Eigenaar van een straat. Indien null, dan is de straat nog niet verkocht.
        /// </summary>
        public Speler Eigenaar { get; set; }

        /// <summary>
        /// Huurprijzen voor onbebouwd en bebouwd
        /// </summary>
        public Huur Huurprijzen { get; set; }
        
        /// <summary>
        /// Een straat kan 1 hotel bevatten
        /// </summary>
        private bool _hotel;

        /// <summary>
        /// Een straat kan 1 tot 4 huizen bevatten
        /// </summary>
        private int _huizenAantal;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="aankoopprijs"></param>
        /// <param name="huurprijzen"></param>
        public Straat(string naam, int aankoopprijs, Huur huurprijzen) : base(naam)
        {
            Aankoopprijs = aankoopprijs;
            Huurprijzen = huurprijzen;
        }

        public bool isVerkocht()
        {
            return Eigenaar != null;
        }

        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            if (isVerkocht()) 
            {
                return new BetaalHuur(this);
            }
            return new KoopStraat(this);
        }

        public bool HeeftHotel()
        {
            return _hotel;
        }

        public int GeefAantalHuizen()
        {
            return _huizenAantal;
        }

        public int GeefTeBetalenHuur()
        {
            return Huurprijzen.GeefTeBetalenHuur(this);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(GetType())) {
                Straat straat = (Straat) obj;
                return straat.Naam.Equals(Naam);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Naam.GetHashCode();
        }

        public bool MagHuisKopen()
        {
            return Stad.HeeftAlleSratenInBezit(Eigenaar) && GeefAantalHuizen() < 4 && !HeeftHotel();
        }

        public bool MagHotelKopen()
        {
            return GeefAantalHuizen() == 4;
        }

        public bool KoopHuis()
        {
            if (!MagHuisKopen()) 
                throw new ApplicationException("Er mogen maximaal 4 huizen gekocht worden en alleen indien alle straten van de stad in bezit zijn");
            if (Eigenaar.Betaal(Stad.Huisprijs, new Speler("Bank")))
            {
                _huizenAantal++;
                return true;
            }
            return false;
        }

        public bool KoopHotel()
        {
            if (!MagHotelKopen())
                throw new ApplicationException("Er mag slechts een hotel gekocht worden indien reeds 4 straten in bezit zijn");
            if (Eigenaar.Betaal(Stad.Huisprijs, new Speler("Bank")))
            {
                _huizenAantal = 0;
                _hotel = true;
                return _hotel;
            }
            return false;
        }

        public bool MagHuisKopen(int aantal)
        {
            return MagHuisKopen() && GeefAantalHuizen() + aantal <= 4;
        }

        public bool KoopHuis(int aantal)
        {
            bool gelukt = false;
            for (int i = 0; i < aantal; i++)
                gelukt = KoopHuis();
            return gelukt;
        }

    }
}
