using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.velden;

namespace CRMonopoly.builders
{
    class Stationbuilder
    {
        private static readonly string NOORD = "Station Noord";
        private static readonly string OOST = "Station Oost";
        private static readonly string ZUID = "Station Zuid";
        private static readonly string WEST = "Station West";

        private static Stationbuilder _instance = null;
        private Dictionary<string, Station> Stations { get; set; }

        public static Stationbuilder GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Stationbuilder();
                _instance.Stations = new Dictionary<string, Station>();
                Station noord = new Station(NOORD, _instance.Stations);
                Station oost = new Station(OOST, _instance.Stations);
                Station zuid = new Station(ZUID, _instance.Stations);
                Station west = new Station(WEST, _instance.Stations);
                _instance.Stations.Add(NOORD, noord); _instance.Stations.Add(OOST, oost); 
                _instance.Stations.Add(ZUID, zuid); _instance.Stations.Add(WEST, west);

            }
            return _instance;
        }

        public Station Noord()
        {
            return Stations[NOORD];
        }

        public Station Oost()
        {
            return Stations[OOST];
        }

        public Station Zuid()
        {
            return Stations[ZUID];
        }

        public Station West()
        {
            return Stations[WEST];
        }

    }
}
