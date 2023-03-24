using ToyRobot.Helpers.Parser;

namespace ToyRobot.Commands
{
    public class CommandHandler : ICommandHandler
    {
        private readonly ICommandFactory commandFactory;
        private readonly IInputParser inputParser;
        public CommandHandler(ICommandFactory commandFactory, IInputParser inputParser)
        {
            this.commandFactory = commandFactory;
            this.inputParser = inputParser;
        }
        public void Handle(string inputRequest)
        {   
            var parsedCommand = inputParser.ParseCommand(inputRequest);
            var command = commandFactory.Create(parsedCommand);
            command.Execute();
        }
    }
}

