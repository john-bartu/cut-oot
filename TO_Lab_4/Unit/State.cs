using System;

namespace TO_Lab_4.Unit
{
    class Context
    {
        private State _state = null;

        public Context(State state)
        {
            TransitionTo(state);
        }
        
        public void TransitionTo(State state)
        {
            Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
            _state = state;
            _state.SetContext(this);
        }
        

        public void HandleImmune(){}
        public void HandleVulnerable(){}
        public void HandleHealthy(){}
        public void HandleIll(){}
        public void HandleSymptomatic(){}
        public void HandleAsymptomatic(){}
    }
    
    abstract class State
    {
        protected Context _context;

        public void SetContext(Context context)
        {
            _context = context;
        }

        public abstract bool Handle1();

        public abstract bool Handle2();
    }

    class SImmunize : State
    {
        public override bool Handle1()
        {
            Console.WriteLine("Jestem odporny");
            return false;
        }

        public override bool Handle2()
        {
            Console.WriteLine("Jestem nieodporny");
            return true;
        }
    }
    
    class SHealth : State
    {
        public override bool Handle1()
        {
            Console.WriteLine("Jestem zdrowy");
            return false;
        }

        public override bool Handle2()
        {
            Console.WriteLine("Jestem chory");
            _context.TransitionTo(new SSymtomps());
            return true;
        }
    }
    
    class SSymtomps : State
    {
        public override bool Handle1()
        {
            Console.WriteLine("Jestem zdrowy");
            return false;
        }

        public override bool Handle2()
        {
            Console.WriteLine("Jestem zarażony");
            _context.TransitionTo(new SHealth());
            return true;
        }
    }
}