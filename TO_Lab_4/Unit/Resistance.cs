using System;
using TO_Lab_4.Unit;

namespace TO_Lab_4
{
    public interface IResistance
    {
        bool InteractWith(Person person);
    };
    
    class Immunize : IResistance
    {
        public bool InteractWith(Person person)
        {
            return false;
        }
    };

    class UnImminize : IResistance
    {
        public bool InteractWith(Person person)
        {
            return person.Health.InteractWith(person);
        }
    };
}