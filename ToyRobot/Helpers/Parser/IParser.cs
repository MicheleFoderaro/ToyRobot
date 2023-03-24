using ToyRobot.Commands;

namespace ToyRobot.Helpers.Parser
{
    public interface IInputParser
    {
        public InputCommand ParseCommand(string inputRequest);
    }
}
