using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.gebeurtenis.kans;
using CRMonopoly.domein.velden;

namespace CRMonopoly.builders
{
    class AlgemeenFondsKaartenBuilder : KaartenBuilder
    {
        private List<Gebeurtenis> _kaarten = null;
        private static object _syncRoot = new Object();
        private static volatile AlgemeenFondsKaartenBuilder _instance;

        internal Monopolybord Bord { get; set; }

        private AlgemeenFondsKaartenBuilder()
        {
        }
        public static AlgemeenFondsKaartenBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new AlgemeenFondsKaartenBuilder();
                    }
                }

                return _instance;
            }
            private set { }
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
                        _kaarten.Add(new OntvangGeld(100, "U erft ƒ 100"));
                        _kaarten.Add(new OntvangGeld(25, "U ontvangt rente van 7% preferente aandelen ƒ 25"));
                        _kaarten.Add(new OntvangGeld(200, "Een vergissing van de bank in uw voordeel, u ontvangt ƒ 200"));
                        // Ga terug naar Dorpsstraat (Ons Dorp)
                        // Ga direct naar de gevangenis. Ga niet door "Start", u ontvangt geen ƒ 200
                        // U bent jarig en ontvangt van iedere speler ƒ 10
                        _kaarten.Add(new OntvangGeld(10, "U hebt de tweede prijs in een schoonheidswedstrijd gewonnen en ontvangt ƒ 10"));
                        _kaarten.Add(new BetaalGeld(50, "Betaal uw doktersrekening ƒ 50"));
                        _kaarten.Add(new BetaalGeld(50, "Betaal uw verzekeringspremie ƒ 50"));
                        _kaarten.Add(new OntvangGeld(50, "Door verkoop van effecten ontvangt u ƒ 50"));
                        _kaarten.Add(new VerlaatDeGevangenis(_kaarten));
                        _kaarten.Add(new OntvangGeld(20, "Restitutie inkomstenbelasting, u ontvangt ƒ 20"));
                        _kaarten.Add(new OntvangGeld(100, "Lijfrente vervalt, u ontvangt ƒ 100"));
                        _kaarten.Add(new BetaalGeld(100, "Betaal het hospitaal ƒ 100"));
                        _kaarten.Add(new GaNaarGebeurtenis(Start.VELD_NAAM, "Ga verder naar 'Start'"));
                        // Betaal ƒ 10 boete of neem een Kanskaart
                    }
                }
            }
            return _kaarten;
        }
    }
}
