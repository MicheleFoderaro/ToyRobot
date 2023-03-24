using ToyRobot.Enums;
using ToyRobot.Models.Interfaces;

namespace ToyRobot.Models
{
    public class Robot : IActor
    {
        public Position? Position { get; set; }
        public Direction? Direction { get; set; }
        public bool IsPlaced => Position is not null || Direction.HasValue;

        /* This method returns the next position of the actor on the tabletop based on its current direction.
         * The position is determined by adding or subtracting 1 from the X or Y coordinate 
         * of the current position based on the direction of the actor.*/
        public Position GetNextPosition()
        {
            var (x, y) = Direction switch
                {
                    Enums.Direction.NORTH => (Position!.X, Position.Y + 1),
                    Enums.Direction.EAST => (Position!.X + 1, Position.Y),
                    Enums.Direction.SOUTH => (Position!.X, Position.Y - 1),
                    Enums.Direction.WEST => (Position!.X - 1, Position.Y),
                    _ => throw new ArgumentException("Invalid direction. " +
                        "Please select from one of the following directions: NORTH|EAST|SOUTH|WEST")
                };

            return new Position(x, y);
        }
    }
}
