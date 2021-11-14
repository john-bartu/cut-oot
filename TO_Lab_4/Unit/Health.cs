namespace TO_Lab_4.Unit
{
    public interface IHealth
    {
        bool InteractWith(Person person);
    };

    class Healthy : IHealth
    {
        public bool InteractWith(Person person)
        {
            return false;
        }
    };

    class Ill : IHealth
    {
        public bool InteractWith(Person person)
        {
            return person.Symptoms.Infect();
        }
    };
}