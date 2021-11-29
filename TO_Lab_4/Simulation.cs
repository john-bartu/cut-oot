using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
        private bool IsRunning { get; set; } = false;
        private readonly List<List<Person>> _mementos;
        private Stopwatch _stopwatch = Stopwatch.StartNew();
        private int lastCheck = 0;
        private long lastTimeCheck = 0;

        private int _step;
        public Population Originator { get; }

        public Simulation(Population population, int preRender = 0)
        {
            _mementos = new();

            Originator = population;

            Simulate();
            _step = 0;
            SimulateN(preRender);
        }


        public void Stats()
        {
            long currentTime = _stopwatch.ElapsedMilliseconds;

            long timeSpan = currentTime - lastTimeCheck;

            if (timeSpan >= 1000)
            {
                int count = MaxId() - lastCheck;

                Console.WriteLine($"Tick/s {count / (timeSpan / 1000f)}");


                lastCheck = MaxId();
                lastTimeCheck = currentTime;
            }
        }

        public void Simulate()
        {
            _mementos.Add(Originator.People.Clone().ToList());
            // originator has next step
            Originator.Step();
            Stats();
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
            return _mementos[_step];
        }

        public int CurrentId()
        {
            return _step;
        }

        public int MaxId()
        {
            return _mementos.Count - 1;
        }


        public void Previous()
        {
            if (IsRunning)
                _step = _step - 1 < 0 ? 0 : _step - 1;
        }

        public void Next()
        {
            if (IsRunning)
                _step = _step + 1 == MaxId() ? _step : _step + 1;
        }

        public void PlayPause()
        {
            IsRunning = !IsRunning;
        }

        public float GetBound()
        {
            return Originator.Bound;
        }
    }
}