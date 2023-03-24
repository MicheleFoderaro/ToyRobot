using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToyRobot.Commands;
using ToyRobot.Helpers;
using ToyRobot.Helpers.Output.Implementations;
using ToyRobot.Helpers.Output.Interfaces;
using ToyRobot.Helpers.Parser;
using ToyRobot.Models;
using ToyRobot.Models.Interfaces;

// Create a new host with default configurations
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        // Add dependencies to the service collection
        services.AddSingleton<ITableTop>(new TableTop(5, 5));
        services.AddSingleton<IActor, Robot>();
        services.AddSingleton<IPrinter, ConsolePrinter>();
        services.AddSingleton<IInputParser, InputParser>();
        services.AddTransient<ICommandHandler, CommandHandler>();
        services.AddTransient<ICommandFactory, CommandFactory>();
    })
    .Build();

// Create a new scope for the service provider
using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

// Get the required dependencies from the service provider
var commandHandler = provider.GetRequiredService<ICommandHandler>();
var printer = provider.GetRequiredService<IPrinter>();

// Display a welcome message to the user
string message = Helpers.GetWelcomeMessage();
printer.DisplayMessage(message);

do
{
    // Prompt the user for input
    printer.DisplayMessage("Request: ");
    string? input = Console.ReadLine();

    if (String.IsNullOrEmpty(input))
        continue;

    // Convert the input to uppercase to simplify handling
    input = input.ToUpper();

    // Exit the loop if the user enters "QUIT"
    if (input.Equals("QUIT"))
        break;

    try
    {
        // Handle the user input with the command handler
        commandHandler.Handle(input);
    }
    catch (Exception ex)
    {
        printer.DisplayErrorMessage(ex.Message);
    }
} while (true);


await host.RunAsync();


