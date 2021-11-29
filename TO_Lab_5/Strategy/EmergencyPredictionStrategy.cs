namespace TO_Lab_5.Strategy
{
    public interface IEventStrategy
    {
        int execute();
    }
    
    public class EventMz : IEventStrategy
    {
        public int execute()
        {
            return 2;
        }
    }
    
    public class EventPz : IEventStrategy
    {
        public int execute()
        {
            return 3;
        }
    }
    
    public class EventAfMz : IEventStrategy
    {
        public int execute()
        {
            return 2;
        }
    }
    
    public class EventAfPz: IEventStrategy
    {
        public int execute()
        {
            return 3;
        }
    }
}