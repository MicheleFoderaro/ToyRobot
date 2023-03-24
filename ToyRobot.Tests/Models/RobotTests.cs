using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Models.Interfaces;

namespace ToyRobot.Models.Tests
{
    [TestClass()]
    public class RobotTests
    {
        [TestMethod()]
        public void GetNextPositionTest()
        {            
            IActor actor = new Robot
            {
                Position = new Position(4, 4), 
                Direction = Enums.Direction.NORTH
            };
            var result = actor.GetNextPosition();
            var expectedPosition = new Position(4, 5);
            Assert.AreEqual(expectedPosition, result);

            IActor actor2 = new Robot
            {
                Position = new Position(4, 4),
                Direction = Enums.Direction.SOUTH
            };
            var result2 = actor2.GetNextPosition();
            var expectedPosition2 = new Position(4, 3);
            Assert.AreEqual(expectedPosition2, result2);

            IActor actor3 = new Robot
            {
                Position = new Position(4, 4),
                Direction = Enums.Direction.EAST
            };
            var result3 = actor3.GetNextPosition();
            var expectedPosition3 = new Position(5, 4);
            Assert.AreEqual(expectedPosition3, result3);

            IActor actor4 = new Robot
            {
                Position = new Position(4, 4),
                Direction = Enums.Direction.WEST
            };
            var result4 = actor4.GetNextPosition();
            var expectedPosition4 = new Position(3, 4);
            Assert.AreEqual(expectedPosition4, result4);
        }
    }
}