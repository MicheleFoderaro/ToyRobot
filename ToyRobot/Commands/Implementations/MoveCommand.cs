using ToyRobot.Commands.Interfaces;
using ToyRobot.Models.Interfaces;

namespace ToyRobot.Commands.Implementations
{
    public class MoveCommand : ICommand, IValidator
    {
        private readonly IActor actor;
        private readonly ITableTop tableTop;
        public MoveCommand(IActor actor, ITableTop tableTop)
        {
            this.actor = actor;
            this.tableTop = tableTop;
        }

        public void Execute()
        {
            if (Validate())
            {
                actor.Position = actor.GetNextPosition();
            }              
        }

        public bool Validate()
        {
            var pos = actor.GetNextPosition();
            var test = tableTop.IsPositionValid(pos);
            if (!actor.IsPlaced || !tableTop.IsPositionValid(actor.GetNextPosition()))
                return false;

            return true;
        }
    }
}
