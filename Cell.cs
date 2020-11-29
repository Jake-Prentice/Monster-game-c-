using System;
using System.IO;

namespace MonsterGame
{
    class Cell
    {
        public int row;
        public int col;
        public int g;
        public int h;

        public string graphic;

        public Cell(int row, int col, string graphic) {
            this.row = row;
            this.col = col;
            this.graphic = graphic;
        }

        public void Draw() {
            Console.SetCursorPosition(col, row);
            Console.Write(graphic);
        }
    }
}
