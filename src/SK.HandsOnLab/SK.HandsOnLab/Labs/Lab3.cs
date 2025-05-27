using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using SK.HandsOnLab.Plugins.Native;
using SK.HandsOnLab.Utils;

namespace SK.HandsOnLab.Labs;

public class Lab3 : ILab
{
    public string Name { get; set; } = "Use auto function calling";

    public async Task RunAsync()
    {
        Console.WriteLine("========================================================");
        Console.WriteLine($"Running Lab - {Name}");
        Console.WriteLine("========================================================");

        var kernel = KernelManager.GetChatKernel();
        kernel.ImportPluginFromPromptDirectory("Plugins/Semantic");
        kernel.ImportPluginFromType<WeatherPlugin>();

        Console.WriteLine("Ask your question: \n");

        string? userRequest = Console.ReadLine();

        OpenAIPromptExecutionSettings settings = new() { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() };

        var result = await kernel.InvokePromptAsync(userRequest, new(settings));

        Console.WriteLine(result);

        userRequest = Console.ReadLine();
    }
}