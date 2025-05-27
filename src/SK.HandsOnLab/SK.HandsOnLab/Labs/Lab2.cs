using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.TextToImage;
using SK.HandsOnLab.Utils;

namespace SK.HandsOnLab.Labs;

public class Lab2 : ILab
{
    public string Name { get; set; } = "Create an image from text";

    public async Task RunAsync()
    {
        Console.WriteLine("========================================================");
        Console.WriteLine($"Running Lab - {Name}");
        Console.WriteLine("========================================================");

        var kernel = KernelManager.GetImageKernel();
        var service = kernel.GetRequiredService<ITextToImageService>();

        Console.WriteLine("Describe the image you wants to generate: \n");

        string? userRequest = Console.ReadLine();

        Console.WriteLine("Wait for generation...");

            var generatedImages = await service.GetImageContentsAsync(
                                                new TextContent(userRequest),
                                                new OpenAITextToImageExecutionSettings { Size = (Width: 1792, Height: 1024) });

            Console.WriteLine(generatedImages[0].Uri!.ToString());
    }
}