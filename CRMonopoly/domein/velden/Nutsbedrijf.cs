﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.builders;

namespace CRMonopoly.domein.velden
{
    public class Nutsbedrijf : Veld, VerkoopbaarVeld
    {
        private Speler _eigenaar = null;
        public Hypotheek Hypotheek { get; private set; }

        public Nutsbedrijf(string naam)
            : base(naam)
        {
            Hypotheek = new Hypotheek(this);
        }

        public Speler Eigenaar
        {
            get
            {
                return _eigenaar;
            }
            set
            {
                removeThisFromPossiblePreviousOwner();
                _eigenaar = value;
                addThisToNewOwner();
                informHuurChange();
            }
        }
        private void addThisToNewOwner()
        {
            _eigenaar.Add(this);
        }
        private void removeThisFromPossiblePreviousOwner()
        {
            if (_eigenaar != null)
            {
                _eigenaar.Remove(this);
            }
        }
        public bool heeftEigenaar()
        {
            return Eigenaar != null;
        }

        private void informHuurChange()
        {
            // Maximale worp is 12
            int newHuurprijs = getMultiplier() * 12;
            myHuurChangeListeners.ForEach(listener => listener.informHuurChange(newHuurprijs));
        }

        public override Gebeurtenis bepaalGebeurtenis(Speler speler)
        {
            if (isVerkocht())
            {
                return new BetaalHuur(this);
            }
            return new KoopStraat(this);
        }

        private bool isVerkocht()
        {
            return Eigenaar != null;
        }

        /// <summary>
        /// Geeft de te betalen huur, afhankelijk van hoeveel Nutsbedrijven de Speler in bezit heeft
        /// en de worp (aantal ogen van de worp)
        /// Wanneer één nutsbedrijf in bezit is, bedraagt de huur 4 keer het gegooide aantal ogen
        /// Wanneer beide nutsbedrijven in bezit zijn, bedraagt de huur 10 keer het gegooide aantal ogen
        /// </summary>
        /// <returns>te betalen huur</returns>
        public int GeefTeBetalenHuur(Speler bezoeker)
        {
            int multiplier = getMultiplier();
            int worp = bezoeker.WorpenInHuidigeBeurt.LaatsteWorp().Totaal();
            return multiplier * worp;
        }
        private int getMultiplier()
        {
            return Eigenaar.AantalNutsbedrijven() == 1 ? 4 : 10;
        }

        public int GeefAankoopprijs()
        {
            return 150;
        }

        public Speler GeefEigenaar()
        {
            return Eigenaar;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (! (obj is Nutsbedrijf)) return false;

            Nutsbedrijf nutsBedrijf = (Nutsbedrijf)obj;
            return Naam.Equals(nutsBedrijf.Naam);
        }

        public override int GetHashCode()
        {
            return Naam.GetHashCode();
        }

    }
}
