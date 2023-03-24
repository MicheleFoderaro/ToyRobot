using ToyRobot.Enums;

namespace ToyRobot.Models.Interfaces
{
    public interface ITableTop
    {
        public int Rows { get; }
        public int Columns { get; }
        bool IsPositionValid(Position position);

    }
}
