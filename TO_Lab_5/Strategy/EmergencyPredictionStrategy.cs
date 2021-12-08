using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TO_Lab_5.Core;
using TO_Lab_5.Iterator;
using TO_Lab_5.Observer;

namespace TO_Lab_5.Strategy
{
    public abstract class IEventStrategy
    {
        public abstract List<FireTruck> Execute(IIterator<FireTruck> fireTrucks);

        protected List<FireTruck> GetClosest(IIterator<FireTruck> fireTrucks, int count)
        {
            List<FireTruck> trucks = new();

            for (int i = 0; i < count; i++)
            {
                FireTruck truck = fireTrucks.getNext();
                truck.HandleBusy();
                trucks.Add(truck);
            }

            return trucks;
        }
    }

    public class StrategyMz : IEventStrategy
    {
        public override List<FireTruck> Execute(IIterator<FireTruck> fireTrucks)
        {
            return GetClosest(fireTrucks, 3);
        }
    }

    public class StrategyPz : IEventStrategy
    {
        public override List<FireTruck> Execute(IIterator<FireTruck> fireTrucks)
        {
            return GetClosest(fireTrucks, 2);
        }
    }
}