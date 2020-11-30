using System;
using System.IO;

namespace MonsterGame
{
    class Map
    {
        private Cell[,] grid;
        public int Cols;
        public int Rows;
        public Map(string filePath) {
            //get level from txt file
            string[] lines = File.ReadAllLines(filePath);
            Rows = lines.Length;
            Cols = lines[0].Length;
            grid = new Cell[Rows, Cols];

            for (int row=0; row < Rows; row++) {
                string line = lines[row];
                for (int col=0; col < Cols; col++) {
                    char currentChar = line[col];
                    grid[row,col] = new Cell(row,col, currentChar.ToString());
                }
            }
        }

        public void Draw() {
            for (int row=0; row < Rows; row++) {
                for (int col=0; col < Cols; col++) {
                     grid[row,col].Draw();
                }
            }
        }
        public bool isPositionValid(int row, int col) {
            // all wall/barrier values that actors can't go through.
            string[] walls = {"+", "|", "-"}; 
            if (Array.IndexOf(walls, grid[row,col].graphic) != -1) {
                return false;
            }else {
                return true;
            }
        }

        public (int, int) GetRandomPosition() {
            Random random = new Random();
            int randomRow;
            int randomCol;
            //maybe a bit inefficient
            do {
                randomRow = random.Next(Rows);
                randomCol = random.Next(Cols);
            }while (isPositionValid(randomRow, randomCol) != true);

            return (randomRow, randomCol);
        }

        public void MoveActor(Actor actor, int row, int col) {
            if (isPositionValid(row, col)) actor.Move(row,col);
        }

   
    }
}
