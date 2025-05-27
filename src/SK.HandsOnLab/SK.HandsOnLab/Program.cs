using SK.HandsOnLab.Labs;
using System.Reflection;

namespace SK.HandsOnLab
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine("      Semantic Kernel Hands-On Lab Selection Menu       ");
            Console.WriteLine("========================================================");

            // Dictionary to hold lab classes with their corresponding numbers
            var labs = new Dictionary<int, Type>();

            // Find all classes that implement ILab interface
            var labTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(ILab).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .ToList();

            // Sort labs by their number attribute if available
            for (int i = 0; i < labTypes.Count; i++)
            {
                labs.Add(i + 1, labTypes[i]);
            }

            // Display available labs
            foreach (var lab in labs)
            {
                // Create an instance of the lab to access its Name property
                if (Activator.CreateInstance(lab.Value) is ILab labInstance)
                {
                    Console.WriteLine($"{lab.Key}. {labInstance.Name}");
                }
            }

            Console.WriteLine("\nEnter the number of the lab you want to run (or 0 to exit):");

            // Get user choice
            if (int.TryParse(Console.ReadLine(), out int choice) && labs.ContainsKey(choice))
            {
                // Create an instance of the selected lab and run it
                if (Activator.CreateInstance(labs[choice]) is ILab selectedLab)
                {
                    Console.Clear();
                    await selectedLab.RunAsync();
                }
            }
            else if (choice == 0)
            {
                Console.WriteLine("Exiting program...");
            }
            else
            {
                Console.WriteLine("Invalid selection. Please run the program again.");
            }

            //Console.WriteLine("\nPress any key to exit...");
            //Console.ReadKey();
        }
    }
}