using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Models.Interfaces;
using ToyRobot.Models;
using ToyRobot.Enums;

namespace ToyRobot.Commands.Implementations.Tests
{
    [TestClass()]
    public class PlaceCommandTests
    {
        private Mock<IActor> actorMock;
        private Mock<ITableTop> tableTopMock;

        [TestInitialize]
        public void TestSetup()
        {
            actorMock = new Mock<IActor>();
            tableTopMock = new Mock<ITableTop>();
        }

        [TestMethod]
        public void Validate_WhenValidPosition_ReturnsTrue()
        {
            var position = new Position(1, 2);
            var direction = Direction.NORTH;
            var placeCommand = new PlaceCommand(actorMock.Object
                , tableTopMock.Object
                , position
                , direction);
            tableTopMock.Setup(tt => tt.IsPositionValid(position)).Returns(true);

            var result = placeCommand.Validate();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Validate_WhenInvalidPosition_ReturnsFalse()
        {
            var position = new Position(-1, 2);
            var direction = Direction.NORTH;
            var placeCommand = new PlaceCommand(actorMock.Object
                , tableTopMock.Object
                , position
                , direction);
            tableTopMock.Setup(tt => tt.IsPositionValid(position)).Returns(false);

            var result = placeCommand.Validate();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Execute_WhenValidPositionAndDirection_SetsActorPositionAndDirection()
        {
            var position = new Position(1, 2);
            var direction = Direction.NORTH;
            var placeCommand = new PlaceCommand(actorMock.Object
                , tableTopMock.Object
                , position
                , direction);
            tableTopMock.Setup(tt => tt.IsPositionValid(position)).Returns(true);

            placeCommand.Execute();

            actorMock.VerifySet(a => a.Position = position, Times.Once);
            actorMock.VerifySet(a => a.Direction = direction, Times.Once);
        }

        [TestMethod]
        public void Execute_WhenInvalidPosition_DoesNotSetActorPositionOrDirection()
        {
            var position = new Position(-1, 2);
            var direction = Direction.NORTH;
            var placeCommand = new PlaceCommand(actorMock.Object
                , tableTopMock.Object
                , position
                , direction);
            tableTopMock.Setup(tt => tt.IsPositionValid(position)).Returns(false);

            placeCommand.Execute();

            actorMock.VerifySet(a => a.Position = position, Times.Never);
            actorMock.VerifySet(a => a.Direction = direction, Times.Never);
        }        
    }
}