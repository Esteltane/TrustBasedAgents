using System;
using System.Collections.Generic;
using System.Text;
using ActressMas;

namespace PrisonersDilemma
{
    class PoliceAgent:Agent
    {
        private Dictionary<string, Agent_Store> _responses;


        public PoliceAgent()
        {
            _responses = new Dictionary<string, Agent_Store>();

        }

        public override void Act(Message message)
        {
            try
            {
                Console.WriteLine("\t[{1} -> {0}]: {2}", Name, message.Sender, message.Content);
                
                Agent_Store agent = message.ContentObj;
                
                HandlePlay(agent.name, agent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void HandlePlay(string sender, Agent_Store agent)
        {
            _responses.Add(sender, agent);

           

            if (_responses.Count == 2)
            {
                var e = _responses.Values.GetEnumerator();
                e.MoveNext(); var p1 = e.Current;
                e.MoveNext(); var p2 = e.Current;

                ComputeOutcome(p1.response, p2.response, out int outcome1, out int outcome2);
                
                Send(p1.name, $"outcome {outcome1}");
                Send(p2.name, $"outcome {outcome2}");

                Console.WriteLine(p2.cost);

                _responses.Clear();
            }
        }

        private void ComputeOutcome(string action1, string action2, out int outcome1, out int outcome2)
        {
            outcome1 = outcome2 = 0;


            if (action1 == "Cooperate" && action2 == "Cooperate")
            {
                outcome1 = outcome2 = 3;
            }
            else if (action1 == "Defect" && action2 == "Defect")
            {
                outcome1 = outcome2 = 1;
            }
            else if (action1 == "Cooperate" && action2 == "Defect")
            {
                outcome1 = 0; outcome2 = 5;
            }
            else if (action1 == "Defect" && action2 == "Cooperate")
            {
                outcome1 = 5; outcome2 = 0;
            }
        }
    }
}
