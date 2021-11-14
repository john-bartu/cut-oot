using System;
using System.Collections;
using System.Collections.Generic;
using OpenTK;
using TO_Lab_4.Unit;

namespace TO_Lab_4
{
    public class Population
    {
        public List<Person> People { get; } = new();
        public static float Bound { get; } = 100;

        private int ImmuneProb { get; }
        private int IllnessProb { get; }

        public Population(int count, int immuneProb, int illnessProb)
        {
            IllnessProb = illnessProb;
            ImmuneProb = immuneProb;

            for (int personId = 0; personId < count; personId++)
            {
                Person newPerson = Born();
                newPerson.position = RandomStartPosition();
                People.Add(newPerson);
            }
        }

        private Vector2 RandomPosition()
        {
            int number = Random.Shared.Next(5);
            // Console.WriteLine(number);
            switch (number)
            {
                case 0:
                    return new Vector2(0, Random.Shared.NextSingle() * Population.Bound);
                case 1:
                    return new Vector2(Population.Bound, Random.Shared.NextSingle() * Population.Bound);
                case 2:
                    return new Vector2(Random.Shared.NextSingle() * Population.Bound, Population.Bound);
                case 4:
                    return new Vector2(Random.Shared.NextSingle() * Population.Bound, 0);
                default:
                    return new Vector2();
            }
        }

        private Vector2 RandomStartPosition()
        {
            int number = Random.Shared.Next(5);
            return new Vector2(
                Random.Shared.NextSingle() * Bound,
                Random.Shared.NextSingle() * Bound
            );
        }

        Person Born()
        {
            bool isIll = Random.Shared.Next(100) < IllnessProb;

            IResistance resistance = Random.Shared.Next(100) < ImmuneProb ? new Immunize() : new UnImminize();
            IHealth health = isIll ? new Healthy() : new Ill();

            Person person = new(resistance, health);
            if (isIll)
                person.MakeIll();

            return person;
        }

        public void Step()
        {
            foreach (var person in People)
            {
                person.Move(0.04f);
                person.IllTime -= 1;

                foreach (var person2 in People)
                {
                    if (person != person2)
                    {
                        if (person.TouchedBy(person2))
                        {
                            person.MakeIll();
                        }
                    }
                }
            }
        }
    }
}