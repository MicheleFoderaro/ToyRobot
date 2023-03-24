using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Models.Interfaces;
using Moq;
using ToyRobot.Enums;
using ToyRobot.Models;
using ToyRobot.Commands.Implementations;
using ToyRobot.Helpers.Output.Interfaces;

namespace ToyRobot.Commands.Tests
{
    [TestClass()]
    public class CommandFactoryTests
    {
        private Mock<IActor> actorMock;
        private Mock<ITableTop> tableTopMock;
        private Mock<IPrinter> printerMock;
        private ICommandFactory factory;

        [TestInitialize]
        public void TestSetup()
        {
            actorMock = new Mock<IActor>();
            tableTopMock = new Mock<ITableTop>();
            printerMock = new Mock<IPrinter>();
            factory = new CommandFactory(actorMock.Object, tableTopMock.Object, printerMock.Object);
        }

        [TestMethod]
        public void Create_InvalidCommand_ThrowsException()
        {
            var inputCommand = new InputCommand
            {
                Command = (Command)99, // Invalid command
                Position = new Position(1, 2),
                Direction = Direction.NORTH
            };

            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                factory.Create(inputCommand);
            });
        }

        [TestMethod]
        public void Create_ReportCommand_ReturnsCorrectCommandType()
        {
            var inputCommand = new InputCommand
            {
                Command = Command.REPORT
            };

            var command = factory.Create(inputCommand);

            Assert.IsInstanceOfType(command, typeof(ReportCommand));
        }

        [TestMethod]
        public void Create_RightCommand_ReturnsCorrectCommandType()
        {
            var inputCommand = new InputCommand
            {
                Command = Command.RIGHT
            };

            var command = factory.Create(inputCommand);

            Assert.IsInstanceOfType(command, typeof(RightCommand));
        }

        [TestMethod]
        public void Create_LeftCommand_ReturnsCorrectCommandType()
        {
            var inputCommand = new InputCommand
            {
                Command = Command.LEFT
            };

            var command = factory.Create(inputCommand);

            Assert.IsInstanceOfType(command, typeof(LeftCommand));
        }

        [TestMethod]
        public void Create_PlaceCommand_ReturnsCorrectCommandType()
        {
            var inputCommand = new InputCommand
            {
                Command = Command.PLACE,
                Position = new Position(1, 2),
                Direction = Direction.NORTH
            };

            var result = factory.Create(inputCommand);

            Assert.IsInstanceOfType(result, typeof(PlaceCommand));
        }

        [TestMethod]
        public void Create_MoveCommand_ReturnsCorrectCommandType()
        {
            var inputCommand = new InputCommand
            {
                Command = Command.MOVE
            };

            var result = factory.Create(inputCommand);

            Assert.IsInstanceOfType(result, typeof(MoveCommand));
        }
    }
}