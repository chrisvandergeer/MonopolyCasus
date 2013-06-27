using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein.gebeurtenis
{
    public class NeemHypotheekGebeurtenis : AbstractGebeurtenis
    {
        public NeemHypotheekGebeurtenis() : base(Gebeurtenisnamen.NEEM_HYPOTHEEK) { }

        public override GebeurtenisResult VoerUit(Speler speler)
        {
            VerkoopbaarVeld straat = speler.getStraten().FindLast(str => !str.Hypotheek.IsOnderHypotheek);
            straat.Hypotheek.NeemHypotheek();
            return GebeurtenisResult.Uitgevoerd(speler, "neemt hypotheek op", straat);
        }

        public override bool IsVerplicht()
        {
            return false;
        }

    }
}