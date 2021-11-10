namespace TO_Lab_4.Unit
{
    public class Person : BodyPerson
    {
        public Person(IResistance resistance, IHelath helath, ISymtomps symtomps, float illTime)
        {
            Resistance = resistance;
            Helath = helath;
            Symtomps = symtomps;
            IllTime = illTime;
        }

        public IResistance Resistance { get; }
        public IHelath Helath { get; }
        public ISymtomps Symtomps { get; }

        public float IllTime { get; set; }

        public bool TouchedBy(Person person)
        {
            return Resistance.InteractWith(person);
        }
    }
}