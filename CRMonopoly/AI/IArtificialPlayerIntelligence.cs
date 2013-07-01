using System;
using CRMonopoly.domein;
namespace CRMonopoly.AI
{
    public interface IArtificialPlayerIntelligence
    {
        void HandelExtraZakenAfBinnenDeWorp(Speler speler);
        void HandelWorpAf(Speler speler);
    }
}
