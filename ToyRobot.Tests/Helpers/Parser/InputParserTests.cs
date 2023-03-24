using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Helpers.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Commands;

namespace ToyRobot.Helpers.Parser.Tests
{
    [TestClass()]
    public class InputParserTests
    {
        [TestMethod()]
        public void ParseCommandTest_Move()
        {
            IInputParser inputParser = new InputParser();    
            string inputRequest = "MOVE";
            var result = inputParser.ParseCommand(inputRequest);            
            InputCommand expectedResult = new()
            {
                Command = Enums.Command.MOVE
            };

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void ParseCommandTest_Left()
        {
            IInputParser inputParser = new InputParser();
            string inputRequest = "LEFT";
            var result = inputParser.ParseCommand(inputRequest);
            InputCommand expectedResult = new()
            {
                Command = Enums.Command.LEFT,
            };

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void ParseCommandTest_Right()
        {
            IInputParser inputParser = new InputParser();
            string inputRequest = "RIGHT";
            var result = inputParser.ParseCommand(inputRequest);
            InputCommand expectedResult = new()
            {
                Command = Enums.Command.RIGHT
            };

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void ParseCommandTest_Report()
        {
            IInputParser inputParser = new InputParser();
            string inputRequest = "REPORT";
            var result = inputParser.ParseCommand(inputRequest);
            InputCommand expectedResult = new()
            {
                Command = Enums.Command.REPORT
            };

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void ParseCommandTest_ValidPlace()
        {
            IInputParser inputParser = new InputParser();
            string inputRequest = "PLACE 1,1,NORTH";
            var result = inputParser.ParseCommand(inputRequest);
            InputCommand expectedResult = new()
            {
                Command = Enums.Command.PLACE,
                Direction = Enums.Direction.NORTH,
                Position = new Models.Position(1, 1)
            };

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void ParseCommandTest_InvalidPlace()
        {
            IInputParser inputParser = new InputParser();

            string inputRequest = "PLACE";            
            Assert.ThrowsException<ArgumentException>(() =>
            {
                inputParser.ParseCommand(inputRequest);
            });

            string inputRequest2 = "PLACE 1,1";
            Assert.ThrowsException<ArgumentException>(() =>
            {
                inputParser.ParseCommand(inputRequest2);
            });

            string inputRequest3 = "PLACE X,Y,NORTH";
            Assert.ThrowsException<ArgumentException>(() =>
            {
                inputParser.ParseCommand(inputRequest3);
            });

            string inputRequest4 = "PLACE X,Y,NOTVALID";
            Assert.ThrowsException<ArgumentException>(() =>
            {
                inputParser.ParseCommand(inputRequest4);
            });
        }

        [TestMethod()]
        public void ParseCommandTest_InvalidCommand()
        {
            IInputParser inputParser = new InputParser();
            string inputRequest = "UNHANDLED";
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                inputParser.ParseCommand(inputRequest);
            });
        }

    }
}