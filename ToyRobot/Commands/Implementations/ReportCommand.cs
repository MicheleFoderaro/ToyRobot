using ToyRobot.Commands.Interfaces;
using ToyRobot.Helpers.Output.Interfaces;
using ToyRobot.Models.Interfaces;

namespace ToyRobot.Commands.Implementations
{
    public class ReportCommand : ICommand, IValidator
    {
        private readonly IActor actor;
        private readonly IPrinter printer;
        public ReportCommand(IActor actor, IPrinter printer)
        {
            this.actor = actor;
            this.printer = printer;
        }

        public void Execute()
        {
            if (Validate())
                printer.DisplayMessage(string.Format("Output: {0},{1},{2}", 
                    actor.Position!.X,
                    actor.Position!.Y, 
                    actor.Direction!.ToString()));
        }

        public bool Validate()
        {
            return actor.IsPlaced;
        }
    }
}
