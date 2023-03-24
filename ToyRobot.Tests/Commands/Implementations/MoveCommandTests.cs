using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Models.Interfaces;
using ToyRobot.Enums;
using ToyRobot.Models;

namespace ToyRobot.Commands.Implementations.Tests
{
    [TestClass()]
    public class MoveCommandTests
    {
        private Mock<IActor> actorMock;
        private Mock<ITableTop> tableTopMock;
        private MoveCommand moveCommand;

        [TestInitialize]
        public void TestSetup()
        {
            actorMock = new Mock<IActor>();
            tableTopMock = new Mock<ITableTop>();
            moveCommand = new MoveCommand(actorMock.Object, tableTopMock.Object);
        }

        [TestMethod]
        public void Validate_WhenActorIsNotPlaced_ShouldReturnFalse()
        {
            actorMock.SetupGet(a => a.IsPlaced).Returns(false);

            var isValid = moveCommand.Validate();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Validate_WhenCalculatedPositionIsOut_ShouldReturnFalse()
        {
            actorMock.SetupGet(a => a.IsPlaced).Returns(true);
            actorMock.SetupProperty(a => a.Direction, Direction.NORTH);
            actorMock.SetupProperty(a => a.Position, new Position(4,4));

            var isValid = moveCommand.Validate();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Validate_ShouldReturnTrue()
        {
            actorMock.SetupGet(a => a.IsPlaced).Returns(true);
            actorMock.SetupGet(a => a.Direction).Returns(Direction.NORTH);
            actorMock.SetupGet(a => a.Position).Returns(new Position(2, 2));
            actorMock.Setup(a => a.GetNextPosition()).Returns(new Position(2, 3));
            tableTopMock.SetupGet(t => t.Rows).Returns(5);
            tableTopMock.SetupGet(t => t.Columns).Returns(5);
            tableTopMock.Setup(t => t.IsPositionValid(new Position(2, 3))).Returns(true);

            var isValid = moveCommand.Validate();

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Execute_ShouldChangePosition()
        {
            actorMock.SetupGet(a => a.IsPlaced).Returns(true);
            actorMock.SetupProperty(a => a.Direction, Direction.NORTH);
            actorMock.SetupProperty(a => a.Position, new Position(2, 2));
            actorMock.Setup(a => a.GetNextPosition()).Returns(new Position(2, 3));
            tableTopMock.SetupGet(t => t.Rows).Returns(5);
            tableTopMock.SetupGet(t => t.Columns).Returns(5);
            tableTopMock.Setup(t => t.IsPositionValid(new Position(2, 3))).Returns(true);

            moveCommand.Execute();

            Assert.AreEqual(new Position(2, 3), actorMock.Object.Position);
        }

        [TestMethod]
        public void Execute_ShouldNotChangePosition()
        {
            var initialPosition = new Position(4, 4);
            actorMock.SetupGet(a => a.IsPlaced).Returns(true);
            actorMock.SetupProperty(a => a.Direction, Direction.NORTH);
            actorMock.SetupProperty(a => a.Position, initialPosition);

            moveCommand.Execute();
            
            Assert.AreEqual(initialPosition, actorMock.Object.Position);
        }
    }
}