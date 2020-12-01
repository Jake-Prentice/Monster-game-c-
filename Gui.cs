using System;
using System.IO;

namespace MonsterGame
{
    static class Gui
    {
        public static (int width, int height) MapDimensions {get; set;}

        public static void DrawStats(int playerLives, int currentLevel, int pointsLeft) {
            Console.SetCursorPosition(MapDimensions.width + 3, 1);
            Console.WriteLine($"Player lives: {playerLives}");
            Console.SetCursorPosition(MapDimensions.width + 3, 3);
            Console.WriteLine($"Current level: {currentLevel}");
            Console.SetCursorPosition(MapDimensions.width + 3, 5);
            Console.WriteLine($"Points left: {pointsLeft}");

        }
        
        public static void Intro() {
            Console.WriteLine("press any key to start...");
            Console.ReadKey();
        }

        public static bool PlayAgain() {
            while (true) {
                Console.Write("Play again [y/n]: ");
                string answer = Console.ReadLine();
                if (answer == "y") return true;
                else if (answer == "n") return false;
                else Console.WriteLine("Not a valid input!");
            }
        }

        public static void GameOver() {
            Console.Clear();
            System.Console.WriteLine("Game Over!");
        }

        public static void LevelCompleted(int currentLevel) { 
            Console.Clear();
            Console.WriteLine("You won!");
            Console.WriteLine($"continue to level {currentLevel}...");
            Console.ReadKey();
        }
    }
}
