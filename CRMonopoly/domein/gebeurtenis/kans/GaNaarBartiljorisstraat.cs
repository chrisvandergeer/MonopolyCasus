using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein;
using CRMonopoly.builders;

namespace CRMonopoly.domein.gebeurtenis.kans
{
    class GaNaarBartiljorisstraat : Gebeurtenis
    {
        private Monopolybord _bord;

        public GaNaarBartiljorisstraat(Monopolybord bord) {
            _bord = bord;
        }

        public bool VoerUit(Speler speler)
        {
            Veld huidigePositie = speler.HuidigePositie; 
            Veld barteljorisstraat = _bord.getBarteljorisstraat();
            if (KomtLangsStart(speler))
            {
                new OntvangGeld(300).VoerUit(speler);
            }
            speler.Verplaats(barteljorisstraat);
            return true;
        }

        private bool KomtLangsStart(Speler speler)
        {
            Veld huidigePositie = speler.HuidigePositie;
            Veld barteljorisstraat = _bord.getBarteljorisstraat();
            return _bord.GeefPositie(huidigePositie) > _bord.GeefPositie(barteljorisstraat);
        }

        public bool IsVerplicht()
        {
            return true;
        }

        public string Gebeurtenisnaam()
        {
            return "Betaal schoolgeld ƒ 150";
        }
    }
}
