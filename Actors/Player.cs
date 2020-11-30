using System;
using System.IO;

namespace MonsterGame
{
    class Player : Actor
    {
        public int Lives = 5;
        public Player() 
        {
            this.Color = ConsoleColor.DarkCyan;
            this.Symbol = '1';
            this.Row = 1;
            this.Col = 1;
        }      
    }
}