using System;
using System.Collections.Generic;
using System.Text;
using ActressMas;

namespace PrisonersDilemma
{
    class Tournament : Agent
    {
        public struct Social{
            public Social(string name, double score)
            {
                N = name;
                S = score;
                
            }
            public string N { get; set; }
            public double S { get; set; }
            

            

        }
        private List<PrisonerAgent> socialLearn = new List<PrisonerAgent>();
        private Dictionary<string, Social> sl = new Dictionary<string, Social>();
        private Random rnd = new Random();
        int _counter = 0;
        int pSelector = 0;
        int end = 0;
        private List<PrisonerAgent> players = new List<PrisonerAgent>();
        double Number = 0.0;
        double currentFitness = 0.0;
        double sum = 0.0;
        int _generation = 0;
        private Social value;

        public override void Setup()
        {
            var prisonerAgent1 = new TitForTatPrisonerAgent();
            var prisonerAgent2 = new GRIM_Prisoner();
            var prisonerAgent3 = new ALLCPrisoner();
            var prisonerAgent4 = new ALLDPrisoner();
            var prisonerAgent5 = new TBS_Prisoner();
            var prisonerAgent6 = new TBS_D_Prisoner();

            socialLearn.Add(prisonerAgent1);
            socialLearn.Add(prisonerAgent2);
            socialLearn.Add(prisonerAgent3);
            socialLearn.Add(prisonerAgent4);
            socialLearn.Add(prisonerAgent5);
            socialLearn.Add(prisonerAgent6);


            foreach (var p1 in socialLearn)
            {
                if (!(players.Contains(p1)))
                {
                    players.Add(p1);
                }
                if (!(Enviroment.env.AllAgents().Contains($"p1-{p1.GetType().Name}")))
                {

                    Enviroment.env.Add(players[0], $"p1-{players[0].GetType().Name}");
                }
                foreach (var p2 in socialLearn)
                {

                    players.Add(p2);
                    if (players.Count == 2)
                    {
                        if (!(Enviroment.env.AllAgents().Contains($"p2-{p2.GetType().Name}")))
                        {
                            Enviroment.env.Add(players[1], $"p2-{players[1].GetType().Name}");
                        }
                        //

                        players.Remove(p2);
                    }

                }

                players.Clear();

            }


        }

        public void Iterate()
        {
            while (_generation < Settings.EndGen)
            {
                
                foreach (var p1 in socialLearn)
                {
                    if (!(players.Contains(p1)))
                    {
                        players.Add(p1);
                    }
                    if (!(Enviroment.env.AllAgents().Contains($"p1-{p1.GetType().Name}")))
                    {
                        
                        Enviroment.env.Add(players[0], $"p1-{players[0].GetType().Name}");
                    }
                    foreach (var p2 in socialLearn)
                    {

                        players.Add(p2);
                        if (players.Count == 2)
                        {
                            if (!(Enviroment.env.AllAgents().Contains($"p2-{p2.GetType().Name}")))
                            {
                                Enviroment.env.Add(players[1], $"p2-{players[1].GetType().Name}");
                            }
                            Enviroment.env.Start();

                            players.Remove(p2);
                        }

                    }

                    players.Clear();

                }
            }

            tourEnd();
        }
        public override void Act(Message message)
        {
            Console.WriteLine($"\t{message.Format()}");

                string agent = "";
                string[] split = message.Sender.Split("-");
                string name = split[1];
                if (!(sl.ContainsKey(name)))
                {
                    sl.Add(name, new Social(message.Sender, Convert.ToDouble(message.ContentObj)));
                }
                else
                {
                    bool hasValue = sl.TryGetValue(name, out value);
                    if (hasValue)
                    {
                        value.S += Convert.ToDouble(message.ContentObj);
                        //count
                    }


                }

            if (sl.Count == socialLearn.Count)
            {
                foreach (var fit in sl)
                {
                    sum += fit.Value.S;
                }
                Number = rnd.NextDouble() * sum;
                foreach (var s in sl)
                {
                    currentFitness += s.Value.S;
                    if(Number < currentFitness)
                    {
                        agent = s.Key;
                    }
                    currentFitness = 0.0;
                    
                }
                if (agent == "TitForTatPrisonerAgent")
                {
                    _counter = rnd.Next(0, socialLearn.Count);
                    socialLearn.RemoveAt(_counter);
                    var prisoner = new TitForTatPrisonerAgent();
                    socialLearn.Add(prisoner);

                }
                else if (agent == "GRIM_Prisoner")
                {
                    _counter = rnd.Next(0, socialLearn.Count);
                    socialLearn.RemoveAt(_counter);
                    var prisoner = new GRIM_Prisoner();
                    socialLearn.Add(prisoner);

                }
                else if (agent == "ALLCPrisoner")
                {
                    _counter = rnd.Next(0, socialLearn.Count);
                    socialLearn.RemoveAt(_counter);
                    var prisoner = new ALLCPrisoner();
                    socialLearn.Add(prisoner);

                }
                else if (agent == "ALLDPrisoner")
                {
                    _counter = rnd.Next(0, socialLearn.Count);
                    socialLearn.RemoveAt(_counter);
                    var prisoner = new ALLDPrisoner();
                    socialLearn.Add(prisoner);

                }
                else if (agent == "TBS_Prisoner")
                {
                    _counter = rnd.Next(0, socialLearn.Count);
                    socialLearn.RemoveAt(_counter);
                    var prisoner = new TBS_Prisoner();
                    socialLearn.Add(prisoner);

                }
                else if (agent == "TBS_D_Prisoner")
                {
                    _counter = rnd.Next(0, socialLearn.Count);
                    socialLearn.RemoveAt(_counter);
                    var prisoner = new TBS_D_Prisoner();
                    socialLearn.Add(prisoner);

                }
                else {
                    Console.WriteLine("Unknown agent");
                }
                //sl.Clear();
            }


            _generation++;
            Iterate();
        }



        private void tourEnd()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"The tournament has ended at generation {_generation}");
            Console.WriteLine("The results are in:");
            
            foreach (var agt in socialLearn)
            {
                
                Console.WriteLine($"{agt.GetType().Name}");
            }
            Stop();
        }
    }
}
