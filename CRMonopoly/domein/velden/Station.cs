using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein.velden
{
    public class Station : Veld, VerkoopbaarVeld
    {
        private static int[] huurprijzenPerStationsInBezit = { 0, 25, 50, 100, 200 };

        public Dictionary<string, Station> Stations { get; set; }
        public Speler Eigenaar { get; set; }

        public Station(String naam, Dictionary<string, Station> stations) : this(naam)
        {
            Stations = stations;
        }

        public Station(string naam) : base(naam) 
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

        public bool isVerkocht()
        {
            return Eigenaar != null;
        }

        /// <summary>
        /// Geeft de te betalen huur, afhankelijk van hoeveel Stations de Speler in bezit heeft
        /// </summary>
        /// <returns>te betalen huur</returns>
        public int GeefTeBetalenHuur(Speler bezoeker)
        {
            int aantalInBezit = geefAantalStationsInBezitVanEigenaar();
            int teBetalenHuur = huurprijzenPerStationsInBezit[aantalInBezit];
            return teBetalenHuur;
        }

        private int geefAantalStationsInBezitVanEigenaar()
        {
            int aantalInBezit = 0;
            foreach (Station station in Stations.Values)
            {
                if (Eigenaar.Equals(station.Eigenaar))
                    aantalInBezit++;
            }
            return aantalInBezit;
        }

        //private int DoubleIt(int huur)
        //{
        //    if (huur == 0)
        //        return 25;
        //    return huur + huur;
        //}
        
        public int GeefAankoopprijs()
        {
            return 200;
        }

        public Speler GeefEigenaar()
        {
            return Eigenaar;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Station)) return false;

            Station station = (Station) obj;
            return Naam.Equals(station.Naam);
        }

        public override int GetHashCode()
        {
            return Naam.GetHashCode();
        }
    }
}
