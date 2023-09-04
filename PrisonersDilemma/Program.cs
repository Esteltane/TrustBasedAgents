using System;
using ActressMas;

namespace PrisonersDilemma
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var tour = new Tournament();

            Enviroment.env.Add(tour, "Tournament");


            var policeAgent = new PoliceAgent();
            Enviroment.env.Add(policeAgent, "police");

            Enviroment.env.Start();
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
