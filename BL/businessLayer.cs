using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class businessLayer
    {

        public bool register(String ID, String password, String name, String email)
        {
            //TODO: call register via communication layer
            return false;
        }

        public bool login(String ID, String password)
        {
            //TODO: call function via communication layer
            return false;
        }

        public User getUser(String ID)
        {
            //TODO: call function via communication layer
            return null;
        }

        public void logout(String ID)
        {
            //TODO: call function via communication layer
        }

        public bool editUserPassword(String userID, String newPassword)
        {
            //TODO: call function via communication layer
            return false;
        }

        public bool editUserName(String userID, String newName)
        {
            //TODO: call function via communication layer
            return false;
        }

        public bool editUserEmail(String userID, String newEmail)
        {
            //TODO: call function via communication layer
            return false;
        }

        public LinkedList<game> searchGames (int potSize)
        {
            //TODO: call function via communication layer
            return null;
        }

        public bool joinGame(String gameID, String UserID)
        {
            //TODO: call function via communication layer
            return false;
        }

        public game getGameByID(String gameID)
        {
            //TODO: call function via communication layer
            return new game();
        }

        public String createGame(String UserID, GameType type, int Limit, int buyIn, int chipPolicy, int minBet,
              int minPlayers, int maxPlayers, bool spectatable, bool leaguable)
        {
            //TODO: call function via communication layer
            return "";
        }

        public LinkedList<game> listOfJoinableGames(String UserID)
        {
            //TODO: call function via communication layer
            return null;
        }
        public LinkedList<game> listOfSpectatableGames()
        {
            //TODO: call function via communication layer
            return null;
        }

        public bool spectateGame(String UserID, String GameID)
        {
            //TODO: call function via communication layer
            return false;
        }

    }
}
