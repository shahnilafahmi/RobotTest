using Shahnila.RobotMovement.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shahnila.RobotMovement;

namespace Shahnila.RobotMovement.Applicaton
{
    class Program
    {
        static void Main(string[] args) 
        {
           
            int commandCount = int.Parse(Console.ReadLine());
            
           
            Vector2 startPosition = Vector2.PositionFromString(Console.ReadLine());

         
            Robot robot = new Robot(startPosition);
            PositionTracker tracker = new PositionTracker(robot);

            // Loop until we have read all commands.
            for (int i = 0; i < commandCount; i++)
            {
              
                var line = Console.ReadLine();
                Vector2 movement = Vector2.MoveDirectionFromString(line);

                // Move the robot.
                robot.Move(movement);
            }

          
            Console.WriteLine($"=> Cleaned: {tracker.CalculatePositionsVisited()}");
        }
    }
}
