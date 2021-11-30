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
        }

        public override string ToString()
        {
            return $"Truck({name})";
        }
    }
}