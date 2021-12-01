using TO_Lab_5.Vector;

namespace TO_Lab_6
{
    public class Person
    {
        private string name;
        private string surname;
        private Vector2 coordinate;

        public Person(string name, string surname,Vector2 coordinate)
        {
            this.coordinate = coordinate;
            this.name = name;
            this.surname = surname;
        }
    }
}