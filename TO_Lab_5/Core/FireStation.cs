using System.Collections.Generic;
using TO_Lab_5.Observer;
using TO_Lab_5.Vector;

namespace TO_Lab_5.Core
{
    public class FireStation
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
                new (name +"-1"), new (name +"-2"), new (name +"-3"), new (name +"-4")
            };
        }

        public override string ToString()
        {
            return $"FS({Name} - {Trucks.Count} Trucks)";
        }
    }
}