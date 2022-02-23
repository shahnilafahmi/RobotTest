using Shahnila.RobotMovement.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahnila.RobotMovement
{
   
    public class PositionTracker
    {
        Robot robot;
        Vector2 initialPosition;

        Queue<Vector2> moves = new Queue<Vector2>();

      
        public PositionTracker(Robot robot)
        {
            if (robot == null) throw new ArgumentNullException(nameof(robot));

            this.robot = robot;

            initialPosition = this.robot.Position;

            this.robot.Moved += OnRobotMoved;
        }

       
        public int CalculatePositionsVisited()
        {
            lock (moves)
            {
                if (moves.Count <= 0) return 1;

              
                Dictionary<int, bool> positionsVisitedCache = new Dictionary<int, bool>();

               
                int count = 0;

                // Start at the initial position and foreach move that was made,
                // check if each position along the move has been visited.
                Vector2 currentPosition = initialPosition;
                foreach (var move in moves)
                {
                    var lastPosition = currentPosition;
                    foreach (var position in PositionsAlongMove(currentPosition, move))
                    {
                       
                        bool visited = false;
                        positionsVisitedCache.TryGetValue(position.ToString().GetHashCode(), out visited);

                      
                        if (!visited)
                            count++;

                      
                        positionsVisitedCache[position.ToString().GetHashCode()] = true;

                      
                        lastPosition = position;
                    }
                 
                    currentPosition = lastPosition;
                }

                return count;
            }
        }

       
       public IEnumerable<Vector2> PositionsAlongMove(Vector2 currentPosition, Vector2 move)
        {
            if (move.X != 0 && move.Y != 0) throw new Exception("Must only move in one direction at a time.");

            if (move.X != 0)
            {
                if (move.X >= 0)
                {
                    for (int i = 0; i <= move.X; i++)
                        yield return new Vector2(currentPosition.X + i, currentPosition.Y);
                }
                else
                {
                    for (int i = 0; i >= move.X; i--)
                        yield return new Vector2(currentPosition.X + i, currentPosition.Y);
                }
            }
            else
            {
                if (move.Y >= 0)
                {
                    for (int i = 0; i <= move.Y; i++)
                        yield return new Vector2(currentPosition.X, currentPosition.Y + i);
                }
                else
                {
                    for (int i = 0; i >= move.Y; i--)
                        yield return new Vector2(currentPosition.X, currentPosition.Y + i);
                }
            }
        }

      
        void OnRobotMoved(object sender, RobotMovedEventArgs e)
        {
            lock (moves)
            {
                moves.Enqueue(e.MovementDirection);
            }
        }
    }
}
