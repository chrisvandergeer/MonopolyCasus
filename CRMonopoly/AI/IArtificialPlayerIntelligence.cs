using System;
namespace CRMonopoly.AI
{
    public interface IArtificialPlayerIntelligence
    {
        void HandelExtraZakenAfBinnenDeWorp(CRMonopoly.domein.Speler speler, CRMonopoly.domein.MonopolyspelController controller);
        void HandelWorpAf(CRMonopoly.domein.Speler speler);
    }
}
