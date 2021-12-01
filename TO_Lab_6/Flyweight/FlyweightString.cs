namespace TO_Lab_6
{
    interface IFlyweight<T>
    {
        public T GetState();
    }
    
    
    public class Flyweight<T> : IFlyweight<T>
    {
        private T _state;

        public Flyweight(T state)
        {
            _state = state;
        }

        public T GetState()
        {
            return _state;
        }
    }
}