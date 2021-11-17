using System;
using System.Collections;
using System.Collections.Generic;
using OpenTK;
using TO_Lab_4.Graphic;
using TO_Lab_4.Unit;

namespace TO_Lab_4
{
    public class Population
    {
        public List<Person> People { get; } = new();
        public static float Bound { get; set; } = 50;
        public static float Multiplier { get; } = 1f / 25f;
        public static float PopulizeRate { get; } = 0.4f;

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
            int number = Random.Shared.Next(4);
            // Console.WriteLine(number);
            switch (number)
            {
                case 0:
                    return new Vector2(0, Random.Shared.NextSingle() * Bound);
                case 1:
                    return new Vector2(Bound, Random.Shared.NextSingle() * Bound);
                case 2:
                    return new Vector2(Random.Shared.NextSingle() * Bound, Bound);
                case 3:
                    return new Vector2(Random.Shared.NextSingle() * Bound, 0);
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
            bool isImmune = Random.Shared.Next(100) < ImmuneProb;
            bool isIll = Random.Shared.Next(100) < IllnessProb;

            Person person = new(isImmune ? new ImmuneState() : new VulnerableState());
            person.State.SetContext(person);

            if (isIll)
                person.MakeIll();

            return person;
        }

        public void Step()
        {
            // Bound = (float)(Bound + Math.Sin(Camera.Stopwatch.ElapsedMilliseconds / 75.0) * 25);
            //

            Popularize();

            for (int i = People.Count - 1; i >= 0; i--)
            {
                Person person = People[i];
                person.Tick(Multiplier);

                foreach (var person2 in People)
                {
                    if (person != person2 && person.GetDistanceTo(person2) < 2)
                    {
                        person.TouchedBy(person2);
                    }
                }

                OutOfBoundCheck(person);
            }
        }

        private void Popularize()
        {
            if (Random.Shared.NextSingle() < PopulizeRate)
            {
                Person person = Born();
                person.position = RandomPosition();
                People.Add(person);
            }
        }


        private void OutOfBoundCheck(Person person)
        {
            if (OutOfBound(person.position))
            {
                if (Random.Shared.Next(2) == 0)
                    person.MoveTowards(new(Population.Bound / 2, Population.Bound / 2));
                else
                    Suicide(person);
            }
        }

        private void Suicide(Person person)
        {
            People.Remove(person);
        }

        private bool OutOfBound(Vector2 position)
        {
            return position.X < 0 || position.X > Bound || position.Y < 0 || position.Y > Bound;
        }
    }
}