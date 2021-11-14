using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TO_Lab_4.Unit;

namespace TO_Lab_4
{
    static class Extensions
    {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }

    public class Simulation
    {
        private List<List<Person>> mementos;
        private int _step;
        private Population Originator { get; }


        public Simulation()
        {
            mementos = new();
            Originator = new Population(100, 10, 20);
            Simulate();
            _step = 0;
            
            SimulateN(100);

        }

        public void Simulate()
        {
            mementos.Add(Originator.People.Clone().ToList());
            // originator has next step
            Originator.Step();
        }

        private void SimulateN(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Simulate();
            }
        }

        public List<Person> Current()
        {
            return mementos[_step];
        }

        public int CurrentId()
        {
            return _step;
        }

        public int MaxId()
        {
            return mementos.Count - 1;
        }


        public void Previous()
        {
            _step = _step - 1 < 0 ? 0 : _step - 1;
        }

        public void Next()
        {
            _step++;
            if (mementos.Count < _step + 1)
            {
                Simulate();
            }
        }
    }
}