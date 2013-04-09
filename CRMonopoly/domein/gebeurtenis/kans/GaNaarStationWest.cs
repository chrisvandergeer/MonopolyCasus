using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein.gebeurtenis;
using CRMonopoly.domein;

namespace MSMonopoly.domein.gebeurtenis.kans
{
    class GaNaarStationWest : Gebeurtenis
    {
        private Monopolybord _bord;

        public GaNaarStationWest(Monopolybord bord)
        {
            _bord = bord;
        }

        public bool VoerUit(Speler speler)
        {
            Veld huidigePositie = speler.HuidigePositie;
            Veld barteljorisstraat = _bord.GeefStationWest();
            if (KomtLangsStart(speler))
            {
                new OntvangGeld(200).VoerUit(speler);
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
            return "Reis naar station 'West' en indien u langs 'Start' komt, ontvangt u ƒ 200";
        }
    }
}
