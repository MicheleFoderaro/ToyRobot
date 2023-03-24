using ToyRobot.Commands.Interfaces;
using ToyRobot.Enums;
using ToyRobot.Models.Interfaces;

namespace ToyRobot.Commands.Implementations
{
    public class RightCommand : ICommand, IValidator
    {
        private readonly IActor actor;
        public RightCommand(IActor actor)
        {
            this.actor = actor;
        }

        public void Execute()
        {
            if (Validate())
            {
                // Rotate the actor's direction to the right by adding 1 and taking the result modulo 4 
                actor.Direction = (Direction)(((int)actor.Direction! + 1) % 4);
            }
        }

        public bool Validate()
        {
            return actor.IsPlaced;
        }
    }
}
