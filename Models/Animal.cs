namespace MiniZooApi.Models;

public class Animal
{
    public Animal(int id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
}
