using System;
using System.Collections;
using System.Collections.Generic;
using TO_Lab_6.Proxy;

namespace TO_Lab_6
{
    public class FlyweightFactory<T>
    {
        public FlyweightFactory()
        {
            Flyweights = new();
        }

        public List<Flyweight<T>> Flyweights { get; set; }

        public Flyweight<T> GetFlyweight(T state)
        {
            int i = Flyweights.FindIndex(x => Equals(x.GetState(), state));
            if (i >= 0)
            {
                Console.WriteLine($"Flyweight [{state,16}] load from memory");
                return Flyweights[i];
            }
            else
            {
                Console.WriteLine($"Flyweight [{state,16}] create in memory");

                Flyweight<T> newFlyweight = new(state);
                Flyweights.Add(newFlyweight);
                return newFlyweight;
            }
        }

        public IEnumerable GetFlyweights()
        {
            return Flyweights;
        }
    }
}