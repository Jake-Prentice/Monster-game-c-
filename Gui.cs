using System;
using System.IO;

namespace MonsterGame
{
    static class Gui
    {
        public static (int width, int height) MapDimensions {get; set;}

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

        public static bool GameOver() {
            Console.Clear();
            System.Console.WriteLine("Game Over!");
            return PlayAgain();
        }

        public static bool GameCompleted() { 
            Console.Clear();
            Console.WriteLine("You won!");
            return PlayAgain();
        }

        public static void PlayerLives(int playerLives) {
            Console.SetCursorPosition(MapDimensions.width + 3, 1);
            Console.WriteLine($"Player lives: {playerLives}");
        }

    }
}
