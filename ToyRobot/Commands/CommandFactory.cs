using ToyRobot.Commands.Implementations;
using ToyRobot.Commands.Interfaces;
using ToyRobot.Enums;
using ToyRobot.Helpers;
using ToyRobot.Helpers.Output.Interfaces;
using ToyRobot.Models.Interfaces;

namespace ToyRobot.Commands
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IActor actor;
        private readonly ITableTop tabletop;
        private readonly IPrinter printer;
        public CommandFactory(IActor actor, ITableTop tabletop, IPrinter printer)
        {
            this.actor = actor;
            this.tabletop = tabletop;
            this.printer = printer;
        }

        public ICommand Create(InputCommand inputCommand)
        {
            return inputCommand.Command switch
            {
                Command.PLACE => new PlaceCommand(actor, tabletop, inputCommand.Position!, inputCommand.Direction!.Value),
                Command.REPORT => new ReportCommand(actor, printer),
                Command.RIGHT => new RightCommand(actor),
                Command.LEFT => new LeftCommand(actor),
                Command.MOVE => new MoveCommand(actor, tabletop),
                _ => throw new InvalidOperationException("Unrecognized command. " +
                    "Please try again using the following format: PLACE X,Y,Direction|MOVE|LEFT|RIGHT|REPORT")
            };
        }
    }
}

