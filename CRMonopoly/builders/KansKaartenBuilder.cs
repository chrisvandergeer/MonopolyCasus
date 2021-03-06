﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.gebeurtenis.kans;
using CRMonopoly.domein.velden;

namespace CRMonopoly.builders
{
    class KansKaartenBuilder : KaartenBuilder
    {

        private static string gaNaarBartiljorisstraat = "Ga verder naar Barteljorisstraat. Indien u langs 'Start' komt, ontvangt u euro 200";
        private static string gaNaarStationWest = "Reis naar station 'West' en indien u langs 'Start' komt, ontvangt u euro 200";
        private static string gaNaarStart = "Ga verder naar 'Start'";

        private List<Gebeurtenis> _kaarten = null;

        [ThreadStatic]
        private static volatile KansKaartenBuilder _instance;
        private static object _syncRoot = new Object();

        internal Monopolybord Bord { get; set; }

        public static KansKaartenBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new KansKaartenBuilder();
                    }
                }

                return _instance;
            }
            private set { }
        }

        private KansKaartenBuilder()
        {
        }

        public List<Gebeurtenis> getStapelKaarten()
        {
            if (_kaarten == null)
            {
                lock (_syncRoot)
                {
                    if (_kaarten == null)
                    {
                        _kaarten = new List<Gebeurtenis>();
                        _kaarten.Add(new BetaalGeld(150, "Betaal schoolgeld euro 150"));
                        _kaarten.Add(new BetaalGeld(15, "Boete voor te snel rijden euro 15"));
                        _kaarten.Add(new GaNaarGebeurtenis(HaarlemBuilder.BARTELJORISSTRAAT, gaNaarBartiljorisstraat));
                        _kaarten.Add(new GaNaarGebeurtenis(Stationbuilder.WEST, gaNaarStationWest));
                        _kaarten.Add(new GaNaarGebeurtenis(Start.VELD_NAAM, gaNaarStart));
                        _kaarten.Add(new Ga3PlaatsenTerug());
                        _kaarten.Add(new GaNaarGevangenis());
                        _kaarten.Add(new GaNaarGebeurtenis(GroningenBuilder.HEERESTRAAT, "Ga verder naar de Heerestraat. Indien u langs 'Start' komt ontvangt u euro 200"));
                        _kaarten.Add(new OntvangGeld(50, "De bank betaalt u euro 50 dividend"));
                        _kaarten.Add(new VerlaatDeGevangenis(_kaarten));
                        // Repareer uw huizen. Betaal voor elk huis euro 25, betaal voor elk hotel euro 100
                        // U wordt aangeslagen voor straatgeld. euro 40 per huis, euro 115 per hotel
                        _kaarten.Add(new OntvangGeld(150, "Uw bouwverzekering vervalt, u ontvangt euro 150"));
                        _kaarten.Add(new BetaalGeld(20, "Aangehouden wegens dronkenschap euro 20 boete"));
                        _kaarten.Add(new GaNaarGebeurtenis(AmsterdamBuilder.KALVERSTRAAT, "Ga verder naar Kalverstraat"));
                        _kaarten.Add(new OntvangGeld(100, "U hebt een kruiswoordpuzzel gewonnen en ontvangt euro 100"));
                    }
                }
            }
            return _kaarten;
        }
    }
}
