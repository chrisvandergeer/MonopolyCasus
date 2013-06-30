using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;
using Monopoly.domein.labels;
using Monopoly.domein.gebeurtenissen;
using Monopoly.domein;

namespace Monopoly.builders
{
    public class Gebeurtenisveldbuilder
    {
        private Spelbord Bord { get; set; }

        public Gebeurtenisveldbuilder(Spelbord bord)
        {
            Bord = bord;
        }

        public Gebeurtenisveld BuildStart()
        {
            return new Gebeurtenisveld(
                Veldnamen.START, new OntvangGeld(400).SetTekst(GebeurtenisMelding.OP_START));
        }

        public Gebeurtenisveld BuildInkomstenBelasting()
        {
            return new Gebeurtenisveld(
                Veldnamen.INKOMSTENBELASTING,
                new BetaalGeld(200).SetTekst(GebeurtenisMelding.INKOMSTENBELASTING200));
        }

        public Gebeurtenisveld BuildExtraInkomstenBelasting()
        {
            return new Gebeurtenisveld(
                Veldnamen.EXTRAINKOMSTENBELASTING,
                new BetaalGeld(200).SetTekst(GebeurtenisMelding.EXTRAINKOMSTENBELASTING200));
        }

        public Gebeurtenisveld BuildAlgemeenFonds()
        {
            return new Gebeurtenisveld(
                Veldnamen.ALGEMEEN_FONDS,
                new AlgemeenFondsKaartenbuilder(Bord).build());
        }
        public Gebeurtenisveld BuildKans()
        {
            return new Gebeurtenisveld(
                Veldnamen.KANS,
                new AlgemeenFondsKaartenbuilder(Bord).build());
        }
        public Gebeurtenisveld BuildVrijParkeren()
        {
            return new Gebeurtenisveld(
                Veldnamen.VRIJ_PARKEREN,
                new Vrij("Vrij parkeren"));
        }
        public Gebeurtenisveld BuildGevangenis()
        {
            return new Gebeurtenisveld(
                Veldnamen.GEVANGENIS, 
                new GevangenisGebeurtenis());
        }
        public Gebeurtenisveld BuildGaNaarGevangenis()
        {
            return new Gebeurtenisveld(
                Veldnamen.GA_NAAR_GEVANGENIS,
//                VerplaatsSpeler.CreateVerplaatsVooruitGeenStartgeld("Ga naar gevangenis.", Bord.GeefVeld(Veldnamen.GEVANGENIS))
                new GaDirectNaarDeGevangenis()
                );
        }
    }
}
