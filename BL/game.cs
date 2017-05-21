using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public enum GameType
    {
        LIMIT, NO_LIMIT, POT_LIMIT
    }

    public class game
    {
        public LinkedList<player> players;
        public Queue<player> WantToJoinPlayers;
        public player CurrentPlayer;
        public Deck deck;
        public int num_of_want_to_join;
        public GamePreferences preferences;
        public int playersNumber;
        public int cashOnTheTable = 0;
        public int GameID;
        public int CurrentBet;
        public LinkedList<User> user_waches;
        public card[] table;
        public int cardsOnTable;
        public int blindBit;
        public LinkedList<player> folded = new LinkedList<player>();

        public game()
        {

        }
    }


    public class GamePreferences
    {
        public GameType gameTypePolicy;
        public int buyInPolicy;
        public int chipPolicy;
        public int minBet;
        public int minPlayersNum;
        public int maxPlayersNum;
        public bool spectatable;

        public GamePreferences() 
        {
        }
}
}
