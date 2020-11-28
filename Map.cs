using System;
using System.IO;

namespace MonsterGame
{
    class Map
    {
        private string[,] grid;
        public int cols;
        public int rows;
        public Map(string filePath) {
            //get level 
            string[] lines = File.ReadAllLines(filePath);
            rows = lines.Length;
            cols = lines[0].Length;
            grid = new string[rows, cols];

            for (int row=0; row < rows; row++) {
                string line = lines[row];
                for (int col=0; col < cols; col++) {
                    char currentChar = line[col];
                    grid[row,col] = currentChar.ToString();
                }
            }
        }

        public void Draw() {
            for (int row=0; row < rows; row++) {
                for (int col=0; col < cols; col++) {
                    Console.SetCursorPosition(col, row);
                    Console.Write(grid[row,col]);
                }
            }
        }
        public bool isPositionValid(int row, int col) {
            return grid[row,col] != "+" && grid[row,col] != "|" && grid[row,col] != "-";
        }
    }
}
