using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TO_Lab_5.Iterator;
using TO_Lab_5.Observer;

namespace TO_Lab_5.Core
{
    public class ControlStation : ISubject
    {
        private readonly List<IObserver> _observators;

        private readonly List<Incident> _incidents;


        public ControlStation()
        {
            _observators = new List<IObserver>();
            _incidents = new List<Incident>();
        }


        public void RegisterIncident(Incident incident)
        {
            Console.WriteLine($"ControlStation What's happen? - {incident}");

            var squad = new FireSquad(incident);

            IIterator<FireTruck> iterator = new ClosestFireTrucksIterator(this, incident.Location);

            squad.Step1PrepareTeam(iterator);

            squad.Go();
        }

        public void RegisterStations(List<FireStation> fireStations)
        {
            foreach (var fireStation in fireStations)
            {
                Console.WriteLine($"ControlStation Registering: {fireStation}");
                Attach(fireStation);
            }
        }

        public void Attach(IObserver observer)
        {
            _observators.Add(observer);
        }

        public List<FireTruck> Notify()
        {
            List<FireTruck> trucks = new();

            foreach (var observer in _observators)
            {
                trucks.AddRange(observer.SignalNewIncident());
            }

            return trucks;
        }
    }
}