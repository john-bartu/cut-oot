using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TO_Lab_5.Iterator;
using TO_Lab_5.Observer;

namespace TO_Lab_5.Core
{
    public class ControlStation
    {
        private readonly List<FireStation> _observators;

        private readonly List<Incident> _incidents;


        public ControlStation()
        {
            _observators = new List<FireStation>();
            _incidents = new List<Incident>();
        }


        public async void RegisterIncident(Incident incident)
        {
            Console.WriteLine($"ControlStation What's happen? - {incident}");

            var squad = new FireSquad(incident);
            
            IIterator<FireTruck> iterator = new ClosestFireTrucksIterator(_observators, incident.Location);
            

            squad.Step1PrepareTeam(iterator);

            squad.Go();
        }


        public void RegisterFireStations(List<FireStation> fireStations)
        {
            foreach (var fireStation in fireStations)
            {
                Console.WriteLine($"ControlStation Registering: {fireStation}");
            }

            _observators.AddRange(fireStations);
        }
    }
}