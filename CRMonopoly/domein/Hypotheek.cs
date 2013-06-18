using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein
{
    public class Hypotheek
    {
        private VerkoopbaarVeld HypotheekObject { get; set; }
        public bool IsOnderHypotheek { get; private set; }

        public Hypotheek(VerkoopbaarVeld eigendom)
        {
            HypotheekObject = eigendom;
        }

        public bool NeemHypotheek()
        {
            Speler eigenaar = HypotheekObject.Eigenaar;
            if (IsOnderHypotheek)
                return false;
            eigenaar.Ontvang(HypotheekObject.GeefAankoopprijs() / 2);
            IsOnderHypotheek = true;
            return true;
        }

        public bool LosHypotheekAf()
        {
            if (IsOnderHypotheek)
            {
                Speler eigenaar = HypotheekObject.Eigenaar;
                int hypotheekBedrag = HypotheekObject.GeefAankoopprijs() / 2;
                int aflosBedrag = hypotheekBedrag + (int)(hypotheekBedrag * 0.1);
                if (eigenaar.Betaal(aflosBedrag));
                {
                    IsOnderHypotheek = false;
                    return true;
                }
            }
            return false;
        }
    }
}
