using ToyRobot.Commands.Interfaces;
using ToyRobot.Enums;
using ToyRobot.Models;
using ToyRobot.Models.Interfaces;

namespace ToyRobot.Commands.Implementations
{
    public class PlaceCommand : ICommand, IValidator
    {
        private readonly IActor actor;
        private readonly ITableTop tableTop;
        private readonly Direction direction; 
        private readonly Position position;
        public PlaceCommand(IActor actor, ITableTop tableTop,  Position position, Direction direction)
        {
            this.actor = actor;
            this.tableTop = tableTop;
            this.direction = direction;
            this.position = position;
        }

        public void Execute()
        {
            if (Validate())
            {
                actor.Position = position;
                actor.Direction = direction;
            }
        }
        
        public bool Validate()
        {
            return tableTop.IsPositionValid(position);
        }
    }
}
