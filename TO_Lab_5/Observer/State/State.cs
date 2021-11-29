namespace TO_Lab_5.Observer.State
{
    public abstract class State
    {
        protected FireTruck fireTruck;

        public void SetContext(FireTruck fireTruck)
        {
            this.fireTruck = fireTruck;
        }

        public abstract void HandleFree();
        public abstract void HandleTravelTo();
        public abstract void HandleBusy();
        public abstract void HandleTravelReturn();
    }


    class BusyState : State
    {
        public override void HandleFree()
        {
            throw new System.NotImplementedException();
        }

        public override void HandleTravelTo()
        {
            throw new System.NotImplementedException();
        }

        public override void HandleBusy()
        {
            throw new System.NotImplementedException();
        }

        public override void HandleTravelReturn()
        {
            throw new System.NotImplementedException();
        }
    }
}