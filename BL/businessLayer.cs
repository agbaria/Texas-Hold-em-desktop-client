using System;
using System.Collections.Generic;
using System.Threading;

namespace BL
{
    public class businessLayer
    {
        private static businessLayer singelton = new businessLayer();
        public static businessLayer getBL() {
            return singelton;
        }
        communicationLayer CL;
        int isDone;
        User user;
        string recived;
        LinkedList<game> games;
        private businessLayer() {
            CL = new communicationLayer();
            isDone = 0;
            user = null;
            recived = "";
            games = new LinkedList<game>();
        }
        public void registered(string msg){
            if (msg.Contains("REG") && msg.Contains("DONE"))
                isDone = 1;
            else isDone = 2;
        }
        /**
 * 
 * @param request is string That has this format: "LOGIN *USER NAME* *PASSWORD*"
 * @return "LOGIN DONE *USER NAME* *NAME* *CASH* *SCORE* *LEAGUE*" if succeed to login, "LOGIN FAILED" else
 */
        public void loggedin(string msg)
        {
            if (msg.Contains("LOGIN") && msg.Contains("DONE"))
            {
                string [] parts =msg.Split(' ');
                Console.WriteLine(msg.ToString());
                user = new User(parts[2],parts[3],Int32.Parse(parts[4]), Int32.Parse(parts[5]), Int32.Parse(parts[6]));
                isDone = 1;
            }
                
            else isDone = 2;
        }
        /**
* 
* @param request is string that has this format: "EDITPASS *USER NAME* *NEWPASSWORD*"
* @return "EDITPASS DONE" if succeed to edit the user password, "EDITPASS FAILED *MSG*" else
*/
        public void edittedUserPassword(string msg)
        {
            if (msg.Contains("EDITPASS") && msg.Contains("DONE"))
            {   
                isDone = 1;
            }

            else isDone = 2;
        }


        public void edittedUserName(string msg)
        {
            if (msg.Contains("EDITUSERNAME") && msg.Contains("DONE"))
            {
                isDone = 1;
            }

            else isDone = 2;
        }


        public void edittedUserEmail(string msg)
        {
            if (msg.Contains("EDITUSEREMAIL") && msg.Contains("DONE"))
            {
                isDone = 1;
            }

            else isDone = 2;
        }

        /** 
 *  GAMES DETAILS = "*ONE GAME DETAILS*"{0,n} 
 *  ONE GAME DETAILS= "GAMEID=*GAME ID* ENDGAME"
 * @param request is string that has this format: "SEARCHGAMESBYPOTSIZE *POT SIZE*"
 * @return "SEARCHGAMESBYPOTSIZE DONE *GAMES DETAILS*", "SEARCHGAMESBYPOTSIZE FAILED"
  */
        public void searchedGamesByPotSize(string msg)
        {
            if (msg.Contains("DONE"))
            {
                this.recived = msg;
                isDone = 1;
            }

            else isDone = 2;
        }


        /** 
* PLAYERS = "*PLAYER USER NAME* "{0,n}
* CARDS = "*CARD NUMBER* *CARD TYPE* "{0,n}
* GAME FULL DETAILS= "GameID=*ID*&players=*PLAYERS*&activePlayers=*PLAYERS*&blindBit=*NUMBER*&CurrentPlayer=*PLAYER USER NAME*&
* table=*CARDS*&MaxPlayers=*NUMBER*&activePlayersNumber=*NUMBER*&cashOnTheTable=*NUMBER*&CurrentBet=*NUMBER*"
* @param request is string that has this format: "SPECTATEGAME *GAME ID* *USER NAME*"
* @return "SPECTATEGAME *GAME ID* *USER NAME* DONE *GAME FULL DETAILS*", "SPECTATEGAME FAILED *GAME ID* *USER NAME* *MSG*"
*/
        public void spectated(string msg)
        {
            if (msg.Contains("SPECTATEGAME") && msg.Contains("DONE"))
            {
                String part2 = msg.Substring(msg.IndexOf("DONE "));
                game newGame = new game();
                string players = extractString(part2, "players=");
                LinkedList<player> playerss = extractPlayers(players);
                players = extractString(part2, "activePlayers=");
                LinkedList<player> activePlayers = extractPlayers(players);
                card[] table = extractCards(extractString(part2, "table="));

                newGame.GameID = extractString(part2, "GameID=");
                newGame.players = playerss;
                newGame.activePlayers = activePlayers;
                newGame.blindBit = Int32.Parse(extractString(part2, "blindBit="));
                newGame.CurrentPlayer = extractString(part2, "CurrentPlayer=");
                newGame.table = table;
                newGame.MaxPlayers = Int32.Parse(extractString(part2, "MaxPlayers="));
                newGame.cashOnTheTable = Int32.Parse(extractString(part2, "cashOnTheTable="));
                newGame.CurrentBet = Int32.Parse(extractString(part2, "CurrentBet="));
                this.games.AddFirst(newGame);
                isDone = 1;
            }

            else isDone = 2;
        }

        /**

     * PLAYERS = "*PLAYER USER NAME*,*Player Name*,"{0,n} 
     *  CARDS = "*CARD NUMBER*,*CARD TYPE*,"{0,n}
     *  GAME FULL DETAILS= "GameID=*ID*&players=*PLAYERS*&activePlayers=*PLAYERS*&blindBit=*NUMBER*&CurrentPlayer=*PLAYER USER NAME*&
     * table=*CARDS*&MaxPlayers=*NUMBER*&cashOnTheTable=*NUMBER*&CurrentBet=*NUMBER*"
     * @param request is string that has this format: "JOINGAME *GAME ID* *USER NAME*"
     * @return "JOINGAME *GAME ID* *USER NAME* DONE *GAME FULL DETAILS*", "JOINGAME *GAME ID* *USER NAME* FAILED *MSG*"
     */
        public void joinedGame(string msg)
        {
            if (msg.Contains("JOINGAME") && msg.Contains("DONE"))
            {
                String part2 = msg.Substring(msg.IndexOf("DONE "));
                game newGame = new game();
                string players = extractString(part2, "players=");
                LinkedList<player> playerss = extractPlayers(players);
                players = extractString(part2, "activePlayers=");
                LinkedList<player> activePlayers = extractPlayers(players);
                card[] table = extractCards(extractString(part2, "table="));

                newGame.GameID = extractString(part2, "GameID=");
                newGame.players = playerss;
                newGame.activePlayers = activePlayers;
                newGame.blindBit = Int32.Parse(extractString(part2, "blindBit="));
                newGame.CurrentPlayer = extractString(part2, "CurrentPlayer=");
                newGame.table = table;
                newGame.MaxPlayers = Int32.Parse(extractString(part2, "MaxPlayers="));
                newGame.cashOnTheTable= Int32.Parse(extractString(part2, "cashOnTheTable="));
                newGame.CurrentBet = Int32.Parse(extractString(part2, "CurrentBet="));
                this.games.AddFirst(newGame);
                isDone = 1;
            }

            else isDone = 2;
        }

        /** 
* PLAYERS = "*PLAYER USER NAME* "{0,n}
* CARDS = "*CARD NUMBER* *CARD TYPE* "{0,n}
* GAME FULL DETAILS= "GameID=*ID*&players=*PLAYERS*&activePlayers=*PLAYERS*&blindBit=*NUMBER*&CurrentPlayer=*PLAYER USER NAME*&
* table=*CARDS*&MaxPlayers=*NUMBER*&activePlayersNumber=*NUMBER*&cashOnTheTable=*NUMBER*&CurrentBet=*NUMBER*"
* GAME PREF = gameTypePolicy=*GAME TYPE POLICY*&potLimit=*POT LIMIT*&buyInPolicy=*BUY IN POLICY*&chipPolicy=*CHIP POLICY*&minBet=*MIN BET*&minPlayersNum=*MIN PLAY NUM*&maxPlayersNum=*MAX PLAYER NUMBER*&spectatable=*T/F*&leaguable=*T/F*&league=*NUNBER*
* @param request is string that has this format: "CREATEGAME *USER NAME* *GAME PREF*"
* @return "CREATEGAME *USER NAME* DONE *GAME FULL DETAILS*", "CREATEGAME FAILED" else
*/
        public void createdGame(string msg)
        {
            if (msg.Contains("CREATEGAME") && msg.Contains("DONE"))
            {
                String part2 = msg.Substring(msg.IndexOf("DONE "));
                game newGame = new game();
                string players = extractString(part2, "players=");
                LinkedList<player> playerss = extractPlayers(players);
                players = extractString(part2, "activePlayers=");
                LinkedList<player> activePlayers = extractPlayers(players);
                card[] table = extractCards(extractString(part2, "table="));

                newGame.GameID = extractString(part2, "GameID=");
                newGame.players = playerss;
                newGame.activePlayers = activePlayers;
                newGame.blindBit = Int32.Parse(extractString(part2, "blindBit="));
                newGame.CurrentPlayer = extractString(part2, "CurrentPlayer=");
                newGame.table = table;
                newGame.MaxPlayers = Int32.Parse(extractString(part2, "MaxPlayers="));
                newGame.cashOnTheTable = Int32.Parse(extractString(part2, "cashOnTheTable="));
                newGame.CurrentBet = Int32.Parse(extractString(part2, "CurrentBet="));
                this.games.AddFirst(newGame);
                this.recived = newGame.GameID;
                isDone = 1;
            }

            else isDone = 2;
        }


        private LinkedList<player> extractPlayers(string players)
        {
            int i = 0;
            string name;
            string ID;
            LinkedList<player> result = new LinkedList<player>();
            while (i < players.Length-1) {

                ID = players.Substring(i,players.IndexOf(",",i) - i);
                i = players.IndexOf(",", i)+1;
                name = players.Substring(i, players.IndexOf(",", i) - i);
                i = players.IndexOf(",", i) + 1;
                player p = new player();
                p.user = new User(ID,name);
                result.AddLast(p);
            }
            return result;
        }

        private card[] extractCards(string cards)
        {
            int i = 0;
            string cardType;
            string CardNumber;
            List<card> result = new List<card>();
            while (i < cards.Length - 1)
            {

                CardNumber = cards.Substring(i, cards.IndexOf(",", i) - i);
                i = cards.IndexOf(",", i) + 1;
                cardType = cards.Substring(i, cards.IndexOf(",", i) - i);
                i = cards.IndexOf(",", i) + 1;
                card p = new card();
                p.number = Int32.Parse(CardNumber);
                //SPADES, HEARTS, DIAMONDS, CLUBS
                if (cardType.Equals("SPADES"))
                {
                    p.type = CardType.SPADES;
                }
                if (cardType.Equals("HEARTS"))
                {
                    p.type = CardType.HEARTS;
                }
                if (cardType.Equals("DIAMONDS"))
                {
                    p.type = CardType.DIAMONDS;
                }
                if (cardType.Equals("CLUBS"))
                {
                    p.type = CardType.CLUBS;
                }
                result.Add(p);
            }
            return result.ToArray();
        }

        private string extractString(string input,string splitter) {
            int beginning = input.IndexOf(splitter) + splitter.Length;
            int end = input.IndexOf("&", beginning) == -1 ? input.Length-1:input.IndexOf("&", beginning);
            return input.Substring(beginning, end);

        }

        /**
 * 	
 * @param request is string That has this format: "REG *USER NAME* *PASSWORD* *NAME* *EMAIL*"
 * @return "REG DONE" if the registration done, "REG FAILED" else
 */
        public bool register(String ID, String password, String name, String email)
        {

            isDone = 0;
            if (CL.send("REG " + ID + " " + password + " " + name + " " + email+"\n"))
            {
                while (isDone == 0) ;
                if (isDone == 1) return true;
                return false;
            }
            return false;
        }
        /**
         * 
         * @param request is string That has this format: "LOGIN *USER NAME* *PASSWORD*"
         * @return "LOGIN DONE *USER NAME* *NAME* *CASH* *SCORE* *LEAGUE*" if succeed to login, "LOGIN FAILED" else
         */
        public bool login(String ID, String password)
        {
            isDone = 0;
            if (CL.send("LOGIN " + ID + " " + password +"\n"))
            {
                while (isDone == 0) ;
                if (isDone == 1) return true;
                return false;
            }
            return false;
        }

        public User getUser(String ID)
        {
            return this.user;
        }
        /**
 * 
 * @param id is string that has this format: "LOGOUT *USER NAME*"
 * @return "LOGOUT DONE" if succeed to logout, "LOGOUT FAILED *MSG*" else
 */
        public void logout(String ID)
        {
            isDone = 0;
            if (!CL.send("LOGOUT " + ID + "\n"))
            {
                logout(ID);
            }
            this.user = null;
        }
        /**
 * 
 * @param request is string that has this format: "EDITPASS *USER NAME* *NEWPASSWORD*"
 * @return "EDITPASS DONE" if succeed to edit the user password, "EDITPASS FAILED *MSG*" else
 */
        public bool editUserPassword(String userID, String newPassword)
        {
            isDone = 0;
            if (CL.send("EDITPASS " + userID + " " + newPassword + "\n"))
            {
                while (isDone == 0) ;
                if (isDone == 1) return true;
                return false;
            }
            return false;
        }





        public bool editUserName(String userID, String newName)
        {
            //TODO: call function via communication layer
            isDone = 0;
            if (CL.send("EDITUSERNAME " + userID + " " + newName + "\n"))
            {
                while (isDone == 0) ;
                if (isDone == 1) return true;
                return false;
            }
            return false;
        }

        public bool editUserEmail(String userID, String newEmail)
        {
            //TODO: call function via communication layer
            isDone = 0;
            if (CL.send("EDITUSEREMAIL " + userID + " " + newEmail + "\n"))
            {
                while (isDone == 0) ;
                if (isDone == 1) return true;
                return false;
            }
            return false;
        }
        /** 
         *  GAMES DETAILS = "*ONE GAME DETAILS*"{0,n} 
         *  ONE GAME DETAILS= "GAMEID=*GAME ID* ENDGAME"
         * @param request is string that has this format: "SEARCHGAMESBYPOTSIZE *POT SIZE*"
         * @return "SEARCHGAMESBYPOTSIZE DONE *GAMES DETAILS*", "SEARCHGAMESBYPOTSIZE FAILED"
          */
        public LinkedList<string> searchGamesByPotSize(int potSize)
        {
            isDone = 0;
            if (CL.send("SEARCHGAMESBYPOTSIZE " + potSize +"\n"))
            {
                while (isDone == 0) ;
                if (isDone == 1) {
                    LinkedList<string> result = new LinkedList<string>();
                    
                        String part2 = recived.Substring(recived.IndexOf("GAMEID="));
                    if (!part2.StartsWith("GAMEID=")) return null;
                    int i = 0;
                    while (i < part2.Length-1) {
                        i = part2.IndexOf("GAMEID=") + "GAMEID=".Length;
                        result.AddFirst(part2.Substring(i,part2.IndexOf(" ENDGAME ",i)-i));
                        i = part2.IndexOf(" ENDGAME ", i);
                    }
                   
                    this.recived = "";
                    return result;
                }
                this.recived = "";
                return null;
            }
            this.recived = "";
            return null;
        }

        /**

     * PLAYERS = "*PLAYER USER NAME*,*Player Name*,"{0,n} 
     *  CARDS = "*CARD NUMBER*,*CARD TYPE*,"{0,n}
     *  GAME FULL DETAILS= "GameID=*ID*&players=*PLAYERS*&activePlayers=*PLAYERS*&blindBit=*NUMBER*&CurrentPlayer=*PLAYER USER NAME*&
     * table=*CARDS*&MaxPlayers=*NUMBER*&cashOnTheTable=*NUMBER*&CurrentBet=*NUMBER*"
     * @param request is string that has this format: "JOINGAME *GAME ID* *USER NAME*"
     * @return "JOINGAME *GAME ID* *USER NAME* DONE *GAME FULL DETAILS*", "JOINGAME *GAME ID* *USER NAME* FAILED *MSG*"
     */
        public bool joinGame(String gameID, String UserID)
        {
            //TODO: call function via communication layer
            isDone = 0;
            if (CL.send("JOINGAME " + gameID + " " + UserID + "\n"))
            {
                while (isDone == 0);
                if (isDone == 1) return true;
                return false;
            }
            return false;
        }

        public game getGameByID(String gameID)
        {
            foreach(game currentGame in games){
                if (currentGame.GameID.Equals(gameID))
                    return currentGame;
            }
            return null;
        }

        /** 
     * PLAYERS = "*PLAYER USER NAME* "{0,n}
     * CARDS = "*CARD NUMBER* *CARD TYPE* "{0,n}
     * GAME FULL DETAILS= "GameID=*ID*&players=*PLAYERS*&activePlayers=*PLAYERS*&blindBit=*NUMBER*&CurrentPlayer=*PLAYER USER NAME*&
     * table=*CARDS*&MaxPlayers=*NUMBER*&activePlayersNumber=*NUMBER*&cashOnTheTable=*NUMBER*&CurrentBet=*NUMBER*"
     * GAME PREF = gameTypePolicy=*GAME TYPE POLICY*&potLimit=*POT LIMIT*&buyInPolicy=*BUY IN POLICY*&chipPolicy=*CHIP POLICY*&minBet=*MIN BET*&minPlayersNum=*MIN PLAY NUM*&maxPlayersNum=*MAX PLAYER NUMBER*&spectatable=*T/F*&leaguable=*T/F*&league=*NUNBER*
     * @param request is string that has this format: "CREATEGAME *USER NAME* *GAME PREF*"
     * @return "CREATEGAME *USER NAME* *GAME FULL DETAILS*", "CREATEGAME FAILED" else
 */

        public String createGame(String UserID, GameType type, int Limit, int buyIn, int chipPolicy, int minBet,
              int minPlayers, int maxPlayers, bool spectatable, bool leaguable,int league)
        {
            string result = null; 
            isDone = 0;
            string spect = "";
            string leagu = "";
            if (spectatable) spect = "T";
            else spect = "F";
            if (leaguable) leagu = "T";
            else leagu = "F";
            if (CL.send("CREATEGAME " + UserID + " gameTypePolicy=" + type + "&potLimit=" + Limit + "&buyInPolicy=" +buyIn+
                "&chipPolicy="+ chipPolicy + "&minBet="+ minBet + "&minPlayersNum="+ minPlayers + "&maxPlayersNum="+ maxPlayers + "&spectatable="+spect+ "&leaguable="+leagu+ "&league="+ league + "\n"))
            {
                while (isDone == 0) ;
                if (isDone == 1) {
                    result = recived;
                    this.recived = "";
                    return result; }
                this.recived = "";
                return null;
            }
            this.recived = "";
            return null;
        }

        /** 
 *  GAMES DETAILS = "*ONE GAME DETAILS*"{0,n} 
 *  ONE GAME DETAILS= "GAMEID=*GAME ID* ENDGAME "
 * @param request is string that has this format: "LISTJOINABLEGAMES *USER NAME*"
 * @return "LISTJOINABLEGAMES DONE *GAMES DETAILS*", "LISTJOINABLEGAMES FAILED"
 */
        public LinkedList<string> listOfJoinableGames(String UserID)
        {
            isDone = 0;
            if (CL.send("LISTJOINABLEGAMES " + UserID + "\n"))
            {
                while (isDone == 0) ;
                if (isDone == 1)
                {
                    LinkedList<string> result = new LinkedList<string>();

                    String part2 = recived.Substring(recived.IndexOf("GAMEID="));
                    if (!part2.StartsWith("GAMEID=")) return null;
                    int i = 0;
                    while (i < part2.Length - 1)
                    {
                        i = part2.IndexOf("GAMEID=") + "GAMEID=".Length;
                        result.AddFirst(part2.Substring(i, part2.IndexOf(" ENDGAME ", i) - i));
                        i = part2.IndexOf(" ENDGAME ", i);
                    }

                    this.recived = "";
                    return result;
                }
                this.recived = "";
                return null;
            }
            this.recived = "";
            return null;
        }

        /** 
 *  GAMES DETAILS = "*ONE GAME DETAILS*"{0,n} 
 *  ONE GAME DETAILS= "GAMEID=*GAME ID* ENDGAME "
 * @param request is string that has this format: "LISTSPECTATEABLEGAMES"
 * @return "LISTSPECTATEABLEGAMES DONE *GAMES DETAILS*", "LISTSPECTATEABLEGAMES FAILED" 
 */
        public LinkedList<string> listOfSpectatableGames()
        {
            isDone = 0;
            if (CL.send("LISTSPECTATEABLEGAMES\n"))
            {
                while (isDone == 0) ;
                if (isDone == 1)
                {
                    LinkedList<string> result = new LinkedList<string>();

                    String part2 = recived.Substring(recived.IndexOf("GAMEID="));
                    if (!part2.StartsWith("GAMEID=")) return null;
                    int i = 0;
                    while (i < part2.Length - 1)
                    {
                        i = part2.IndexOf("GAMEID=") + "GAMEID=".Length;
                        result.AddFirst(part2.Substring(i, part2.IndexOf(" ENDGAME ", i) - i));
                        i = part2.IndexOf(" ENDGAME ", i);
                    }

                    this.recived = "";
                    return result;
                }
                this.recived = "";
                return null;
            }
            this.recived = "";
            return null;
        }

        /** 
 * PLAYERS = "*PLAYER USER NAME* "{0,n}
 * CARDS = "*CARD NUMBER* *CARD TYPE* "{0,n}
 * GAME FULL DETAILS= "GameID=*ID*&players=*PLAYERS*&activePlayers=*PLAYERS*&blindBit=*NUMBER*&CurrentPlayer=*PLAYER USER NAME*&
 * table=*CARDS*&MaxPlayers=*NUMBER*&activePlayersNumber=*NUMBER*&cashOnTheTable=*NUMBER*&CurrentBet=*NUMBER*"
 * @param request is string that has this format: "SPECTATEGAME *GAME ID* *USER NAME*"
 * @return "SPECTATEGAME *GAME ID* *USER NAME* DONE *GAME FULL DETAILS*", "SPECTATEGAME FAILED *GAME ID* *USER NAME* *MSG*"
 */
        public bool spectateGame(String UserID, String GameID)
        {
            isDone = 0;
            if (CL.send("SPECTATEGAME " + GameID + " " + UserID + "\n"))
            {
                while (isDone == 0) ;
                if (isDone == 1) return true;
                return false;
            }
            return false;
        }

    }
}
