using System;

namespace TO_Lab_5.Strategy
{
    public interface IExecutionStrategy
    {
        float execute();
    }


    public class Emergency : IExecutionStrategy
    {
        public float execute()
        {
            return Random.Shared.NextSingle() * 25 + 5;
        }
    }

    public class Fake : IExecutionStrategy
    {
        public float execute()
        {
            return 0;
        }
    }
}