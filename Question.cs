using System;
using System.IO;

namespace MonsterGame
{
    class Question : Actor
    {
        public Question(Actor actor)
            :base(actor.Row, actor.Col) 
        {
            
        }

        public static void AskAll() {

        }
        
    }
}