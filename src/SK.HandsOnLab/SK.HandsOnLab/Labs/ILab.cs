namespace SK.HandsOnLab.Labs;

// Interface that all labs must implement
public interface ILab
{
    string Name { get; set; }
    Task RunAsync();
}