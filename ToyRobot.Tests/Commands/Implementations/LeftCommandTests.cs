using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Models.Interfaces;
using ToyRobot.Enums;

namespace ToyRobot.Commands.Implementations.Tests
{
    [TestClass()]
    public class LeftCommandTests
    {
        private Mock<IActor> actorMock;
        private LeftCommand leftCommand;

        [TestInitialize]
        public void TestSetup()
        {
            actorMock = new Mock<IActor>();
            leftCommand = new LeftCommand(actorMock.Object);
        }

        [TestMethod]
        public void Validate_WhenActorIsNotPlaced_ShouldReturnFalse()
        {
            actorMock.SetupGet(a => a.IsPlaced).Returns(false);

            var isValid = leftCommand.Validate();
            
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Validate_WhenActorIsPlaced_ShouldReturnTrue()
        {
            actorMock.SetupGet(a => a.IsPlaced).Returns(true);

            var isValid = leftCommand.Validate();

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Execute_WhenActorIsNotPlaced_ShouldNotChangeActorDirection()
        {
            actorMock.SetupGet(a => a.IsPlaced).Returns(false);
            actorMock.SetupProperty(a => a.Direction, Direction.NORTH);

            leftCommand.Execute();

            Assert.AreEqual(Direction.NORTH, actorMock.Object.Direction);
        }

        [TestMethod]
        public void Execute_WhenActorIsPlaced_ShouldChangeActorDirection()
        {
            actorMock.SetupGet(a => a.IsPlaced).Returns(true);
            actorMock.SetupProperty(a => a.Direction, Direction.NORTH);

            leftCommand.Execute();

            Assert.AreEqual(Direction.WEST, actorMock.Object.Direction);
        }
    }
}