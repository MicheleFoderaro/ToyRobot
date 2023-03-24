using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Models.Interfaces;

namespace ToyRobot.Models.Tests
{
    [TestClass()]
    public class TableTopTests
    {
        [TestMethod()]
        public void IsPositionValidTest_InvalidPosition()
        {
            ITableTop table = new TableTop(5, 5);

            var position1 = new Position(5, 5); 
            var result1 = table.IsPositionValid(position1);
            Assert.AreEqual(false, result1);

            var position2 = new Position(-1, -1);
            var result2 = table.IsPositionValid(position2);
            Assert.AreEqual(false, result2);
        }

        [TestMethod()]
        public void IsPositionValidTest_ValidPosition()
        {
            ITableTop table = new TableTop(5, 5);

            var position = new Position(4, 4);
            var result = table.IsPositionValid(position);
            Assert.AreEqual(true, result);

            var position2 = new Position(0, 0);
            var result2 = table.IsPositionValid(position2);
            Assert.AreEqual(true, result2);
        }
    }
}