using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein.gebeurtenis.kans;
using CRMonopoly.domein.velden;

namespace CRMonopoly.AI
{
    class VoorzichtigeHuisjesMelkendePlayerAI : AbstractPlayerAI
    {
        private double VERKOOPPRIJS_MULTIPLIER = 1.2;
        private double SAFETYZONE_MULTIPLIER = 1.5;

        protected override Gebeurtenis isErEenGebeurtenisAfTeHandelen(Speler speler)
        {
            Gebeurtenis gebeurtenis = null;
            gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.MayorEvent, speler, true);
            if (gebeurtenis == null) gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.OntvangGeld, speler, true);
            if (gebeurtenis == null) gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.BetaalGeld, speler, false);
            if (gebeurtenis == null) gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.Verplaats, speler, true);
            if (gebeurtenis == null) gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.Bouwen, speler, false);
            if (gebeurtenis == null) gebeurtenis = selecteerGebeurtenisVanType(GebeurtenisType.Aankopen, speler, false);

            return gebeurtenis;
        }

        protected override double MinimumBedragDatInKasMoetBlijven(MonopolyspelController controller)
        {
            return (this.SAFETYZONE_MULTIPLIER * controller.geefMaximalHuurprijs());
        }
    }


}
