using System;


namespace MonsterGame
{
    class Game
    {
        private Map Map;
        private Actor Player;
        private Actor Monster;
        private Actor MagicFlask;
        public void Start() {
            string[] maps = {
                "cavern"
            };
    
            Map = new Map($"./levels/{maps[0]}.txt");
            //player
            Player = new Actor(1,1);
            Player.Color = ConsoleColor.Yellow;
            Player.Symbol = '1';
            //magic flask
            MagicFlask = new Actor(1,5);
            MagicFlask.Color = ConsoleColor.Red;
            MagicFlask.Symbol = 'X';
            //monster
            Random random = new Random();
            int randomRow = random.Next(Map.rows);
            int randomCol = random.Next(Map.cols);

            Monster = new Actor(randomRow, randomCol);
            Monster.Color = ConsoleColor.Red;
            Monster.Symbol = 'M';
            RunGameLoop();
        }

        private void DisplayIntro() {
            Console.WriteLine("some intro....");
            Console.ReadKey();
        }

        private void HandleKeyPress() {
            ConsoleKey key;
            do {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;
            } while (Console.KeyAvailable);
            //seems a bit ugly!
            switch(key) {
                case ConsoleKey.UpArrow:
                    if (Map.isPositionValid(Player.Row - 1, Player.Col)) Player.Row -= 1; 
                    break;
                case ConsoleKey.DownArrow:
                    if (Map.isPositionValid(Player.Row + 1, Player.Col)) Player.Row += 1;
                    break;
                case ConsoleKey.LeftArrow:
                    if (Map.isPositionValid(Player.Row, Player.Col - 1)) Player.Col -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    if (Map.isPositionValid(Player.Row, Player.Col + 1)) Player.Col += 1; 
                    break;
                default:
                    break;    

            }
        }
        
        private void DrawFrame() {
            Monster.Draw();
            MagicFlask.Draw();
            Player.Draw();
        }
        private void RunGameLoop() {
            Console.Clear();
            DisplayIntro();
            Map.Draw();

            while (true) {
                
                DrawFrame();
                HandleKeyPress();

                //monster catches player
                if (Player.row == Monster.row && Player.col == Monster.col) {
                    GameOver();
                    return;
                };

                //give it a chance to render
                System.Threading.Thread.Sleep(50);
            }
        }

        private void GameOver() {
            Console.Clear();
            System.Console.WriteLine("You died motherfucker!!");
      
        }


    }
}
