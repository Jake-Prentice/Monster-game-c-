using System;
using System.IO;

namespace MonsterGame
{
    class Point : Actor
    {
        public Point(Map map) 
        {
            this.Symbol = '0';
            this.Color = ConsoleColor.Yellow;
            (int randomRow, int randomCol) = map.GetRandomPosition();
            this.Row = randomRow;
            this.Col = randomCol;
        }        
    }
}
