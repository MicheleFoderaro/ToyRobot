using ToyRobot.Commands.Interfaces;
using ToyRobot.Enums;
using ToyRobot.Models.Interfaces;

namespace ToyRobot.Commands.Implementations
{
    public class LeftCommand : ICommand, IValidator
    {
        private readonly IActor actor;
        public LeftCommand(IActor actor)
        {
            this.actor = actor;
        }

        public void Execute()
        {            
            if (Validate())
            {
                // Rotate the actor's direction to the left by adding 3 and taking the result modulo 4 
                actor.Direction = (Direction)(((int)actor.Direction! + 3) % 4);
            }
        }

        public bool Validate()
        {
            return actor.IsPlaced;
        }
    }
}
