using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TO_Lab_5.Iterator;
using TO_Lab_5.Observer;
using TO_Lab_5.Strategy;

namespace TO_Lab_5.Core
{
    public class FireSquad
    {
        private string name;
        private List<FireTruck> _trucks;
        private IEventStrategy _strategy;
        private Incident task;

        string TrucksString()
        {
            return String.Join(", ", _trucks);
        }

        public FireSquad(Incident task)
        {
            name = Guid.NewGuid().ToString().AsSpan(0, 8).ToString();

            _trucks = new List<FireTruck>();
            this.task = task;

            if (task.Type == Incident.EventType.MZ)
                _strategy = new StrategyMz();
            else if (task.Type == Incident.EventType.PZ)
                _strategy = new StrategyPz();
            else
                throw new Exception("Unrecognized incident type");
        }

        public void Step1PrepareTeam(IIterator<FireTruck> fireTrucks)
        {
            Console.WriteLine($"1 {this} Preparing Team - {task}");

            _trucks = _strategy.Execute(fireTrucks);

            Console.WriteLine($"{TrucksString()} -> {this}");
        }

        private async Task Step2GoToLocation()
        {
            Console.WriteLine($"2 {this} Travelling To - {task}");

            foreach (var fireTruck in _trucks)
            {
                fireTruck.HandleTravelTo();
            }

            Console.WriteLine($"{TrucksString()} -> {task}");
            await Task.Delay(Random.Shared.Next(3000));
        }

        private async Task Step3Investigate()
        {
            Console.WriteLine($"3 {this} Investigating {task}");

            if (task.Real)
            {
                Console.WriteLine($"{this} Task is Real {task}");
                Console.WriteLine($"{this} doing {task}");

                foreach (var fireTruck in _trucks)
                {
                    fireTruck.HandleWork();
                }

                Console.WriteLine($"{TrucksString()} doing {task}");

                await Task.Delay(Random.Shared.Next(20000) +5000);
            }
            else
            {
                Console.WriteLine($"{this} Task is fake {task}");
            }
        }

        public override string ToString()
        {
            return $"Squad({name})";
        }

        public async void Go()
        {
            await Step2GoToLocation();
            await Step3Investigate();
            await Step4Return();

            Console.WriteLine($"{this} Done - {task}");
        }

        private async Task Step4Return()
        {
            Console.WriteLine($"4 {this} sent crew to bases - {task}");

            
            foreach (var fireTruck in _trucks)
            {
                fireTruck.HandleTravelReturn();
            }
            
            await Task.Delay(Random.Shared.Next(3000));

            foreach (var fireTruck in _trucks)
            {
                fireTruck.HandleFree();
            }
            
            Console.WriteLine($"{TrucksString()} -> Base");
        }
    }

    
}