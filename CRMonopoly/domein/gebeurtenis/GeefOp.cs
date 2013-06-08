using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMonopoly.domein.gebeurtenis
{
    class GeefOp: AbstractGebeurtenis
    {
        private string oorzaak;
        public GeefOp(string id, string oorzaak) : base(id, GebeurtenisType.MayorEvent)
        {
            this.oorzaak = oorzaak;
        }

        public override GebeurtenisResult VoerUit(Speler speler)
        {
            return GebeurtenisResult.Uitgevoerd(speler, "moet opgeven omdat", oorzaak);
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override string ToString()
        {
            return string.Format("Opgeven: {0}", Gebeurtenisnaam);
        }
    }
}
