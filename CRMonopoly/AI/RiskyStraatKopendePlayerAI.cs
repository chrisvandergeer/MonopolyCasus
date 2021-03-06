﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.gebeurtenis.kans;
using CRMonopoly.domein.velden;

namespace CRMonopoly.AI
{
    class RiskyStraatKopendePlayerAI : AbstractPlayerAI
    {
        private double VERKOOPPRIJS_MULTIPLIER = 1.2;

        // Extra zaken afhandelen binnen de worp.
        public override void HandelExtraZakenAfBinnenDeWorp(Speler speler)
        {
            Console.WriteLine(String.Format("{0}: {1} bepaald wat extra gebeurtenissen uit te voeren.", speler.Name, this.GetType()));
            gaNaOfErStratenTeKoopZijn(speler);
            gaNaOfIkHuizenKanBouwen(speler);
        }

        protected override Gebeurtenis isErEenGebeurtenisAfTeHandelen(Speler speler)
        {
            Gebeurtenis gebeurtenis = null;
            gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.MayorEvent, speler, true);
            if (gebeurtenis == null) gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.OntvangGeld, speler, true);
            if (gebeurtenis == null) gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.BetaalGeld, speler, false);
            if (gebeurtenis == null) gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.Verplaats, speler, true);
            if (gebeurtenis == null) gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.Aankopen, speler, false);
            if (gebeurtenis == null) gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.Bouwen, speler, false);

            return gebeurtenis;
        }

        protected override double MinimumBedragDatInKasMoetBlijven(Speler speler)
        {
            return 0.0;
        }
    }
}
