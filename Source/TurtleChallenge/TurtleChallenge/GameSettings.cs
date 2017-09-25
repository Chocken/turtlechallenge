using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge
{
    class GameSettings
    {
        public Point BoardSize { get; set; }
        private List<Point> _mines = new List<Point>();
        public List<Point> Mines { get { return _mines; } set { _mines = value; } }
        public Point Exit { get; set; }
        public Point StartingPoint { get; set; }
        public Direction StartingDirection { get; set; }
    }
}
