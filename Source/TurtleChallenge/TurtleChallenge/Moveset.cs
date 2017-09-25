using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge
{
    class Moveset
    {
        List<Action> _actions = new List<Action>();
        public List<Action> Actions { get { return _actions; } set { _actions = value; } }
    }
}
