using ToyRobot.Enums;
using ToyRobot.Models;

namespace ToyRobot.Commands
{
    public class InputCommand
    {
        public Command Command { get; set; }
        public Position? Position { get; set; }
        public Direction? Direction { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null || GetType() != obj.GetType())
            {
                return false;
            }

            InputCommand other = (InputCommand)obj;

            return Command == other.Command &&
                Position == other.Position &&
                Direction == other.Direction;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Command, Position, Direction);
        }

    }
}
