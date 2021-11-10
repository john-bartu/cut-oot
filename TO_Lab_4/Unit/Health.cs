namespace TO_Lab_4.Unit
{
    public interface IHelath
    {
        bool InteractWith(Person person);
    };

    class Healthy : IHelath
    {
        public bool InteractWith(Person person)
        {
            return false;
        }
    };

    class Ill : IHelath
    {
        public bool InteractWith(Person person)
        {
            return person.Symtomps.Infect();
        }
    };
}