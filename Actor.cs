using System;
using System.IO;

namespace MonsterGame
{
    class Actor
    {
        public int row;
        public int col;
  
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

        public int Row {
            get {return row;} 
            set {
                Console.SetCursorPosition(col, row);
                Console.Write(" ");
                row = value;
            }
        }
        public int Col { 
            get {return col;}
            set {
                Console.SetCursorPosition(col, row);
                Console.Write(" ");
                col = value;
            }
        }

    }
}
