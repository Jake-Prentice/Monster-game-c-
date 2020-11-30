using System;
using System.IO;

namespace MonsterGame
{
    class MagicFlask : Actor
    {
        public MagicFlask(Map map) 
        {
            this.Symbol = 'X';
            this.Color = ConsoleColor.Magenta;
            (int randomRow, int randomCol) = map.GetRandomPosition();
            this.Row = randomRow;
            this.Col = randomCol;
        }
        
    }
}