using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.ChatCompletion;
using SK.HandsOnLab.Plugins.Native;
using SK.HandsOnLab.Utils;

namespace SK.HandsOnLab.Labs;

public class Lab5 : ILab
{
    public string Name { get; set; } = "Agent mode";

    public async Task RunAsync()
    {
        Console.WriteLine("========================================================");
        Console.WriteLine($"Running Lab - {Name}");
        Console.WriteLine("========================================================");

        await CreateAnAgentAsync();
    }

    public async Task CreateAnAgentAsync()
    {
        var activityAgent = CreateWeatherAgent();

        Console.WriteLine("Ask your question: \n");

        string? userRequest = Console.ReadLine();
        var userMessage = new ChatMessageContent(AuthorRole.User, userRequest);

        while (userMessage != null)
        {
            await foreach (AgentResponseItem<ChatMessageContent> response in activityAgent.InvokeAsync(userMessage))
            {
                Console.WriteLine(response.Message);
            }

            userRequest = Console.ReadLine();
            userMessage = new ChatMessageContent(AuthorRole.User, userRequest);
        }
    }
    
    public ChatCompletionAgent CreateWeatherAgent()
    {
        const string AgentName = "WeatherAgent";
        const string AgentDescription = "An agent that provides weather information and suggestions based on the weather conditions.";
        const string AgentInstructions = "You are an agent that can help with weather information. You can answer questions about the weather, suggest activities based on the weather, and provide information about it.";
        
        ChatCompletionAgent agent =
           new()
           {
               Name = AgentName,
               Description = AgentDescription,
               Instructions = AgentInstructions,
               Kernel = KernelManager.GetChatKernel(),
           };
        agent.Kernel.ImportPluginFromType<WeatherPlugin>();

        return agent;
    }
}