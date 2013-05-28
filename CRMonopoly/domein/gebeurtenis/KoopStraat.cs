using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMonopoly.domein;
using CRMonopoly.domein.velden;

namespace CRMonopoly.domein.gebeurtenis
{
    class KoopStraat : AbstractGebeurtenis
    {
        public volatile static string NAAM = "Koop straat";

        public VerkoopbaarVeld TeKopenStraat { get; private set; }  
      
        public KoopStraat(VerkoopbaarVeld straat) : base(NAAM, GebeurtenisType.Aankopen)
        {
            TeKopenStraat = straat;
        }

        public override GebeurtenisResult VoerUit(Speler koper)
        {
            if (koper.Betaal(TeKopenStraat.GeefAankoopprijs(), new Speler("Bank")))
            {
                koper.Add(TeKopenStraat);
                TeKopenStraat.Eigenaar = koper;
                return GebeurtenisResult.Uitgevoerd(koper, "koopt", TeKopenStraat);
            }            
            return GebeurtenisResult.NietUitgevoerd(koper, "kan", TeKopenStraat, "niet betalen");
        }

        public override bool IsVerplicht()
        {
            return false;
        }
    }
}
