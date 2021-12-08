using System;
using System.Threading.Tasks;

namespace TO_Lab_5.Observer
{
    public abstract class State
    {
        protected FireTruck fireTruck;

        public  void SetContext(FireTruck newTruck)
        {
            fireTruck = newTruck;
        }

        public virtual void HandleFree()
        {
            throw new Exception("Can't become released" + fireTruck.state);
        }

        public virtual void HandleTravelTo()
        {
            throw new Exception("Can't become travelling to" + fireTruck.state);
        }

        public virtual void HandleBusy()
        {
            throw new Exception("Can't become busy"+ fireTruck.state);
        }

        public virtual void HandleTravelReturn()
        {
            throw new Exception("Can't become travelling back"+ fireTruck.state);
        }
        
        public virtual void HandleWork()
        {
            throw new Exception("Can't become working"+ fireTruck.state);
        }
    }

    class IdleState : State
    {
        public override void HandleBusy()
        {
            fireTruck.TransitionTo( new BusyState());
        }
    }

    class BusyState : State
    {
        public override void HandleTravelTo()
        {
            fireTruck.TransitionTo( new TravellingToState());
        }
    }
    
    public class WorkingState : State
    {
        public override void HandleTravelReturn()
        {
            fireTruck.TransitionTo( new TravellingFromState());
            
        }
    }


    public class TravellingFromState : State
    {
        public override void HandleFree()
        {
            fireTruck.TransitionTo(new IdleState());
        }
    }

    public class TravellingToState : State
    {
        public override void HandleWork()
        {
            
            fireTruck.TransitionTo( new WorkingState());
        }
        
        public override void HandleTravelReturn()
        {
            fireTruck.TransitionTo( new TravellingFromState());
        }
    }
}