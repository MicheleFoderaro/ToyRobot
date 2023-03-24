using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Helpers
{
    public static class Helpers
    {
        public static string GetWelcomeMessage()
        {
            return 
            @$"
            Toy Robot Simulator ({Assembly.GetEntryAssembly()?.GetName().Version})
            Simulate executing commands on a Toy Robot on a 5 x 5 Table Top.
            Commands:
                PLACE X,Y,Direction     Place the robot on X Y with direction NORTH, EAST, SOUTH or WEST.
                MOVE                    Move the robot one unit forward.
                LEFT                    Rotate the robot 90 degrees clockwise.
                RIGHT                   Rotate the robot 90 degrees anti-clockwise.
                REPORT                  Print X, Y and direction of the toy robot.
                QUIT                    Quit the application.
            ";
        }
    }
}
