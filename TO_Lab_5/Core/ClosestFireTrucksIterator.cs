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
        private List<FireTruck> _fireTrucks;
        private readonly Vector2 _targetLocation;
        private readonly ISubject _controlStation;

        public ClosestFireTrucksIterator(ISubject fireStation, Vector2 position)
        {
            _fireTrucks = new List<FireTruck>();
            _controlStation = fireStation;
            _targetLocation = position;
            RefreshIterator();
        }

        public bool hasNext()
        {
            throw new NotImplementedException();
        }

        void RefreshIterator()
        {
            _fireTrucks =
                _controlStation.Notify()
                    .OrderBy(station => station.position
                        .DistanceTo(_targetLocation))
                    .ToList();
        }

        public FireTruck getNext()
        {
            while (true)
            {
                foreach (var truck in _fireTrucks)
                {
                    return truck;
                }

                RefreshIterator();
            }
        }
    }
}