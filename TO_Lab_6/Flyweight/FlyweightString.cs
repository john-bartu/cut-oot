namespace TO_Lab_6
{
    interface IFlyweight<T>
    {
        public T GetState();
    }


    public class Flyweight<T> : IFlyweight<T>
    {
        public T State { get; set; }

        public Flyweight(T state)
        {
            State = state;
        }

        public T GetState()
        {
            return State;
        }

        public override string ToString()
        {
            return State!.ToString()!;
        }
    }
}