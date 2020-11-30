using System;
using System.IO;

namespace MonsterGame
{
    class Monster : Actor
    {
        public Monster(Map map) 
        {
            this.Symbol = 'M';
            this.Color = ConsoleColor.Red;
            (int randomRow, int randomCol) = map.GetRandomPosition();
            this.Row = randomRow;
            this.Col = randomCol;
        }
        
    }
}