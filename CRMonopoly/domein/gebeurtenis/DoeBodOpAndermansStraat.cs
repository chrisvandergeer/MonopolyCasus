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
        
        private int _bod = -1;
        public DoeBodOpAndermansStraat(VerkoopbaarVeld straat, int bod)
            : base(String.Format("Breng een bod uit op {0} van {1}.", straat, bod), GebeurtenisType.Aankopen)
        {
            StraatOmOpTeBieden = straat;
            _bod = bod;
            Console.WriteLine(String.Format("DoeBodOpAndermansStraat: {0}; {1}", StraatOmOpTeBieden, bod));
        }
        public override GebeurtenisResult VoerUit(Speler speler)
        {
            Speler straatEigenaar = StraatOmOpTeBieden.Eigenaar;
            bool bodGeaccepteerd = StraatOmOpTeBieden.Eigenaar.verwerkBodOpStraat(StraatOmOpTeBieden, speler, _bod);
            if (! bodGeaccepteerd)
            {
                return GebeurtenisResult.NietUitgevoerd(straatEigenaar, "heeft een bod van", _bod, "van speler", speler.Name, "op", StraatOmOpTeBieden.Naam, "niet geaccepteerd");
            }
            return GebeurtenisResult.Uitgevoerd("Het bod van", _bod, "van speler", speler.Name, "op", StraatOmOpTeBieden.Naam, "is geaccepteerd door", straatEigenaar);
        }

        public override bool IsVerplicht()
        {
            return false;
        }
    }
}
