using System;
namespace Monopoly.AI
{
    public interface IAIDecider
    {
        void AddDecision(string gebeurtenisnaam, IDecision decision);
        string Decide(Monopoly.domein.Monopolyspel spel);
    }
}
