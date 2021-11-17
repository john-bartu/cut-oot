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


        public float IllTime { get; set; }
        public float TimeSinceInfected { get; set; }
        public State State { get; set; }

        public void Context(State state)
        {
            TransitionTo(state);
        }

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


        public void TouchedBy(Person person)
        {
            switch (person.State)
            {
                case SymptomaticState:
                    MakeIll();
                    break;
                case
                    AsymptomaticState:
                    if (Random.Shared.Next(2) == 0)
                        MakeIll();
                    break;
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
                position = position,
                movement = movement
            };

            return copyPerson;
        }
    }
}