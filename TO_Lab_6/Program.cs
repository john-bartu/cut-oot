using TO_Lab_6;

RegistryOffice registryOffice = new RegistryOffice();


string[] names =
    { "Jan", "Marcin", "Filip", "Szymon", "OskAr", "Artem", "Karol", "Eugeniusz", "Tomasz", "Karol" };
string[] surnames =
    { "Jarosz", "Rutecki", "Kocjan", "Waligóra", "Marcol", "Boczar", "Zubek", "Bojanowski", "Szcześniak", "Łęczycki" };


string RandomName()
{
    List<string> parts = new();
    for (int i = 0; i <= Random.Shared.Next(3); i++)
        parts.Add(names[Random.Shared.Next(names.Length)]);

    for (int i = 0; i <= Random.Shared.Next(3); i++)
        parts.Add(surnames[Random.Shared.Next(surnames.Length)]);

    return String.Join(" ", parts);
}


for (int i = 0; i <= 10; i++)
{
    registryOffice.RegisterPerson(RandomName(), Person.RandomLocation());
}

registryOffice.ExportMemoryTree();

registryOffice.ListWithMemory();
registryOffice.Export("export.json");

RegistryOffice secondRegistryOffice = RegistryOffice.Import("export.json");
secondRegistryOffice.ListWithMemory();
secondRegistryOffice.Export("export2.json");