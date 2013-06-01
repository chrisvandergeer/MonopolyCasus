using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein.gebeurtenis
{
    public class DoeBodOpAndermansStraat : AbstractGebeurtenis
    {
        private VerkoopbaarVeld _verkoopbaarVeld = null;
        private int _bod = -1;
        public DoeBodOpAndermansStraat(VerkoopbaarVeld verkoopbaarVeld) : base("Doe bod op '" + verkoopbaarVeld.Naam + "'.")
        {
            _verkoopbaarVeld = verkoopbaarVeld;
        }
        public void setBod(int bod)
        {
            _bod = bod;
        }
        public override GebeurtenisResult VoerUit(Speler speler)
        {
            bool bodGeaccepteerd = _verkoopbaarVeld.Eigenaar.verwerkBodOpStraat(_verkoopbaarVeld,speler, _bod);
            if (! bodGeaccepteerd)
            {
                return GebeurtenisResult.NietUitgevoerd( _verkoopbaarVeld.Eigenaar.Name, "heeft een bod van", _bod, "van speler", speler.Name, "op", _verkoopbaarVeld.Naam, "niet geaccepteerd");
            }
            return GebeurtenisResult.Uitgevoerd("Het bod van", _bod, "van speler", speler.Name, "op", _verkoopbaarVeld.Naam, "is geaccepteerd door", _verkoopbaarVeld.Eigenaar.Name);
        }

        public override bool IsVerplicht()
        {
            return false;
        }
    }
}
