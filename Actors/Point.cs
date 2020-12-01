using System;
using System.IO;

namespace MonsterGame
{
    class Point : Actor
    {
        public string Question;
        public string[] Choices;  
        public int AnswerIndex;

        public Point(Map map) 
        {
            this.Symbol = '0';
            this.Color = ConsoleColor.Yellow;
            (int randomRow, int randomCol) = map.GetRandomPosition();
            this.Row = randomRow;
            this.Col = randomCol;
        }  

        public bool AskQuestion() {
            return true;
        }      
    }
}
