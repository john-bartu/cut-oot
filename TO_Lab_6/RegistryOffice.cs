using System;
using System.Collections.Generic;
using TO_Lab_5.Vector;
using TO_Lab_6.Proxy;

namespace TO_Lab_6
{
    public class RegistryOffice
    {
        private readonly FlyweightFactory<string> _nameRegistry = new();
        private readonly FlyweightFactory<string> _surnameRegistry = new();
        private readonly List<Person> _persons = new();

        public void RegisterPerson(string name, string surname, Vector2 coord)
        {
            
            Console.WriteLine($"Registry Adding {name,16} | {surname,16}");
            NameChecker checker = new();

            Flyweight<string> flyweightName = _nameRegistry.getFlyweight(checker.Operation(name));
            Flyweight<string> flyweightSurname = _surnameRegistry.getFlyweight(checker.Operation(surname));

            Person person =new(flyweightName, flyweightSurname, coord);
            _persons.Add(person);
            Console.WriteLine($"Registry Added: {person.Name,16}[ {person.Name.GetHashCode():X8} ] |  {person.Surname,16}[ {person.Surname.GetHashCode():X8} ]\n");

        }

        public void ListWithMemory()
        {
            Console.WriteLine("Persons List");
            foreach (var person in _persons)
            {
                Console.WriteLine($"P: {person.Name,16}[ {person.Name.GetHashCode():X8} ] |  {person.Surname,16}[ {person.Surname.GetHashCode():X8} ]");
            }
            
        }
    }
}