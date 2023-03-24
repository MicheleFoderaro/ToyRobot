using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ToyRobot.Helpers.Parser;
using ToyRobot.Enums;
using ToyRobot.Commands.Interfaces;
using ToyRobot.Models;

namespace ToyRobot.Commands.Tests
{
    [TestClass()]
    public class CommandHandlerTests
    {
        private Mock<ICommandFactory> mockCommandFactory;
        private Mock<IInputParser> mockInputParser;
        private ICommandHandler commandHandler;

        [TestInitialize]
        public void Setup()
        {
            mockCommandFactory = new Mock<ICommandFactory>();
            mockInputParser = new Mock<IInputParser>();
            commandHandler = new CommandHandler(mockCommandFactory.Object, mockInputParser.Object);
        }

        [TestMethod]
        public void Handle_ValidInput_CallsParseCommand()
        {
            string inputRequest = "PLACE 1,2,NORTH";
            var parsedCommand = new InputCommand { 
                Command = Command.PLACE, 
                Position = new Position(1,2), 
                Direction = Direction.NORTH
            };
            var mockCommand = new Mock<ICommand>();

            mockInputParser.Setup(parser => parser.ParseCommand(inputRequest)).Returns(parsedCommand);
            mockCommandFactory.Setup(factory => factory.Create(parsedCommand)).Returns(mockCommand.Object);

            commandHandler.Handle(inputRequest);

            mockInputParser.Verify(parser => parser.ParseCommand(inputRequest), Times.Once);
        }

        [TestMethod]
        public void Handle_ValidInput_CallsCreate()
        {
            string inputRequest = "MOVE";
            var parsedCommand = new InputCommand { Command = Command.MOVE };
            var mockCommand = new Mock<ICommand>();
            mockInputParser.Setup(parser => parser.ParseCommand(inputRequest)).Returns(parsedCommand);
            mockCommandFactory.Setup(factory => factory.Create(parsedCommand)).Returns(mockCommand.Object);

            commandHandler.Handle(inputRequest);

            mockCommandFactory.Verify(factory => factory.Create(parsedCommand), Times.Once);
        }

        [TestMethod]
        public void Handle_ValidInput_CallsExecute()
        {
            string inputRequest = "LEFT";
            var parsedCommand = new InputCommand { Command = Command.LEFT };
            var mockCommand = new Mock<ICommand>();
            mockInputParser.Setup(parser => parser.ParseCommand(inputRequest)).Returns(parsedCommand);
            mockCommandFactory.Setup(factory => factory.Create(parsedCommand)).Returns(mockCommand.Object);

            commandHandler.Handle(inputRequest);

            mockCommand.Verify(command => command.Execute(), Times.Once);
        }
    }
}