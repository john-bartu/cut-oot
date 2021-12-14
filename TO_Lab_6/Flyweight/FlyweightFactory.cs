using System;
using System.Collections.Generic;
using TO_Lab_6.Proxy;

namespace TO_Lab_6
{
    public class FlyweightFactory<T>
    {
        private readonly List<Flyweight<T>> _flyweights = new();

        public Flyweight<T> getFlyweight(T state)
        {
            int i = _flyweights.FindIndex(x => Equals(x.GetState(), state));
            if (i >= 0)
            {
                // Console.WriteLine($"Flyweight [{state,16}] load from memory");
                return _flyweights[i];
            }
            else
            {
                // Console.WriteLine($"Flyweight [{state,16}] create in memory");

                Flyweight<T> newFlyweight = new(state);
                _flyweights.Add(newFlyweight);
                return newFlyweight;
            }
        }

        // public Flyweight<T> getFlyweight(T state)
        // {
        //     Flyweight<T> newFlyweight = new(state);
        //     _flyweights.Add(newFlyweight);
        //     return newFlyweight;
        // }
    }
}