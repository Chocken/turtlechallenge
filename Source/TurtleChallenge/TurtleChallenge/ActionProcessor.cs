using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge
{
    class ActionProcessor
    {
        public void ProcessActions(List<Action> actions, GameSettings settings, TileType[,] board)
        {
            bool stillAliveAndInMaze = true;
            Point currentLocation = new Point(settings.StartingPoint.X,settings.StartingPoint.Y);
            Direction currentDirection = settings.StartingDirection;

            foreach (Action action in actions)
            {
                if (action == Action.Move)
                {
                    Console.Write("turtle moving from " + +currentLocation.X + " " + currentLocation.Y);
                    switch (currentDirection)
                    {
                        case Direction.Up:
                            if (currentLocation.Y > 0) { currentLocation.Y--; }
                            break;
                        case Direction.Down:
                            if (currentLocation.Y < settings.BoardSize.Y - 1) { currentLocation.Y++; }
                            break;
                        case Direction.Left:
                            if (currentLocation.X > 0) { currentLocation.X--; }
                            break;
                        case Direction.Right:
                            if (currentLocation.X < settings.BoardSize.X - 1) { currentLocation.X++; }
                            break;
                    }
                    Console.WriteLine(" to: " + currentLocation.X + " " + currentLocation.Y);
                    if (board[currentLocation.X, currentLocation.Y] == TileType.Mine)
                    {
                        Console.WriteLine("you killed the turtle, you monster");
                        stillAliveAndInMaze = false;
                        break;
                    }
                    else if (board[currentLocation.X, currentLocation.Y] == TileType.Exit)
                    {
                        Console.WriteLine("the turtle has escaped!");
                        stillAliveAndInMaze = false;
                        break;
                    }
                }
                else if (action == Action.Rotate)
                {
                    Console.Write("changing direction from " + currentDirection);
                    int newdirection = ((int)currentDirection + 1) % 4;
                    currentDirection = (Direction)newdirection;
                    Console.WriteLine(" to " + currentDirection);
                }
            }

            if(stillAliveAndInMaze)
            {
                Console.WriteLine("turtle is still in danger!");
            }
        }
    }
}
