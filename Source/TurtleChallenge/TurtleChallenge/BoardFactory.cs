using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge
{
    class BoardFactory
    {
        public TileType[,] getBoard(GameSettings gameSettings)
        {
            TileType[,] board = new TileType[gameSettings.BoardSize.X, gameSettings.BoardSize.Y];
            for(int i=0;i<board.GetLength(0); i++)
            {
                for(int j=0;j<board.GetLength(1); j++)
                {
                    board[i, j] = TileType.Empty;
                    foreach (Point mine in gameSettings.Mines)
                    {
                        if(mine.X == i && mine.Y == j)
                        {
                            board[i, j] = TileType.Mine;
                            break;
                        }
                    }
                    if(gameSettings.Exit.X == i && gameSettings.Exit.Y == j)
                    {
                        board[i, j] = TileType.Exit;
                        break;
                    }                   
                }
            }
            return board;
        }
    }
}
