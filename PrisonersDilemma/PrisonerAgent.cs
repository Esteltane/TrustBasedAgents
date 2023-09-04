using System;
using System.Collections.Generic;
using System.Text;
using ActressMas;

namespace PrisonersDilemma
{
    public abstract class PrisonerAgent: Agent
    {
        protected double _points = 0.0;
        protected int _lastOutcome = Settings.Start;
        protected bool _cost = false;
        protected Agent_Store temp = new Agent_Store();
        protected double NCost = 0.0;

        public override void Act(Message message)
        {
            try
            {
                Console.WriteLine($"\t{message.Format()}");
                message.Parse(out string action, out string parameters);

                switch (action)
                {
                    case "outcome":
                        HandleOutcome(Convert.ToInt32(parameters));
                        break;

                    case "end":
                        HandleEnd();
                        break;



                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override void ActDefault()
        {
            HandleTurn();
        }

        protected abstract string ChooseAction(int lastOutcome, out bool cost);

        private void HandleOutcome(int outcome)
        {
            _lastOutcome = outcome;
            _points += _lastOutcome;
        }

        private void HandleTurn()
        {
            
            string action = ChooseAction(_lastOutcome, out _cost);
            
            temp.name = this.Name;
            temp.response = action;
            temp.cost = _cost;
            Send("police", temp);
            Console.WriteLine($"{temp.name} has decided to play {action} this turn");
            if(_cost == true)
            {
                NCost += Settings.payment;
            }

        }

        private void HandleEnd()
        {
            //_points -= NCost;
            Console.WriteLine($"[{Name}]: I have {_points} points : With cost of {NCost}");
            Send("Tournament", _points);

            Stop();
        }
    }
}
