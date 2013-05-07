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
    class KanskaartBuilder : KaartenBuilder
    {
        public static readonly string KANS_NAAM = "Kans";

        private static string gaNaarBartiljorisstraat = "Ga verder naar Barteljorisstraat. Indien u langs 'Start' komt, ontvangt u ƒ 200";
        private static string gaNaarStationWest = "Reis naar station 'West' en indien u langs 'Start' komt, ontvangt u ƒ 200";
        private static string gaNaarStart = "Ga verder naar 'Start'";

        private List<Gebeurtenis> _kaarten = null;
        private static volatile KanskaartBuilder _instance;
        private static object _syncRoot = new Object();

        private Monopolybord Bord { get; set; }

        public static KanskaartBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new KanskaartBuilder();
                    }
                }

                return _instance;
            }
            private set { }
        }

        private KanskaartBuilder()
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
                        _kaarten.Add(new BetaalGeld(150, "Betaal schoolgeld ƒ 150"));
                        _kaarten.Add(new BetaalGeld(15, "Boete voor te snel rijden ƒ 15"));
                        _kaarten.Add(new GaNaarGebeurtenis(Bord.getBarteljorisstraat(), gaNaarBartiljorisstraat));
                        _kaarten.Add(new GaNaarGebeurtenis(Bord.GeefStationWest(), gaNaarStationWest));
                        _kaarten.Add(new GaNaarGebeurtenis(Bord.StartVeld(), gaNaarStart));
                        // Ga drie plaatsen terug
                        // Ga direct naar de gevangenis. Ga niet langs "Start". U ontvangt geen ƒ 200
                        _kaarten.Add(new GaNaarGebeurtenis(Bord.Straat(GroningenBuilder.HEERESTRAAT), "Ga verder naar de Herestraat. Indien u langs 'Start' komt ontvangt u ƒ 200"));
                        _kaarten.Add(new OntvangGeld(50, "De bank betaalt u ƒ 50 dividend"));
                        _kaarten.Add(new VerlaatDeGevangenis(_kaarten));
                        // Repareer uw huizen. Betaal voor elk huis ƒ 25, betaal voor elk hotel ƒ 100
                        // U wordt aangeslagen voor straatgeld. ƒ 40 per huis, ƒ 115 per hotel
                        _kaarten.Add(new OntvangGeld(150, "Uw bouwverzekering vervalt, u ontvangt ƒ 150"));
                        _kaarten.Add(new BetaalGeld(20, "Aangehouden wegens dronkenschap ƒ 20 boete"));
                        _kaarten.Add(new GaNaarGebeurtenis(Bord.Straat(AmsterdamBuilder.KALVERSTRAAT), "Ga verder naar Kalverstraat"));
                        _kaarten.Add(new OntvangGeld(100, "U hebt een kruiswoordpuzzel gewonnen en ontvangt ƒ 100"));
                    }
                }
            }
            return _kaarten;
        }
        public Veld getKansVeld(Monopolybord bord)
        {
            if (Bord == null)
            {
                Bord = bord;
            }
            KansEnAlgemeenfondsVeld veld = new KansEnAlgemeenfondsVeld(KANS_NAAM);
            veld.Builder = this;
            return veld;
        }

    }
}
