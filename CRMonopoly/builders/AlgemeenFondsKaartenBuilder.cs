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
        [ThreadStatic]
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
                        {
                            _instance = new AlgemeenFondsKaartenBuilder();
                        }
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
                        _kaarten.Add(new OntvangGeld(100, "U erft euro 100"));
                        _kaarten.Add(new OntvangGeld(25, "U ontvangt rente van 7% preferente aandelen euro 25"));
                        _kaarten.Add(new OntvangGeld(200, "Een vergissing van de bank in uw voordeel, u ontvangt euro 200"));
                        _kaarten.Add(new GaTerugNaar(OnsDorpBuilder.Instance.OnsDorp.getStraatByName(OnsDorpBuilder.DORPSSTRAAT)));
                        _kaarten.Add(new GaNaarGevangenis());
                        // U bent jarig en ontvangt van iedere speler euro 10
                        _kaarten.Add(new OntvangGeld(10, "U hebt de tweede prijs in een schoonheidswedstrijd gewonnen en ontvangt euro 10"));
                        _kaarten.Add(new BetaalGeld(50, "Betaal uw doktersrekening euro 50"));
                        _kaarten.Add(new BetaalGeld(50, "Betaal uw verzekeringspremie euro 50"));
                        _kaarten.Add(new OntvangGeld(50, "Door verkoop van effecten ontvangt u euro 50"));
                        _kaarten.Add(new VerlaatDeGevangenis(_kaarten));
                        _kaarten.Add(new OntvangGeld(20, "Restitutie inkomstenbelasting, u ontvangt euro 20"));
                        _kaarten.Add(new OntvangGeld(100, "Lijfrente vervalt, u ontvangt euro 100"));
                        _kaarten.Add(new BetaalGeld(100, "Betaal het hospitaal euro 100"));
                        _kaarten.Add(new GaNaarGebeurtenis(Start.VELD_NAAM, "Ga verder naar 'Start'"));
                        // Betaal euro 10 boete of neem een Kanskaart
                    }
                }
            }
            return _kaarten;
        }
    }
}
