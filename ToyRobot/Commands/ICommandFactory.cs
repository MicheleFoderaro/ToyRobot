using ToyRobot.Commands.Interfaces;

namespace ToyRobot.Commands
{
    public interface ICommandFactory
    {
        public ICommand Create(InputCommand inputCommand);
    }
}

