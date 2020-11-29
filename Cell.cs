using System;
using System.IO;

namespace MonsterGame
{
    class Cell
    {
        public int row;
        public int col;
        public int g = 0;
        public int h = 0;
        public int f = 0;

        public string graphic; // what the cell looks like

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
