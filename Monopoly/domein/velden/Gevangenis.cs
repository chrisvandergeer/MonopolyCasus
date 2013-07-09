using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.gebeurtenissen;
using Monopoly.domein.labels;

namespace Monopoly.domein.velden
{
    public class Gevangenis : Veld
    {
        private Dictionary<Speler, Laatste3Worpen> Gevangenen { get; set; }

        public Gevangenis()
            : base(Veldnamen.GEVANGENIS)
        {
            Gevangenen = new Dictionary<Speler, Laatste3Worpen>();
        }

        public override IGebeurtenis BepaalGebeurtenis()
        {
            return new Vrij("Op bezoek bij de gevangenis");
        }

        public void NieuweGevangene(Speler speler, Gebeurtenisresult gebeurtenisResult)
        {
            if (Gevangenen.Keys.Contains(speler))
                throw new ApplicationException(speler + " zit al in de gevangenis");
            speler.Verplaats(speler.Spel.Bord.GeefVeld(Veldnamen.GEVANGENIS));
            Gevangenen.Add(speler, new Laatste3Worpen());
            speler.BeurtGebeurtenissen.VoegResultToe(gebeurtenisResult);
        }

        public void LaatVrij(Speler speler, Gebeurtenisresult result)
        {
            Gevangenen.Remove(speler);
            speler.BeurtGebeurtenissen.VoegResultToe(result);
        }

        public bool IsGevangene(Speler speler)
        {
            return Gevangenen.Keys.Contains(speler);
        }

        private int AddWorp(Speler speler, Worp worp)
        {
            Gevangenen[speler].AddWorp(worp);
            return Gevangenen[speler].AantalWorpen();
        }

        public Gevangenis NotifyWorp(Speler speler, Worp worp)
        {
            if (IsGevangene(speler))
            {
                HandelWorpAfVoorGevangene(speler, worp);
            }
            else
            {
                HandelWorpAfVoorVrijeSpeler(speler, worp);
            }
            return this;
        }

        private void HandelWorpAfVoorVrijeSpeler(Speler speler, Worp worp)
        {
            GooiDobbelstenen gooiDobbelstenen = (GooiDobbelstenen)speler.BeurtGebeurtenissen.GeefGebeurtenis(Gebeurtenisnamen.GOOI_DOBBELSTENEN);
            if (gooiDobbelstenen.Is3MaalDubbelGegooit())
            {
                NieuweGevangene(speler, Gebeurtenisresult.Create(speler, "heeft 3x dubbel gegooit en belandt in de gevangenis"));
            }
        }

        private void HandelWorpAfVoorGevangene(Speler speler, Worp worp)
        {
            if (worp.IsDubbelGegooid() || AddWorp(speler, worp) == 3)
            {
                LaatVrij(speler, Gebeurtenisresult.Create(speler, "is vrij door dubbel te gooien in de gevangenis"));
            }
            else if (AddWorp(speler, worp) == 3)
            {
                LaatVrij(speler, Gebeurtenisresult.Create(speler, "is vrij na 3 ronden in de gevangenis"));
            }
        }
    }
}
