using System;

namespace TO_Lab_6.Proxy
{
    public interface ISubject<T>
    {
        public T operation(T subject);
    }


    class NameChecker : ISubject<string>
    {
        public string operation(string subject)
        {
            if (string.IsNullOrEmpty(subject))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            return char.ToUpper(subject[0]) + subject.Substring(1).ToLower();
        }
    }
}