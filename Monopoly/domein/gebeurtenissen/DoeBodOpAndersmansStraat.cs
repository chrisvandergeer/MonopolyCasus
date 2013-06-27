using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

namespace Monopoly.domein.gebeurtenissen
{
    public class DoeBodOpAndersmansStraat : Gebeurtenis
    {
        public DoeBodOpAndersmansStraat() : base(Gebeurtenisnamen.DOE_BOD_OPANDERMANSTRAAT) { }

        public override bool IsVerplicht()
        {
            return false;
        }

        public override bool IsUitvoerbaar(Speler speler)
        {
            return StedenOmTeBieden(speler).Count > 0;
        }

        public override void Voeruit(Speler speler)
        {
            Straat straat = StedenOmTeBieden(speler)[0].Straten.Find(s => !s.Eigenaar.Equals(speler));
            Speler eigenaar = straat.Eigenaar;
            if (straat.Verkoop(speler))
            {
                Gebeurtenisresult result = Gebeurtenisresult.Create(speler, "koopt*", straat, "van", eigenaar);
                speler.BeurtGebeurtenissen.VoegResultToe(result);
            }
            else
            {
                speler.BeurtGebeurtenissen.VerwijderGebeurtenis(this);
            }
            
        }


        private List<Stad> StedenOmTeBieden(Speler speler)
        {
            List<Stad> alleStratenVerkocht = speler.Bezittingen.GeefStedenMetStraatInBezit().FindAll(stad => stad.IsAllesVerkocht());
            List<Stad> stadNietVolledigInBezit = alleStratenVerkocht.FindAll(stad => !stad.BezitStad(speler));
            return stadNietVolledigInBezit.FindAll(stad => stad.BezitHelft(speler));
        }
    }
}
