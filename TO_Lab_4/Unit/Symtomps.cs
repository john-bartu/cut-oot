using System;

namespace TO_Lab_4.Unit
{
    public interface ISymtomps
    {
        bool Infect();
    };

    class Asymptomatic : ISymtomps
    {
        public bool Infect()
        {
            return Random.Shared.Next(2) == 1;
        }
    };

    class Symptomatic : ISymtomps
    {
        public bool Infect()
        {
            return true;
        }
    };
}