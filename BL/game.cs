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
        public string GameID;
        public LinkedList<player> players;
        public LinkedList<player> activePlayers;
        public int activePlayersNumber;
        public int blindBit;
        public String CurrentPlayer;
        public int cardsOnTable;
        public card[] table;
        public int MaxPlayers;
        public int CurrentBet;
        public int cashOnTheTable = 0;
        
        
        
        

        /**

* PLAYERS = "*PLAYER USER NAME*,*Player Name*,"{0,n} 
*  CARDS = "*CARD NUMBER*,*CARD TYPE*,"{0,n}
*  GAME FULL DETAILS= "GameID=*ID*&players=*PLAYERS*&activePlayers=*PLAYERS*&blindBit=*NUMBER*&CurrentPlayer=*PLAYER USER NAME*&
* table=*CARDS*&MaxPlayers=*NUMBER*&cashOnTheTable=*NUMBER*&CurrentBet=*NUMBER*"
* @param request is string that has this format: "JOINGAME *GAME ID* *USER NAME*"
* @return "JOINGAME *GAME ID* *USER NAME* DONE *GAME FULL DETAILS*", "JOINGAME *GAME ID* *USER NAME* FAILED *MSG*"
*/

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
