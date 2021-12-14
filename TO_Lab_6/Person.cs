using System;
using TO_Lab_5.Vector;

namespace TO_Lab_6
{
    public class Person
    {
        public string Name => name.GetState();
        public string Surname => surname.GetState();

        private Flyweight<string> name;
        private Flyweight<string> surname;
        private Vector2 coordinate;

        public Person(
            Flyweight<string> name,
            Flyweight<string> surname,
            Vector2 coordinate)
        {
            this.coordinate = coordinate;
            this.name = name;
            this.surname = surname;
        }
        
        public Person(
            Flyweight<string> name,
            Flyweight<string> surname)
        {
            coordinate = RandomLocation();
            this.name = name;
            this.surname = surname;
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
        
    }
}