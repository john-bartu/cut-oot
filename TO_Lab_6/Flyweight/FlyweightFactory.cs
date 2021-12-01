using System;
using System.Collections.Generic;

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
                return _flyweights[i];
            }
            else
            {
                Flyweight<T> newFlyweight = new(state);
                _flyweights.Add(newFlyweight);
                return newFlyweight;
            }
        }
    }
}