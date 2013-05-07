using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein;

namespace CRMonopoly.domein.gebeurtenis.kans
{
    public class BetaalGeld : AbstractGebeurtenis
    {
        private int Bedrag { get; set; }

        public BetaalGeld(int bedrag, string gebeurtenisnaam) : base(gebeurtenisnaam)
        {
            Bedrag = bedrag;
        }
        
        public override GebeurtenisResult VoerUit(Speler speler)
        {
            if (speler.Betaal(Bedrag, Speler.BANK))
            {
                return GebeurtenisResult.Uitgevoerd(Gebeurtenisnaam, "is uitgevoerd");
            }
            return GebeurtenisResult.NietUitgevoerd(Gebeurtenisnaam, "kon niet worden uitgevoerd vanwege onvoldoende saldo");
        }

        public override bool IsVerplicht()
        {
            return true;
        }

    }
}
