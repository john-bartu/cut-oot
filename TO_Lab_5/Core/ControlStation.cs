using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace TO_Lab_5.Core
{
    public class ControlStation
    {
        private List<FireStation> observators;

        private List<Event> _events;


        public ControlStation()
        {
            observators = new List<FireStation>();
        }

        public void RegisterFireStations(List<FireStation> fireStations)
        {
            foreach (var fireStation in fireStations)
            {
                Console.WriteLine($"ControlStation Registering: {fireStation}");
            }

            observators.AddRange(fireStations);
        }

        private void Notify(FireStation fireStation)
        {
        }
    }
}