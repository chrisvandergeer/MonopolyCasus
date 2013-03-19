using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSMonopoly.builders;
using MSMonopoly.domein;

namespace MSMonopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }

        private void Run()
        {
            MonopolySpelBuilder builder = new MonopolySpelBuilder();
            Monopoly monopoly = builder.Build();
            monopoly.Add(new Speler() { Naam = "Mees" });
            monopoly.Add(new Speler() { Naam = "Floor" });
            monopoly.Add(new Speler() { Naam = "Hanna" });
            monopoly.Add(new Speler() { Naam = "Chris" });
            Beurt huidigeBeurt = monopoly.Start();
            huidigeBeurt.Gooi();
            huidigeBeurt.Verplaats();
            huidigeBeurt.BepaalActie();
            printInfo(huidigeBeurt);
            Console.ReadLine();
        }

        private void printInfo(Beurt huidigebeurt)
        {
            Console.WriteLine(huidigebeurt.ReadLog());
        }
    }
}
