namespace TO_Lab_5.Observer
{
    public class FireTruck
    {
        private string name;
        public State state;

        public FireTruck(string s)
        {
            name = s;
            
            state = new IdleState();
            state.SetContext(this);
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