using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using OpenTK;
using TO_Lab_4.Graphic;
using TO_Lab_4.Unit;

namespace TO_Lab_4
{
    public class Population
    {
        private readonly Dictionary<Tuple<Person, Person>, long> _neighborsDictionary;
        public List<Person> People { get; } = new();
        public float Bound { get; }
        public float Multiplier { get; }
        public int PopularizeProb { get; }

        private int ImmuneProb { get; }
        private int IllnessProb { get; }

        private long PopulationTime { get; set; }

        public Population(int count, int immuneProb, int illnessProb, int ticksPerSecond, int popularizeProb,
            float bound)
        {
            Multiplier = 1f / ticksPerSecond;
            PopularizeProb = popularizeProb;
            Bound = bound;

            IllnessProb = illnessProb;
            ImmuneProb = immuneProb;

            _neighborsDictionary = new();

            PopulationTime = 0;

            for (int personId = 0; personId < count; personId++)
            {
                Person newPerson = Born();
                newPerson.Position = RandomStartPosition();
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

            Person person = new(isImmune ? new ImmuneState() : new HealthySoVulnerableState());
            person.State.SetContext(person);

            if (isIll)
                person.MakeIll();

            return person;
        }


        public void Step()
        {
            PopulationTime += (long)(1000 * Multiplier);


            for (int i = People.Count - 1; i >= 0; i--)
            {
                Person person = People[i];
                person.Tick(Multiplier);

                foreach (var person2 in People)
                {
                    if (person != person2)
                    {
                        Tuple<Person, Person> neighbors = new(person, person2);

                        if (person.GetDistanceTo2(person2) < 4)
                        {
                            // if (person.CanInfectedBy(person2))
                            // {
                            //     if (!_neighborsDictionary.ContainsKey(neighbors))
                            //     {
                            //         // Register newly neighbors
                            //         _neighborsDictionary[neighbors] = PopulationTime;
                            //     }
                            //     // Neighbors registered, so time is ticking
                            // }
                            // else
                            // {
                            //     // Neighbor has been healed
                            //     _neighborsDictionary.Remove(neighbors);
                            // }
                        }
                        else
                        {
                            // To far so remove
                            _neighborsDictionary.Remove(neighbors);
                        }
                    }
                }


                OutOfBoundCheck(person);
            }

            if (PopulationTime % 5000 == 0)
            {
                Console.WriteLine($"Population: {People.Count} \t Neighbors:{_neighborsDictionary.Count}");
                // CleanNeighbours();
            }

            ShouldInfectCheck();

            // Popularize();
        }
        

        private void ShouldInfectCheck()
        {
            List<Tuple<Person, Person>> infectedList = new();

            foreach (var neighbors in _neighborsDictionary)
            {
                // Console.WriteLine($"Infect in: {2000 - (PopulationTime - neighbors.Value)}");

                if (PopulationTime - neighbors.Value >= 3000)
                {
                    if (neighbors.Key.Item1.TouchedBy(neighbors.Key.Item2))
                        infectedList.Add(neighbors.Key);
                }
            }

            foreach (var neighbors in infectedList)
                _neighborsDictionary.Remove(neighbors);
        }


        private void Popularize()
        {
            if (Random.Shared.Next(100) < PopularizeProb)
                AddNewPerson();
        }

        private void AddNewPerson()
        {
            Person person = Born();
            person.Position = RandomPosition();
            People.Add(person);
        }


        private void OutOfBoundCheck(Person person)
        {
            if (OutOfBound(person.Position))
            {
                if (Random.Shared.Next(2) == 0)
                    person.MoveTowards(new(Bound / 2, Bound / 2));
                else
                {
                    Suicide(person);
                }
            }
        }
        

        private void Suicide(Person person)
        {
            People.Remove(person);
            AddNewPerson();
        }

        private bool OutOfBound(Vector2 position)
        {
            return position.X < 0 || position.X > Bound || position.Y < 0 || position.Y > Bound;
        }
    }
}