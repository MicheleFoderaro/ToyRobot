using ToyRobot.Commands;
using ToyRobot.Enums;
using ToyRobot.Models;

namespace ToyRobot.Helpers.Parser
{
    public class InputParser : IInputParser
    {
        public InputCommand ParseCommand(string inputRequest)
        {
            // Create a new InputCommand object to hold the parsed input data
            InputCommand inputCommand = new();

            // Split the input string into an array of individual parameters
            var inputs = inputRequest.Split(' ');

            // Attempt to parse the first parameter as a valid Command enum
            if (!Enum.TryParse(inputs[0], true, out Command command))
            {
                throw new InvalidOperationException("Unrecognized command. " +
                    "Please try again using the following format: PLACE X,Y,Direction|MOVE|LEFT|RIGHT|REPORT");
            }

            inputCommand.Command = command;

            // If the command is "PLACE", attempt to parse the additional parameters
            if (command is Command.PLACE)
            {
                // Throw an exception if the input parameters are incomplete or invalid
                if (inputs.Length != 2)
                {
                    throw new ArgumentException("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,Direction");
                }

                // Split the second parameter into an array of X, Y, and direction values
                var commandParams = inputs[1].Split(',');
                if (commandParams.Length != 3)
                {
                    throw new ArgumentException("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,Direction");
                }

                if (!int.TryParse(commandParams[0], out var x) || !int.TryParse(commandParams[1], out var y))
                {
                    throw new ArgumentException("Invalid X or Y value. Please enter valid integer values for X and Y.");
                }

                if (!Enum.TryParse(commandParams[^1], true, out Direction direction))
                {
                    throw new ArgumentException("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST");
                }

                inputCommand.Position = new Position(x, y);
                inputCommand.Direction = direction;
            }

            return inputCommand;
        }
    }
}
