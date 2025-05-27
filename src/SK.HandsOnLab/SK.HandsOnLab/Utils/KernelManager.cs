using Microsoft.SemanticKernel;

namespace SK.HandsOnLab.Utils;

internal class KernelManager
{
    public static Kernel GetChatKernel()
    {
        var configuration = Configuration.GetConfiguration();
        string? chatModelDeploymentName = configuration["appsettings:chatModelDeploymentName"];
        string? endpoint = configuration["appsettings:endpoint"];
        string? apiKey = configuration["appsettings:apiKey"];

        if (string.IsNullOrEmpty(chatModelDeploymentName) || string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(apiKey))
        {
            throw new InvalidOperationException("One or more required configuration values are missing.");
        }

        return
             Kernel
                .CreateBuilder()
                .AddAzureOpenAIChatCompletion(chatModelDeploymentName, endpoint, apiKey)
                .Build();
    }

    public static Kernel GetImageKernel()
    {
        var configuration = Configuration.GetConfiguration();
        string? imageModelDeploymentName = configuration["appsettings:imageModelDeploymentName"];
        string? endpoint = configuration["appsettings:endpoint"];
        string? apiKey = configuration["appsettings:apiKey"];

        if (string.IsNullOrEmpty(imageModelDeploymentName) || string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(apiKey))
        {
            throw new InvalidOperationException("One or more required configuration values are missing.");
        }

        return
             Kernel
                .CreateBuilder()
                .AddAzureOpenAITextToImage(imageModelDeploymentName, endpoint, apiKey)
                .Build();
    }
}