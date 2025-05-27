using Microsoft.SemanticKernel;

namespace SK.HandsOnLab.Utils
{
    internal class KernelManager
    {
        public static Kernel GetChatKernel()
        {
            var configuration = Configuration.GetConfiguration();
            string? deploymentName = configuration["appsettings:deploymentName"];
            string? endpoint = configuration["appsettings:endpoint"];
            string? apiKey = configuration["appsettings:apiKey"];

            if (string.IsNullOrEmpty(deploymentName) || string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("One or more required configuration values are missing.");
            }

            return
                 Kernel
                .CreateBuilder()
                .AddAzureOpenAIChatCompletion(deploymentName, endpoint, apiKey)
                .Build();
        }
    }
}
