using System;

namespace TO_Lab_6.Proxy
{
    public interface ISubject<T>
    {
        public T Operation(T subject);
    }

    class NameChecker : ISubject<string>
    {
        public string Operation(string subject)
        {
            if (string.IsNullOrEmpty(subject))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            string subjectCorrect = char.ToUpper(subject[0]) + subject.Substring(1).ToLower();

            //Console.WriteLine($"Name fixing {subject,16} => {subjectCorrect,16}");

            return subjectCorrect;
        }
    }
}