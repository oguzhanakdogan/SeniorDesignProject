using System;

namespace DefaultNamespace.DatabaseManagement
{
    [Serializable]
    public class User
    {

        public string UserName;
        public int userScore;
        public User()
        {
           UserName =  MyPlayerDataScriptinin.playerName;
           userScore = MyPlayerDataScriptinin.playerScore;
        }
    }
}