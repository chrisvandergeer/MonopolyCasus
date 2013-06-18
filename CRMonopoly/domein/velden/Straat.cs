using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein
{
    public class Straat : Veld, VerkoopbaarVeld
    {
        public Hypotheek Hypotheek { get; private set; }

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
        private Speler _eigenaar = null;
        public Speler Eigenaar
        {
            get
            {
                return _eigenaar;
            }
            set
            {
                removeThisFromPossiblePreviousOwner();
                _eigenaar = value;
                addThisToNewOwner();
                informHuurChange();
            }
        }

        private void addThisToNewOwner()
        {
            _eigenaar.Add(this);
        }
        private void removeThisFromPossiblePreviousOwner()
        {
            if (_eigenaar != null)
            {
                _eigenaar.Remove(this);
            }
        }
        public bool heeftEigenaar()
        {
            return Eigenaar != null;
        }
        private void informHuurChange()
        {
            myHuurChangeListeners.ForEach(listener => listener.informHuurChange(this.GeefTeBetalenHuur(null)));
        }

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
            Hypotheek = new Hypotheek(this);
        }

        internal Straat(string straatnaam)
            : base(straatnaam)  { }

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

        public int GeefTeBetalenHuur(Speler bezoeker)
        {
            return Huurprijzen.GeefTeBetalenHuur(this);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Straat)) return false;

            Straat straat = (Straat) obj;
            return straat.Naam.Equals(Naam);
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
                informHuurChange();
                return true;
            }
            return false;
        }

        public bool KoopHotel()
        {
            if (!MagHotelKopen())
                throw new ApplicationException("Er mag slechts een hotel gekocht worden indien er 4 huizen op staan");
            if (Eigenaar.Betaal(Stad.Huisprijs, new Speler("Bank")))
            {
                _huizenAantal = 0;
                _hotel = true;
                informHuurChange();
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
        
        public int GeefAankoopprijs()
        {
            return Aankoopprijs;
        }

        public Speler GeefEigenaar()
        {
            return Eigenaar;
        }

    }
}
