﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;

namespace CRMonopoly.domein.velden
{
    public class Station : Veld, VerkoopbaarVeld
    {
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
            return new BetaalHuur(this);
        }

        /// <summary>
        /// Geeft de te betalen huur, afhankelijk van hoeveel Stations de Speler in bezit heeft
        /// TODO: Methode werkt, maar kan veel korter
        /// </summary>
        /// <returns>te betalen huur</returns>
        public int GeefTeBetalenHuur()
        {
            int aantalInBezit = 0;
            int teBetalenHuur = 0;
            foreach (Station station in Stations.Values)
            {
                if (Eigenaar.Equals(station.Eigenaar))
                    aantalInBezit++;
            }
            for (int i = 0; i < aantalInBezit; i++)
            {
                teBetalenHuur = DoubleIt(teBetalenHuur);
            }
            return teBetalenHuur;
        }

        private int DoubleIt(int huur)
        {
            if (huur == 0)
                return 25;
            return huur + huur;
        }
        
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
            Station station = (Station) obj;
            return Naam.Equals(station.Naam);
        }

        public override int GetHashCode()
        {
            return Naam.GetHashCode();
        }
    }
}
