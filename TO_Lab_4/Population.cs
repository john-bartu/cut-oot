using System;
using System.Collections;
using System.Collections.Generic;
using TO_Lab_4.Unit;

namespace TO_Lab_4
{
    public class Population
    {
        public List<Person> People { get; } = new();
        public static float Bound { get; } = 500;


        public Population(int count, int immuneProb, int ilnessProb)
        {
            for (int personId = 0; personId < count; personId++)
            {
                bool isIll = new Random().Next(100) < ilnessProb;

                IResistance resistance = new Random().Next(100) < immuneProb ? new Immunize() : new UnImminize();
                IHelath helath = isIll ? new Healthy() : new Ill();
                ISymtomps symtomps = new Random().Next(2) == 0 ? new Asymptomatic() : new Symptomatic();

                float illTime = isIll ? new Random().NextSingle() * 10 + 20 : 0;

                Person person = new(resistance, helath, symtomps, illTime);
                People.Add(person);
            }
        }

        public void Step()
        {
            foreach (var person in People)
            {
                person.Move(2);
            }
        }
    }
}