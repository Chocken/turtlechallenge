using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge
{
    class SettingsFactory
    {
        public GameSettings ReadFile(string settingsfile)
        {
            GameSettings gameSettings = new GameSettings();
            using (StreamReader reader = new StreamReader(settingsfile))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] currentLineSplit = line.Split(':');
                    if (currentLineSplit[0].ToLower() == "boardsize")
                    {
                        gameSettings.BoardSize = getPoint(currentLineSplit[1]);
                    }
                    if (currentLineSplit[0].ToLower() == "startingpoint")
                    {
                        gameSettings.StartingPoint = getPoint(currentLineSplit[1]);
                    }
                    if (currentLineSplit[0].ToLower() == "direction")
                    {
                        gameSettings.StartingDirection = getDirection(currentLineSplit[1]);
                    }
                    else if (currentLineSplit[0].ToLower() == "exit")
                    {
                        gameSettings.Exit = getPoint(currentLineSplit[1]);
                    }
                    else if (currentLineSplit[0].ToLower() == "mines")
                    {
                        string[] minePoints = currentLineSplit[1].Split('|');
                        foreach (string str in minePoints)
                        {
                            if (!string.IsNullOrEmpty(str))
                            {
                                gameSettings.Mines.Add(getPoint(str));
                            }
                        }
                    }
                }
            }
            return gameSettings;
        }

        public List<Moveset> GetMoves(string movesfile)
        {
            List<Moveset> moves = new List<Moveset>();
            using (StreamReader reader = new StreamReader(movesfile))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    List<Action> actions = new List<Action>();
                    string[] currentLineSplit = line.Split(',');
                    foreach (string str in currentLineSplit)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str == "m") { actions.Add(Action.Move); }
                            else if (str == "r") { actions.Add(Action.Rotate); }               
                        }
                    }
                    moves.Add(new Moveset {Actions = actions });
                }
            }
            return moves;
        }

        private Point getPoint(string pointStr)
        {
            string[] coords = pointStr.Split(',');
            return new Point(Convert.ToInt16(coords[0]), Convert.ToInt16(coords[1]));
        }

        private Direction getDirection(string str)
        {
            switch(str.ToLower())
            {
                case "up":
                    return Direction.Up;
                case "down":
                    return Direction.Down;                    
                case "left":
                    return Direction.Left;
                case "right":
                    return Direction.Right;
                default:
                    throw new Exception("no direction found");
            }
        }
    }
}
