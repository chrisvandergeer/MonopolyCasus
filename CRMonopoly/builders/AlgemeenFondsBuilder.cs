﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.gebeurtenis.kans;

namespace CRMonopoly.builders
{
    class AlgemeenFondsBuilder
    {
        private Monopolyspel Spel { get; set; }
        private Monopolybord Bord { get; set; }

        public AlgemeenFondsBuilder(Monopolyspel spel)
        {
            Spel = spel;
            Bord = spel.Bord;
        }

        public List<Gebeurtenis> build()
        {
            List<Gebeurtenis> kaarten = new List<Gebeurtenis>();
            // U erft ƒ 100
            // U ontvangt rente van 7% preferente aandelen ƒ 25
            // Een vergissing van de bank in uw voordeel, u ontvangt ƒ 200
            // Ga terug naar Dorpsstraat (Ons Dorp)
            // Ga direct naar de gevangenis. Ga niet door "Start", u ontvangt geen ƒ 200
            // U bent jarig en ontvangt van iedere speler ƒ 10
            // U hebt de tweede prijs in een schoonheidswedstrijd gewonnen en ontvangt ƒ 10
            // Betaal uw doktersrekening ƒ 50
            // Betaal uw verzekeringspremie ƒ 50
            // Door verkoop van effecten ontvangt u ƒ 50
            kaarten.Add(new VerlaatDeGevangenis(kaarten));
            // Verlaat de gevangenis zonder betalen
            // Restitutie inkomstenbelasting, u ontvangt ƒ 20
            // Lijfrente vervalt, u ontvangt ƒ 100
            // Betaal het hospitaal ƒ 100
            // Ga verder naar "Start"
            // Betaal ƒ 10 boete of neem een Kanskaart
            return kaarten;
        }
    }
}
