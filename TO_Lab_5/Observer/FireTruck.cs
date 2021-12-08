using System.Collections.Generic;
using TO_Lab_5.Vector;

namespace TO_Lab_5.Observer
{
    public class FireTruck
    {
        private string name;
        public State state;
        public Vector2 position;

        public FireTruck(string s, Vector2 vector2)
        {
            name = s;
            
            state = new IdleState();
            state.SetContext(this);
            position = vector2;
        }

        public override string ToString()
        {
            return $"Truck({name})";
        }

        public void TransitionTo(State _state)
        {
            // Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
            state = _state;
            state.SetContext(this);
        }

        public void HandleFree()
        {
            state.HandleFree();
        }

        public void HandleTravelTo()
        {
            state.HandleTravelTo();
        }

        public void HandleBusy()
        {
            state.HandleBusy();
        }

        public void HandleTravelReturn()
        {
            state.HandleTravelReturn();
        }

        public void HandleWork()
        {
            state.HandleWork();
        }
     
    }
}