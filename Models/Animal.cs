namespace MiniZooApi.Models;

public class Animal
{
    public int Id { get; set; } // <- Muss vorhanden sein!
    public string Name { get; set; } = string.Empty;

    public Animal() { }

    public Animal(int id, string name)
    {
        Id = id;
        Name = name;
    }
}