namespace ToyRobot.Helpers.Output.Interfaces
{
    public interface IPrinter
    {
        public void DisplayMessage(string message);
        public void DisplayErrorMessage(string errorMessage);
    }
}
