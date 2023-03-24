using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Enums;
using ToyRobot.Models.Interfaces;

namespace ToyRobot.Commands.Implementations.Tests
{
    [TestClass()]
    public class RightCommandTests
    {
        private Mock<IActor> actorMock;
        private RightCommand rightCommand;

        [TestInitialize]
        public void TestSetup()
        {
            actorMock = new Mock<IActor>();
            rightCommand = new RightCommand(actorMock.Object);
        }

        [TestMethod]
        public void Validate_WhenActorIsNotPlaced_ShouldReturnFalse()
        {
            actorMock.SetupGet(a => a.IsPlaced).Returns(false);

            var isValid = rightCommand.Validate();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Validate_WhenActorIsPlaced_ShouldReturnTrue()
        {
            actorMock.SetupGet(a => a.IsPlaced).Returns(true);

            var isValid = rightCommand.Validate();

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Execute_WhenActorIsNotPlaced_ShouldNotChangeActorDirection()
        {
            actorMock.SetupGet(a => a.IsPlaced).Returns(false);
            actorMock.SetupProperty(a => a.Direction, Direction.NORTH);

            rightCommand.Execute();

            Assert.AreEqual(Direction.NORTH, actorMock.Object.Direction);
        }

        [TestMethod]
        public void Execute_WhenActorIsPlaced_ShouldChangeActorDirection()
        {
            actorMock.SetupGet(a => a.IsPlaced).Returns(true);
            actorMock.SetupProperty(a => a.Direction, Direction.NORTH);

            rightCommand.Execute();

            Assert.AreEqual(Direction.EAST, actorMock.Object.Direction);
        }
    }
}