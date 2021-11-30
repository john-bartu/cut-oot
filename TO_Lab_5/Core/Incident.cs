using System;
using TO_Lab_5.Vector;

namespace TO_Lab_5.Core
{
    public class Incident
    {
        public Incident()
        {
            Type = Random.Shared.NextSingle() <= 0.70 ? EventType.MZ : EventType.PZ;
            Name = RandomName(Type);
            Real = Random.Shared.NextSingle() <= 0.90;
            Location = RandomLocation();
        }

        public override string ToString()
        {
            if (Real)
                return $"Incident( {Name})";
            else
                return $"Incident(!{Name})";
        }


        public static string FirstCharToUpper(string input) =>
            input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
            };

        private string[] objectName = new[]
        {
            "cat", "car", "dog", "bird", "crow", "laundry", "woman", "men", "crowd",
            "child", "turtle", "hamster", "dumpster", "apartment", "tree"
        };

        private string RandomName(EventType type)
        {

            var something = objectName[Random.Shared.Next(objectName.Length)];

            if (type == EventType.PZ)
                return FirstCharToUpper($"{something} on fire");

            else
            {
                string[] names = new[]
                {
                    $"{something} on tree",
                    $"car accident with {something}",
                    $"bus accident with {something}",
                    $"truck accident with {something}",
                    "fallen tree",
                    $"{something} drowning",
                    "house flooding"
                };
                return FirstCharToUpper(names[Random.Shared.Next(names.Length)]);
            }
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

        public String Name { get; }
        public EventType Type { get; }
        public bool Real { get; }
        public Vector2 Location { get; }

        public enum EventType
        {
            PZ,
            MZ
        }
    }
}