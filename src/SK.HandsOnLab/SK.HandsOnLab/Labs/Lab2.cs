using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using SK.HandsOnLab.Plugins.Native;
using SK.HandsOnLab.Utils;

namespace SK.HandsOnLab.Labs;

public class Lab2 : ILab
{
    public string Name { get; set; } = "Use semantic plugins";

    public async Task RunAsync()
    {
        Console.WriteLine("========================================================");
        Console.WriteLine($"Running Lab - {Name}");
        Console.WriteLine("========================================================");

        var kernel = KernelManager.GetChatKernel();
        kernel.ImportPluginFromPromptDirectory("Plugins/Semantic");

        Console.WriteLine("Ask your question: \n");

        string? userRequest = Console.ReadLine();

        OpenAIPromptExecutionSettings settings = new() { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() };

        var result = await kernel.InvokePromptAsync(userRequest, new(settings));

        Console.WriteLine(result);

        userRequest = Console.ReadLine();
    }
}