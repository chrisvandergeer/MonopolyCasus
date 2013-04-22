﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein;

namespace CRMonopoly.domein.gebeurtenis.kans
{
    class GaNaarGebeurtenis : AbstractGebeurtenis
    {
        private Veld Bestemming { get; set; }

        public GaNaarGebeurtenis(Veld bestemming, string gebeurtenisnaam) : base(gebeurtenisnaam)
        {
            Bestemming = bestemming;
        }

        public override bool VoerUit(Speler speler)
        {
            Veld huidigePositie = speler.HuidigePositie;

            if (KomtLangsStart(speler))
            {
                new OntvangGeld(200).VoerUit(speler);
            }
            speler.Verplaats(Bestemming);
            return true;
        }

        private bool KomtLangsStart(Speler speler)
        {
            Veld huidigePositie = speler.HuidigePositie;
            Monopolybord bord = huidigePositie.Bord;
            return bord.GeefPositie(huidigePositie) > bord.GeefPositie(Bestemming);
        }

        public override bool IsVerplicht()
        {
            return true;
        }
    }
}
