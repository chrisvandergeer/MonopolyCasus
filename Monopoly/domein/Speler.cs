﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;
using Monopoly.domein.gebeurtenissen;
using Monopoly.domein.labels;
using Monopoly.AI;

namespace Monopoly.domein
{
    public class Speler
    {
        public Monopolyspel Spel                        { get; set; }
        public Veld Positie                             { get; set; }        
        public string Spelernaam                        { get; private set; }
        public Gebeurtenislijst BeurtGebeurtenissen     { get; set; }
        public Bezittingen Bezittingen                  { get; set; }
        private IAIDecider myAI;

        public Speler(string spelersnaam, IAIDecider ai, Monopolyspel spel)
        {
            myAI = ai;
            Spel = spel;
            Spelernaam = spelersnaam;
            Bezittingen = new Bezittingen();
            BeurtGebeurtenissen = new Gebeurtenislijst(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is Speler)
            {
                String naam = ((Speler)obj).Spelernaam;
                return naam == null ? Spelernaam == null : naam.Equals(Spelernaam);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Spelernaam == null ? 0 : Spelernaam.GetHashCode();
        }

        public override string ToString()
        {
            
            return Spelernaam == null ? "[null]" : Spelernaam;
        }

        public bool IsGevangene()
        {
            return Spel.Bord.Gevangenis().IsGevangene(this);
        }

        public void Verplaats(Worp worp)
        {
            Gevangenis gevangenis = Spel.Bord.Gevangenis();
            gevangenis.NotifyWorp(this, worp);
            if (!IsGevangene())
            {
                PasseerStartGebeurtenis passeerStart = new PasseerStartGebeurtenis(Positie);
                Veld nieuwePositie = Spel.Bord.GeefVeld(Positie, worp);
                Verplaats(nieuwePositie);
                passeerStart.Voeruit(this);
            }
        }

        public void Verplaats(Veld nieuwePositie)
        {
            Positie = nieuwePositie;
            BeurtGebeurtenissen.VoegResultToe(Gebeurtenisresult.Create(this, "staat nu op", Positie));
            IGebeurtenis gebeurtenis = Positie.BepaalGebeurtenis();
            if (gebeurtenis.IsVerplicht())
                gebeurtenis.Voeruit(this);
            else
                BeurtGebeurtenissen.VoegGebeurtenisToe(gebeurtenis);   
        }

        public Gebeurtenislijst BepaalGebeurtenissenBijAanvangBeurt()
        {
            BeurtGebeurtenissen.MaakLeeg();
            BeurtGebeurtenissen.VoegGebeurtenisToe(new GooiDobbelstenen());
            BeurtGebeurtenissen.VoegGebeurtenisToe(new LosHypotheekAf());
            BeurtGebeurtenissen.VoegGebeurtenisToe(new KoopHuis());
            BeurtGebeurtenissen.VoegGebeurtenisToe(new VerkoopHuis());
            BeurtGebeurtenissen.VoegGebeurtenisToe(new NeemHypotheek());
            BeurtGebeurtenissen.VoegGebeurtenisToe(new DoeBodOpAndersmansStraat());
            //BeurtGebeurtenissen.VoegGebeurtenisToe(new VerlaatDeGevangenis());
            BeurtGebeurtenissen.VoegGebeurtenisToe(new EindeBeurt());
            BeurtGebeurtenissen.VoegGebeurtenisToe(new EindeSpel());
            return BeurtGebeurtenissen;
        }

        public void SpeelGebeurtenis(string gebeurtenisnaam)
        {
            BeurtGebeurtenissen.GeefGebeurtenis(gebeurtenisnaam).Voeruit(this);
        }

        public bool IsHuidigespeler()
        {
            return Spelernaam.Equals(Spel.HuidigeSpeler.Spelernaam);
        }


        public string Decide()
        {
            return myAI.Decide(Spel);
        }
    }
}
