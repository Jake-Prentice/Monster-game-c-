using System;


namespace MonsterGame
{
    class Game
    {
        private Map Map;
        private Player Player;
        private Monster Monster;
        private MagicFlask MagicFlask;
        private Points Points;
        private int CurrentLevel = 1;

        public void Start() {
            string[] maps = {
                "cavern",
                "2"
            };
    
            Map = new Map($"./levels/{maps[0]}.txt"); 
            Gui.MapDimensions = (Map.Cols, Map.Rows);

            Console.Clear();
            Gui.Intro();
            RunGameLoop();
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

        //dont't like!
        private void InitialiseActors() { 
            Player = new Player();
            Monster = new Monster(Map);
            MagicFlask = new MagicFlask(Map);
            Points = new Points(Map, CurrentLevel);
        }
        
        private void DrawFrame() {
            Monster.Draw();
            MagicFlask.Draw();
            Points.Draw();
            Player.Draw();
            Console.CursorVisible = true; // cursor pointer is disabled throughout draw method
        }

        private void RunGameLoop() {
            while (true) {
                Map.Draw();
                InitialiseActors();
                Gui.DrawStats(Player.Lives, CurrentLevel);

                while (true) { //main loop
                    
                    DrawFrame();
                    HandleKeyPress();

                    // monster catches player - a bit messy?
                    if (Actor.DoesCollide(Player,Monster)) {
                        Gui.GameOver();
                        bool playAgain = Gui.PlayAgain();
                        if (playAgain) {
                            CurrentLevel = 1;
                            break;
                        }
                        else return;
                    }

                    //player reaches magic flask
                    if (Actor.DoesCollide(Player, MagicFlask)) { 
                        CurrentLevel += 1;
                        Gui.GameCompleted(CurrentLevel);
                        break; //reset 
                    }

                    //give it a chance to render
                    System.Threading.Thread.Sleep(20);
                }
            }
        }

    }
}
