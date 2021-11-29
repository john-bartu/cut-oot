using System;

namespace TO_Lab_4.Unit
{
    public class Person : BodyPerson, ICloneable
    {
        public Person(State state)
        {
            State = state;
            IllTime = Random.Shared.NextSingle() * 10 + 20;
            TimeSinceInfected = 0;
        }


        private float IllTime { get; init; }
        private float TimeSinceInfected { get; set; }
        public State State { get; set; }


        public void TransitionTo(State state)
        {
            // Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
            State = state;
            State.SetContext(this);
        }


        public void RequestImmune()
        {
            State.HandleImmune();
        }

        public void RequestVulnerable()
        {
            State.HandleVulnerable();
        }


        public void RequestSymptomatic()
        {
            State.HandleSymptomatic();
        }

        public void RequestAsymptomatic()
        {
            State.HandleAsymptomatic();
        }


        public bool TouchedBy(Person person)
        {
            switch (person.State)
            {
                case SymptomaticState:
                    MakeIll();
                    return true;

                case AsymptomaticState:

                    if (Random.Shared.Next(2) == 0)
                    {
                        MakeIll();
                        return true;
                    }

                    return false;
                default:
                    return false;
            }
        }

        public bool CanInfectedBy(Person person)
        {
            if (State is SymptomaticState || State is AsymptomaticState)
                return false;
            else
            {
                switch (person.State)
                {
                    case SymptomaticState:
                        return true;
                    case AsymptomaticState:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public void Tick(float multiplier)
        {

            if (State is SymptomaticState || State is AsymptomaticState)
                TimeSinceInfected += multiplier;

            if (TimeSinceInfected >= IllTime)
                RequestImmune();

            Move(multiplier);
        }

        public void MakeIll()
        {
            if (Random.Shared.Next(2) == 0)
                RequestSymptomatic();
            else
                RequestAsymptomatic();
        }

        public object Clone()
        {
            Person copyPerson = new(State)
            {
                IllTime = IllTime,
                Position = Position,
                Movement = Movement
            };

            return copyPerson;
        }
    }
}