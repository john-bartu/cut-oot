using System;

namespace TO_Lab_4.Unit
{
    public class Person : BodyPerson, ICloneable
    {
        public Person(IResistance resistance, IHealth health)
        {
            Resistance = resistance;
            Health = health;
            Symptoms = new Asymptomatic();
            IllTime = -1;
        }

        public IResistance Resistance { get; set; }
        public IHealth Health { get; set; }
        public ISymtomps Symptoms { get; set; }

        public float IllTime { get; set; }

        public bool TouchedBy(Person person)
        {
            if (GetDistanceTo(person) < 2 && IllTime < 0)
            {
                return Resistance.InteractWith(person);
            }
            else
                return false;
        }

        public void MakeIll()
        {
            Health = new Ill();
            IllTime = Random.Shared.NextSingle() * 10 + 20;
            Symptoms = Random.Shared.Next(2) == 0 ? new Asymptomatic() : new Symptomatic();
        }

        public void MakeImmune()
        {
            Resistance = new Immunize();
            Health = new Healthy();
        }

        public object Clone()
        {
            Person copyPerson = new(Resistance, Health)
            {
                Symptoms = Symptoms,
                IllTime = IllTime,
                position = position,
                movement = movement
            };

            return copyPerson;
        }
    }
}