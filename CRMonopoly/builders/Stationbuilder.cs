using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.velden;

namespace MSMonopoly.builders
{
    class Stationbuilder
    {
        private static readonly string NOORD = "Station Noord";
        private static readonly string OOST = "Station Oost";
        private static readonly string ZUID = "Station Zuid";
        private static readonly string WEST = "Station West";

        private static Stationbuilder _instance = null;
        private List<Station> Stations { get; set; }

        public static Stationbuilder GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Stationbuilder();
                _instance.Stations = new List<Station>();
                Station noord = new Station(NOORD, _instance.Stations);
                Station oost = new Station(OOST, _instance.Stations);
                Station zuid = new Station(ZUID, _instance.Stations);
                Station west = new Station(WEST, _instance.Stations);
                _instance.Stations.Add(noord); _instance.Stations.Add(oost); 
                _instance.Stations.Add(zuid); _instance.Stations.Add(west);

            }
            return _instance;
        }

        public Station Noord()
        {
            return Station(NOORD);
        }

        public Station Oost()
        {
            return Station(OOST);
        }

        public Station Zuid()
        {
            return Station(ZUID);
        }

        public Station West()
        {
            return Station(WEST);
        }

        private Station Station(string naam)
        {
            Station station = new Station(naam, new List<Station>());
            station.Naam = naam;
            int indexOf = Stations.IndexOf(station);
            return Stations[indexOf];
        }
    }
}
