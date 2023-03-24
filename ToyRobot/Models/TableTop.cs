using ToyRobot.Models.Interfaces;

namespace ToyRobot.Models
{
    public class TableTop : ITableTop
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; } 

        public TableTop(int rows, int columns)
        {
            Rows = rows; 
            Columns = columns;
        }

        /* This method checks whether the given position is valid or not, 
         * based on the number of rows and columns on the tabletop */
        public bool IsPositionValid(Position position)
        {
            return position.X >= 0 && position.X < Columns
                && position.Y >= 0 && position.Y < Rows;
        }

    }
}
