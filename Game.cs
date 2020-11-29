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
            Gui.MapDimensions = (Map.Cols, Map.Rows);
            
            Console.Clear();
            Gui.Intro();
            RunGameLoop();

        }
        //so messy!
        private void InitialisePlayer() {
            Player = new Actor(1,1);
            Player.Color = ConsoleColor.Yellow;
            Player.Symbol = '1';
        }
        private void InitialiseMagicFlask() {
            (int randomRow, int randomCol) = Map.GetRandomPosition();
            MagicFlask = new Actor(randomRow, randomCol);
            MagicFlask.Color = ConsoleColor.Red; 
            MagicFlask.Symbol = 'X';
        }
        private void InitialiseMonster() {
            (int randomRow, int randomCol) = Map.GetRandomPosition();
            Monster = new Actor(randomRow, randomCol);
            Monster.Color = ConsoleColor.Red;
            Monster.Symbol = 'M';
        }

        private void HandleKeyPress() {
            ConsoleKey key;
            do {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;
            } while (Console.KeyAvailable);

            switch(key) {
                case ConsoleKey.UpArrow:
                    Map.MoveActor(Player, Player.Row - 1, Player.Col);
                    break;
                case ConsoleKey.DownArrow:
                    Map.MoveActor(Player, Player.Row + 1, Player.Col);
                    break;
                case ConsoleKey.LeftArrow:
                    Map.MoveActor(Player, Player.Row, Player.Col - 1);
                    break;
                case ConsoleKey.RightArrow:
                    Map.MoveActor(Player, Player.Row, Player.Col + 1);
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
            
            while (true) {
   
                //actors
                InitialisePlayer();
                InitialiseMagicFlask();
                InitialiseMonster();

                Map.Draw();
                Gui.PlayerLives(5);

                while (true) {
                    
                    DrawFrame();
                    HandleKeyPress();

                    //monster catches player - simplify too messy!
                    if (Player.Row == Monster.Row && Player.Col == Monster.Col) {
                        bool playAgain = Gui.GameOver();
                        if (playAgain) break;
                        else return;
                    };
                    //player reaches magic flask
                    if (Player.Row == MagicFlask.Row && Player.Col == MagicFlask.Col) {
                        bool playAgain = Gui.GameCompleted();
                        if (playAgain) break;
                        else return;
                    }

                    //ask question
                    

                    //give it a chance to render
                    System.Threading.Thread.Sleep(20);
                }
            }
        }

    }
}
