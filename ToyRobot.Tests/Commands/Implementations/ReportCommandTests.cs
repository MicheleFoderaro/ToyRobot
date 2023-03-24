using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Enums;
using ToyRobot.Helpers.Output.Interfaces;
using ToyRobot.Models;
using ToyRobot.Models.Interfaces;

namespace ToyRobot.Commands.Implementations.Tests
{
    [TestClass()]
    public class ReportCommandTests
    {
        private Mock<IActor> actorMock;
        private Mock<IPrinter> printerMock;
        private ReportCommand reportCommand;

        [TestInitialize]
        public void TestSetup()
        {
            actorMock = new Mock<IActor>();
            printerMock = new Mock<IPrinter>();
            reportCommand = new ReportCommand(actorMock.Object, printerMock.Object);
        }

        [TestMethod]
        public void Validate_WhenActorIsNotPlaced_ShouldReturnFalse()
        {
            actorMock.SetupGet(a => a.IsPlaced).Returns(false);

            var isValid = reportCommand.Validate();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Validate_WhenActorIsPlaced_ShouldReturnTrue()
        {
            actorMock.SetupGet(a => a.IsPlaced).Returns(true);

            var isValid = reportCommand.Validate();

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Execute_ValidActorAndOutput_CorrectOutputWritten()
        {
            actorMock.Setup(a => a.IsPlaced).Returns(true);
            actorMock.Setup(a => a.Position).Returns(new Position(1, 2));
            actorMock.Setup(a => a.Direction).Returns(Direction.NORTH);

            reportCommand.Execute();

            printerMock.Verify(o => o.DisplayMessage("Output: 1,2,NORTH"), Times.Once);
        }
    }
}