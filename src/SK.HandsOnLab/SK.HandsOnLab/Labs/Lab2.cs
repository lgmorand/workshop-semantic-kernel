using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using SK.HandsOnLab.Plugins;
using SK.HandsOnLab.Utils;

namespace SK.HandsOnLab.Labs;

public class Lab2 : ILab
{
    public string Name { get; set; } = "Use plugins";

    public async Task RunAsync()
    {
        Console.WriteLine($"Running Lab 2 - {Name}");

        var kernel = KernelManager.GetChatKernel();
        kernel.ImportPluginFromType<WeatherPlugin>();

        Console.WriteLine("Ask your question: \n");

        string? userRequest = Console.ReadLine();

        OpenAIPromptExecutionSettings settings = new() { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() };

        var result = await kernel.InvokePromptAsync(userRequest, new(settings));

        Console.WriteLine(result);

        userRequest = Console.ReadLine();
    }
}