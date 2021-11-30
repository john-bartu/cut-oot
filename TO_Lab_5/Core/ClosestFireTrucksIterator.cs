using System;
using System.Collections.Generic;
using System.Linq;
using TO_Lab_5.Iterator;
using TO_Lab_5.Observer;
using TO_Lab_5.Vector;

namespace TO_Lab_5.Core
{
    class ClosestFireTrucksIterator : IIterator<FireTruck>
    {
        private List<FireStation> _fireStations;

        public ClosestFireTrucksIterator(List<FireStation> fireStations, Vector2 position)
        {
            _fireStations = fireStations.OrderBy(station => station.Position.DistanceTo(position)).ToList();
        }

        public bool hasNext()
        {
            throw new NotImplementedException();
        }

        public FireTruck getNext()
        {

            while (true)
            {
                foreach (var station in _fireStations)
                {
                    foreach (var truck in station.Trucks)
                    {
                        if (truck.state is IdleState)
                        {
                            return truck;
                        }
                    }
                }
            }
        }
    }
}