using System.Text.Json;
using TO_Lab_5.Vector;
using TO_Lab_6.Proxy;

namespace TO_Lab_6
{
    public class RegistryOffice
    {
        public FlyweightFactory<string> _nameRegistry { get; set; }
        public List<Person> _persons { get; set; }

        public RegistryOffice()
        {
            _nameRegistry = new();
            _persons = new();
        }


        public void RegisterPerson(string name, Vector2 coord)
        {
            CorrectedFlyweightFactory checker = new CorrectedFlyweightFactory(_nameRegistry);

            Console.WriteLine($"Registry Adding: [{name}]");

            string[] nameParts = name.Split(" ");
            NamePart mainPart = new NamePart(checker.Operation(nameParts[0]));

            NamePart pointer = mainPart;
            for (int i = 1; i < nameParts.Length; i++)
            {
                NamePart nextNamePart = new(checker.Operation(nameParts[i]));
                pointer.SetNext(nextNamePart);
                pointer = pointer.GetNext()!;
            }


            Person person = new(mainPart, coord);
            _persons.Add(person);
            Console.WriteLine($"Registry Added: [{person}] \n");
        }

        public void ListWithMemory()
        {
            Console.WriteLine("Persons List");
            foreach (var person in _persons)
            {
                Console.WriteLine(person.ToString());
                Console.WriteLine(person.ToStringId());
                Console.WriteLine();
            }
        }


        public void ExportMemoryTree()
        {
            List<string> lines = new();

            lines.Add("@startuml");

            foreach (var name in _nameRegistry.GetFlyweights())
            {
                lines.Add($"class {name}");
            }

            foreach (var person in _persons)
            {
                NamePart name = person.GetName();
                string concate = person.ToString().Replace(" ", "");

                while (name.HasNext())
                {
                    lines.Add($"{name.GetPart()} {Tools.RandomArrow()} {name.GetNext()!.GetPart()}");
                    name = name.GetNext()!;
                }
            }

            lines.Add("@enduml");

            File.WriteAllLines("../../../ExportTree.puml", lines);
        }

        public void Export(string fileName)
        {
            string filePath = $"../../../{fileName}";
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllLines(filePath, new[] { jsonString });
        }

        public static RegistryOffice Import(string fileName)
        {
            string filePath = $"../../../{fileName}";
            string jsonString = File.ReadAllText(filePath);
            RegistryOffice importedRegistryOffice =
                JsonSerializer.Deserialize<RegistryOffice>(jsonString) ?? new RegistryOffice();
            return importedRegistryOffice;
        }
    }
}