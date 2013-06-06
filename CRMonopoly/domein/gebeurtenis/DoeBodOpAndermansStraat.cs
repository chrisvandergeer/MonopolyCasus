using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein.gebeurtenis
{
    public class DoeBodOpAndermansStraat : AbstractGebeurtenis
    {
        public VerkoopbaarVeld StraatOmOpTeBieden { get; private set; }
        public List<VerkoopbaarVeld> StratenOmOpTeBieden { get; private set; }
        
        private int _bod = -1;
        public DoeBodOpAndermansStraat(List<VerkoopbaarVeld> verkoopbareVelden) : base("Er is een bod mogelijk op " + verkoopbareVelden.Count + " verkoorbareVelden.", GebeurtenisType.Aankopen)
        {
            StratenOmOpTeBieden = verkoopbareVelden;
        }
        public void setBod(Straat straat, int bod)
        {
            StraatOmOpTeBieden = straat;
            _bod = bod;
        }
        public override GebeurtenisResult VoerUit(Speler speler)
        {
            bool bodGeaccepteerd = StraatOmOpTeBieden.Eigenaar.verwerkBodOpStraat(StraatOmOpTeBieden, speler, _bod);
            if (! bodGeaccepteerd)
            {
                return GebeurtenisResult.NietUitgevoerd(StraatOmOpTeBieden.Eigenaar.Name, "heeft een bod van", _bod, "van speler", speler.Name, "op", StraatOmOpTeBieden.Naam, "niet geaccepteerd");
            }
            return GebeurtenisResult.Uitgevoerd("Het bod van", _bod, "van speler", speler.Name, "op", StraatOmOpTeBieden.Naam, "is geaccepteerd door", StraatOmOpTeBieden.Eigenaar.Name);
        }

        public override bool IsVerplicht()
        {
            return false;
        }
    }
}
