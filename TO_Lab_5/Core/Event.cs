using System;
using TO_Lab_5.Vector;

namespace TO_Lab_5.Core
{
    class Event
    {
        public Event()
        {
            Name = RandomName();
            Type = Random.Shared.NextSingle() <= 70 ? EventType.MZ : EventType.PZ;
            False = Random.Shared.NextSingle() <= 5;
            Location = RandomLocation();
        }

        private string RandomName()
        {
            string[] names = new[]
            {
                "Dumpster fire",
                "Dog on tree",
                "Cat on tree",
                "Apartment fire",
                "Car fire",
                "Accident",
                "Fallen tree",
                "Flooding"
            };


            return names[Random.Shared.Next(names.Length)];
        }

        private static Vector2 RandomLocation()
        {
            float L = 49.9585f;
            float R = 50.1545f;
            float U = 20.0247f;
            float D = 19.6882f;

            return new Vector2(
                Random.Shared.NextSingle() * (R - L) + L,
                Random.Shared.NextSingle() * (U - D) + D
            );
        }

        private String Name { get; }
        private EventType Type { get; }
        private bool False { get; }

        private Vector2 Location { get; }


        enum EventType
        {
            PZ,
            MZ
        }
    }
}