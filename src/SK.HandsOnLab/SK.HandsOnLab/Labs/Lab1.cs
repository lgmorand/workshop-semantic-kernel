namespace SK.HandsOnLab.Labs;


// Example lab classes - you would create 8 of these in separate files
public class Lab1 : ILab
{
    public string Name { get; set; } = "Semantic Kernel";

    public void Run()
    {
        Console.WriteLine($"Running Lab 1 - {Name}");
        // Lab 1 implementation here
    }
}