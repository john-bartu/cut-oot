using System.Collections.Generic;
using TO_Lab_5.Observer;
using TO_Lab_5.Vector;

namespace TO_Lab_5.Core
{
    public class FireStation : IObserver
    {
        public string Name { get; }
        public Vector2 Position { get; }
        public List<FireTruck> Trucks { get; }

        public FireStation(string name, Vector2 position)
        {
            Name = name;
            Position = position;

            Trucks = new List<FireTruck>()
            {
                new(name + "-1",position), new(name + "-2",position), new(name + "-3",position), new(name + "-4",position), new(name + "-5",position)
            };
        }

        public override string ToString()
        {
            return $"FS({Name} - {Trucks.Count} Trucks)";
        }

        public List<FireTruck> SignalNewIncident()
        {
            var response = new List<FireTruck>();
            
            foreach (var truck in Trucks)
            {
                if (truck.state is IdleState)
                    response.Add(truck);
            }

            return response;
        }
    }
}