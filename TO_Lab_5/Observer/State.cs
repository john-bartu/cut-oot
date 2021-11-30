namespace TO_Lab_5.Observer
{
    public abstract class State
    {
        protected FireTruck fireTruck;

        public void SetContext(FireTruck fireTruck)
        {
            this.fireTruck = fireTruck;
        }

        public void HandleFree(){}
        public void HandleTravelTo(){}
        public void HandleBusy(){}
        public void HandleTravelReturn(){}
    }

    class IdleState : State
    {
    
        
    }

    class BusyState : State
    {
        public new void HandleFree()
        {
            throw new System.NotImplementedException();
        }

        public new void HandleTravelTo()
        {
            throw new System.NotImplementedException();
        }

        public new void HandleBusy()
        {
            throw new System.NotImplementedException();
        }

        public new void HandleTravelReturn()
        {
            throw new System.NotImplementedException();
        }
    }
}