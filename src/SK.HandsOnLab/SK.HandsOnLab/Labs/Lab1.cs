using Microsoft.SemanticKernel;
using SK.HandsOnLab.Utils;

namespace SK.HandsOnLab.Labs;

public class Lab1 : ILab
{
    public string Name { get; set; } = "Vanilla Azure Open AI call";

    public async Task RunAsync()
    {
        Console.WriteLine($"Running Lab 1 - {Name}");

        var kernel = KernelManager.GetChatKernel();

        Console.WriteLine("Ask your question: \n");

        string? userRequest = Console.ReadLine();

        var result = await kernel.InvokePromptAsync(userRequest);

        Console.WriteLine(result);
    }
}