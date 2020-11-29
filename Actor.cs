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
        
        public Actor(int row=1, int col=1, ConsoleColor color=ConsoleColor.White, char symbol=' ') {
            Row = row;
            Col = col;
            Color = color;
            Symbol = symbol;
        }

        public Actor() {}

        public void Draw() {
            Console.CursorVisible = false;
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
