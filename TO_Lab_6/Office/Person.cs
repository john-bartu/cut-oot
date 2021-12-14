using System;
using System.Text.Json.Serialization;
using TO_Lab_5.Vector;

namespace TO_Lab_6
{
    public class Person
    {
        public NamePart Name { get; set; }
        public Vector2 Coordinate { get; set; }


        [JsonConstructor]
        public Person(NamePart name, Vector2 coordinate)
        {
            Coordinate = coordinate;
            Name = name;
        }

        public NamePart GetName()
        {
            return Name;
        }

        public Person(NamePart name)
        {
            Coordinate = RandomLocation();
            Name = name;
        }

        public static Vector2 RandomLocation()
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

        public string ToStringId()
        {
            return $"P: [ {Name.ToStringId()} ]";
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}