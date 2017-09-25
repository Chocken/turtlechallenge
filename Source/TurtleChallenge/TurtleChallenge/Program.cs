using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SettingsFactory factory = new SettingsFactory();
                GameSettings settings = factory.ReadFile(args[0]);
                List<Moveset> moves = factory.GetMoves(args[1]);        

                TileType[,] board = new BoardFactory().getBoard(settings);
                printBoard(board);
                ActionProcessor actionProcessor = new ActionProcessor();
                foreach (Moveset moveset in moves)
                {
                    actionProcessor.ProcessActions(moveset.Actions, settings, board);
                    Console.WriteLine();
                }
            }
            catch(Exception e)
            {
                Console.Write(e);
            }           
        }

        public static void printBoard(TileType[,] board)
        {
            Console.WriteLine("Maze:");
            for (int j = 0; j < board.GetLength(1); j++)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {                    
                    switch(board[i,j])
                    {
                        case TileType.Empty:
                            Console.Write(" ");
                            break;
                        case TileType.Exit:
                            Console.Write("E");
                            break;
                        case TileType.Mine:
                            Console.Write("M");
                            break;
                    }
                    Console.Write(",");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
