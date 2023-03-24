using ToyRobot.Enums;

namespace ToyRobot.Models.Interfaces
{
    public interface IActor
    {
        public Position? Position { get; set; }
        public Direction? Direction { get; set; }
        public bool IsPlaced { get; }
        public Position GetNextPosition();

    }
}
