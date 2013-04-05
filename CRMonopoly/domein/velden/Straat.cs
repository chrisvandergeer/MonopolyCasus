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
                return new BetaalHuur(speler, this);
            }

            return new KoopStraat(speler, this);
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

    }
}
