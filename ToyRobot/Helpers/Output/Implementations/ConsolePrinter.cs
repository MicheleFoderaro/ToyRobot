using ToyRobot.Helpers.Output.Interfaces;

namespace ToyRobot.Helpers.Output.Implementations
{
    public class ConsolePrinter : IPrinter
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayErrorMessage(string errorMessage)
        {
            Console.Error.WriteLine(errorMessage);
        }
    }
}
