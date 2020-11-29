using System;
using System.IO;

namespace MonsterGame
{
    class Actor
    {
        public int Row {get; set;}
        public int Col {get; set;}
        public char Symbol {get; set;}
        public ConsoleColor Color {get; set;}
        
        public Actor(int row, int col) {
            Row = row;
            Col = col;
        }

        public void Draw() {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(Col, Row);
            Console.Write(Symbol);         
            Console.ResetColor();
        }

        public void Move(int newRow, int newCol) {
            Console.SetCursorPosition(Col, Row); 
            Console.Write(" "); //get rid of current position
            Row = newRow;
            Col = newCol;
            
        }

    }
}
