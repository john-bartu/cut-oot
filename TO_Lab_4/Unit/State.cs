using System;

namespace TO_Lab_4.Unit
{
    public abstract class State
    {
        protected Person person;

        public void SetContext(Person person)
        {
            this.person = person;
        }

        public abstract void HandleImmune();

        // Healthy
        public abstract void HandleVulnerable();

        //Ill
        public abstract void HandleSymptomatic();

        //Ill
        public abstract void HandleAsymptomatic();
    }

    class ImmuneState : State
    {
        public override void HandleImmune()
        {
        }

        public override void HandleVulnerable()
        {
        }

        public override void HandleSymptomatic()
        {
        }

        public override void HandleAsymptomatic()
        {
        }
    }

    class HealthySoVulnerableState : State
    {
        public override void HandleImmune()
        {
           // throw new Exception("I need to be sick to get immune");
        }

        public override void HandleVulnerable()
        {
           // throw new Exception("I am already vulnerable");
        }
        
        public override void HandleSymptomatic()
        {
            person.TransitionTo(new SymptomaticState());
        }

        public override void HandleAsymptomatic()
        {
            person.TransitionTo(new AsymptomaticState());
        }
    }

    class SymptomaticState : State
    {
        public override void HandleImmune()
        {
            person.TransitionTo(new ImmuneState());
        }

        public override void HandleVulnerable()
        {
            person.TransitionTo(new HealthySoVulnerableState());
        }

        public override void HandleSymptomatic()
        {
            //throw new Exception("I am already asymptomatic");
        }

        public override void HandleAsymptomatic()
        {
            //throw new Exception("I am asymptomatic");
        }
    }

    class AsymptomaticState : State
    {
        public override void HandleImmune()
        {
            person.TransitionTo(new ImmuneState());
        }

        public override void HandleVulnerable()
        {
            person.TransitionTo(new HealthySoVulnerableState());
        }

        public override void HandleSymptomatic()
        {
            //throw new Exception("I am asymptomatic");
        }

        public override void HandleAsymptomatic()
        {
            //throw new Exception("I am already asymptomatic");
        }
    }
}