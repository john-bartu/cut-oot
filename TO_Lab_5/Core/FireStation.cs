using System.Collections.Generic;
using TO_Lab_5.Observer;
using TO_Lab_5.Vector;

namespace TO_Lab_5.Core
{
    public class FireStation
    {
        private string Name { get; }
        private Vector2 Position { get; }
        private List<FireTruck> Trucks { get; }

        public FireStation(string name, Vector2 position)
        {
            Name = name;
            Position = position;
            
            Trucks = new List<FireTruck>()
            {
                new (), new (), new (), new ()
            };
        }

        public override string ToString()
        {
            return $"FS({Name} - {Trucks.Count} Trucks)";
        }
    }
}