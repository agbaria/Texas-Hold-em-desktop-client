using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BL;
using System.Threading;

namespace GUI
{
    /// <summary>
    /// Interaction logic for game.xaml
    /// </summary>
    public partial class game : Window
    {
        businessLayer BL;
        BL.game Game;
        User user;
        Thread newThread;

        BitmapImage[] cards = new BitmapImage[52];
        BitmapImage[] avatars = new BitmapImage[4];
        Border[] playerAvatar = new Border[8];
        Label[] playerName = new Label[8];
        Label[] playerCash = new Label[8];

        public game(businessLayer bl, BL.game Game, User user)
        {
            InitializeComponent();
            this.BL = bl;
            this.Game = Game;
            this.user = user;

            InitializeAvatrsImages();
            InitializeCardsImages();
            InitializePlayersComponents();

              newThread = new Thread(new ThreadStart(Run));
              newThread.Start(); 
        }

        private void Run()
        {
            while(Game.activePlayers.Count > 0)
            {
                updateGame();
                if (this.Game.CurrentPlayer==this.user.ID)
                {
                    myTurn();
                    newThread.Abort();
                }
            }
        }

        private void InitializeAvatrsImages()
        {
            for (int i = 0; i < 4; i++)
            {
                if(i==1)
                avatars[1] = new BitmapImage(new Uri("avatar" + (i + 1) + ".png", UriKind.Relative));
                else
                avatars[i] = new BitmapImage(new Uri("avatar"+(i+1)+".jpg", UriKind.Relative));
            }
        }

        private void InitializePlayersComponents()
        {
            playerAvatar[0] = player1_avatar;
            playerAvatar[1] = player2_avatar;
            playerAvatar[2] = player3_avatar;
            playerAvatar[3] = player4_avatar;
            playerAvatar[4] = player5_avatar;
            playerAvatar[5] = player6_avatar;
            playerAvatar[6] = player7_avatar;
            playerAvatar[7] = player8_avatar;

            playerName[0] = player1_name;
            playerName[1] = player2_name;
            playerName[2] = player3_name;
            playerName[3] = player4_name;
            playerName[4] = player5_name;
            playerName[5] = player6_name;
            playerName[6] = player7_name;
            playerName[7] = player8_name;

            playerCash[0] = player1_cash;
            playerCash[1] = player2_cash;
            playerCash[2] = player3_cash;
            playerCash[3] = player4_cash;
            playerCash[4] = player5_cash;
            playerCash[5] = player6_cash;
            playerCash[6] = player7_cash;
            playerCash[7] = player8_cash;
        }

        private void InitializeCardsImages()
        {
            String[] royalFamily = { "jack", "queen", "king"};

            cards[0] = new BitmapImage(new Uri("ace_of_clubs.png", UriKind.Relative));
            cards[13] = new BitmapImage(new Uri("ace_of_diamonds.png", UriKind.Relative));
            cards[26] = new BitmapImage(new Uri("ace_of_hearts.png", UriKind.Relative));
            cards[39] = new BitmapImage(new Uri("ace_of_spades.png", UriKind.Relative));

            for (int i = 1; i < 10; i++)
            {
                cards[i] = new BitmapImage(new Uri((i + 1) + "_of_clubs.png", UriKind.Relative));
                cards[i + 13] = new BitmapImage(new Uri((i + 1) + "_of_diamonds.png", UriKind.Relative));
                cards[i + 26] = new BitmapImage(new Uri((i + 1) + "_of_hearts.png", UriKind.Relative));
                cards[i + 39] = new BitmapImage(new Uri((i + 1) + "_of_spades.png", UriKind.Relative));
            }

            for (int i = 10; i < 13; i++)
            {
                cards[i] = new BitmapImage(new Uri(royalFamily[i - 10] + "_of_clubs.png", UriKind.Relative));
                cards[i + 13] = new BitmapImage(new Uri(royalFamily[i - 10] + "_of_diamonds.png", UriKind.Relative));
                cards[i + 26] = new BitmapImage(new Uri(royalFamily[i - 10] + "_of_hearts.png", UriKind.Relative));
                cards[i + 39] = new BitmapImage(new Uri(royalFamily[i - 10] + "_of_spades.png", UriKind.Relative));
            }
        }

        private void updateTableCards()
        {
            int numOfCards = Game.cardsOnTable;
            int[] cardIndex=new int[numOfCards];

            for(int i=0; i<numOfCards; i++)
            {
               if(Game.table[i].type.Equals(CardType.CLUBS))
                   cardIndex[i] = Game.table[i].number - 1;
               if (Game.table[i].type.Equals(CardType.DIAMONDS))
                   cardIndex[i] = Game.table[i].number - 1 + 13;
               if (Game.table[i].type.Equals(CardType.HEARTS))
                   cardIndex[i] = Game.table[i].number - 1 + 26;
               if (Game.table[i].type.Equals(CardType.SPADES))
                   cardIndex[i] = Game.table[i].number - 1 + 39;
            }

            if (numOfCards>0)
            {
                    if (numOfCards==1)
                {
                    card1.Background = new ImageBrush(cards[cardIndex[0]]);
                    card2.Background = new ImageBrush();
                    card3.Background = new ImageBrush();
                    card4.Background = new ImageBrush();
                    card5.Background = new ImageBrush();
                }
                if (numOfCards == 2)
                {
                    card1.Background = new ImageBrush(cards[cardIndex[0]]);
                    card2.Background = new ImageBrush(cards[cardIndex[1]]);
                    card3.Background = new ImageBrush();
                    card4.Background = new ImageBrush();
                    card5.Background = new ImageBrush();
                }
                if (numOfCards == 3)
                {
                    card1.Background = new ImageBrush(cards[cardIndex[0]]);
                    card2.Background = new ImageBrush(cards[cardIndex[1]]);
                    card3.Background = new ImageBrush(cards[cardIndex[2]]);
                    card4.Background = new ImageBrush();
                    card5.Background = new ImageBrush();
                }
                if (numOfCards == 4)
                {
                    card1.Background = new ImageBrush(cards[cardIndex[0]]);
                    card2.Background = new ImageBrush(cards[cardIndex[1]]);
                    card3.Background = new ImageBrush(cards[cardIndex[2]]);
                    card4.Background = new ImageBrush(cards[cardIndex[3]]);
                    card5.Background = new ImageBrush();
                }
                if (numOfCards == 5)
                {
                    card1.Background = new ImageBrush(cards[cardIndex[0]]);
                    card2.Background = new ImageBrush(cards[cardIndex[1]]);
                    card3.Background = new ImageBrush(cards[cardIndex[2]]);
                    card4.Background = new ImageBrush(cards[cardIndex[3]]);
                    card5.Background = new ImageBrush(cards[cardIndex[4]]);
                }
            }
        }

        private void updateMyCards(player myPlayer)
        {
            int[] cardIndex = new int[2];

            if (myPlayer.hand[0] != null && myPlayer.hand[1] != null)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (myPlayer.hand[i].type.Equals(CardType.CLUBS))
                        cardIndex[i] = myPlayer.hand[i].number - 1;
                    if (myPlayer.hand[i].type.Equals(CardType.DIAMONDS))
                        cardIndex[i] = myPlayer.hand[i].number - 1 + 13;
                    if (myPlayer.hand[i].type.Equals(CardType.HEARTS))
                        cardIndex[i] = myPlayer.hand[i].number - 1 + 26;
                    if (myPlayer.hand[i].type.Equals(CardType.SPADES))
                        cardIndex[i] = myPlayer.hand[i].number - 1 + 39;
                }
                my_first_card.Background = new ImageBrush(cards[cardIndex[0]]);
                my_second_card.Background = new ImageBrush(cards[cardIndex[1]]);
            }
        }


        public void updatePlayers()
        {
            player1_name.Visibility = System.Windows.Visibility.Hidden;
            player1_cash.Visibility = System.Windows.Visibility.Hidden;
            player2_name.Visibility = System.Windows.Visibility.Hidden;
            player2_cash.Visibility = System.Windows.Visibility.Hidden;
            player3_name.Visibility = System.Windows.Visibility.Hidden;
            player3_cash.Visibility = System.Windows.Visibility.Hidden;
            player4_name.Visibility = System.Windows.Visibility.Hidden;
            player4_cash.Visibility = System.Windows.Visibility.Hidden;
            player5_name.Visibility = System.Windows.Visibility.Hidden;
            player5_cash.Visibility = System.Windows.Visibility.Hidden;
            player6_name.Visibility = System.Windows.Visibility.Hidden;
            player6_cash.Visibility = System.Windows.Visibility.Hidden;
            player7_name.Visibility = System.Windows.Visibility.Hidden;
            player7_cash.Visibility = System.Windows.Visibility.Hidden;
            player8_name.Visibility = System.Windows.Visibility.Hidden;
            player8_cash.Visibility = System.Windows.Visibility.Hidden;

            int numOfPlayers = Game.activePlayers.Count;
  
            for (int i = 0; i < 8; i++)
                playerAvatar[i].Background = new ImageBrush();

            for (int i = 0; i < numOfPlayers; i++)
            {
               if(Game.activePlayers.ElementAt(i).user.avatar.Equals("avatar1"))
                playerAvatar[i].Background = new ImageBrush(avatars[0]);
               if (Game.activePlayers.ElementAt(i).user.avatar.Equals("avatar2"))
                playerAvatar[i].Background = new ImageBrush(avatars[1]);
               if (Game.activePlayers.ElementAt(i).user.avatar.Equals("avatar3"))
                playerAvatar[i].Background = new ImageBrush(avatars[2]);
               if (Game.activePlayers.ElementAt(i).user.avatar.Equals("avatar4"))
                playerAvatar[i].Background = new ImageBrush(avatars[3]);

                playerName[i].Visibility = System.Windows.Visibility.Visible;
                playerName[i].Content = Game.activePlayers.ElementAt(i).user.UserName;

                playerCash[i].Visibility = System.Windows.Visibility.Visible;
                playerCash[i].Content ="      $ "+Game.activePlayers.ElementAt(i).cash;
            }
        }

        private void updateGame()
        {
            this.Game = BL.getGameByID(Game.GameID);

            this.Dispatcher.Invoke((Action)(() =>
            {//this refer to form in WPF application 
                updateTableCards();
                updatePlayers();

                cashOnTheTable.Text = "cash: " +this.Game.cashOnTheTable +"$";

                foreach (player currentPlayer in this.Game.activePlayers)
                    if (currentPlayer.user.ID == this.Game.CurrentPlayer)
                    {
                        now_playing.Text = "now playing: " + currentPlayer.user.UserName;
                        break;
                    }


                foreach (player myPlayer in this.Game.activePlayers)
                if(myPlayer.user.ID==this.user.ID)
                {
                    updateMyCards(myPlayer);
                    break;
                }
        }));
            }

        private  void myTurn()
        {
            this.Dispatcher.Invoke((Action)(() =>
            {//this refer to form in WPF application 
            fold_button.Visibility = System.Windows.Visibility.Visible;
            check_button.Visibility = System.Windows.Visibility.Visible;
            call_button.Visibility = System.Windows.Visibility.Visible;
            raise_button.Visibility = System.Windows.Visibility.Visible;
            Raise_to.Visibility = System.Windows.Visibility.Visible;
            raiseBet.Visibility = System.Windows.Visibility.Visible;
            slider.Visibility = System.Windows.Visibility.Visible;
            

            slider.Minimum = this.Game.CurrentBet;
            foreach (player myPlayer in this.Game.activePlayers)
                if (myPlayer.user.ID == this.user.ID)
                {
                    slider.Maximum = myPlayer.cash;
                    break;
                }
            }));
        }


        private void leave_game_Click(object sender, RoutedEventArgs e)
        {
            BL.leaveGame(Game.GameID, user.ID);
            newThread.Abort();
            gameCenter GC = new gameCenter(BL, user);
            GC.Show();
            this.Close();
        }

        private void fold_button_Click(object sender, RoutedEventArgs e)
        {
            BL.fold(user.ID, this.Game.GameID);

            this.Dispatcher.Invoke((Action)(() =>
            {//this refer to form in WPF application
                fold_button.Visibility = System.Windows.Visibility.Hidden;
            check_button.Visibility = System.Windows.Visibility.Hidden;
            call_button.Visibility = System.Windows.Visibility.Hidden;
            raise_button.Visibility = System.Windows.Visibility.Hidden;
            Raise_to.Visibility = System.Windows.Visibility.Hidden;
            raiseBet.Visibility = System.Windows.Visibility.Hidden;
            slider.Visibility = System.Windows.Visibility.Hidden;
            }));

            newThread = new Thread(new ThreadStart(Run));
            newThread.Start();

        }

        private void check_button_Click(object sender, RoutedEventArgs e)
        {
            BL.check(user.ID, this.Game.GameID);

            this.Dispatcher.Invoke((Action)(() =>
            {//this refer to form in WPF application
                fold_button.Visibility = System.Windows.Visibility.Hidden;
            check_button.Visibility = System.Windows.Visibility.Hidden;
            call_button.Visibility = System.Windows.Visibility.Hidden;
            raise_button.Visibility = System.Windows.Visibility.Hidden;
            Raise_to.Visibility = System.Windows.Visibility.Hidden;
            raiseBet.Visibility = System.Windows.Visibility.Hidden;
            slider.Visibility = System.Windows.Visibility.Hidden;
            }));
 
            newThread = new Thread(new ThreadStart(Run));
            newThread.Start();
        }

        private void call_button_Click(object sender, RoutedEventArgs e)
        {
            int bet=this.Game.CurrentBet;

            foreach (player myPlayer in this.Game.activePlayers)
                if (myPlayer.user.ID == this.user.ID)
                 if(bet>myPlayer.cash)
                    {
                        bet = myPlayer.cash;
                    }

            BL.call(user.ID, this.Game.GameID, bet);


            this.Dispatcher.Invoke((Action)(() =>
            {//this refer to form in WPF application
                fold_button.Visibility = System.Windows.Visibility.Hidden;
            check_button.Visibility = System.Windows.Visibility.Hidden;
            call_button.Visibility = System.Windows.Visibility.Hidden;
            raise_button.Visibility = System.Windows.Visibility.Hidden;
            Raise_to.Visibility = System.Windows.Visibility.Hidden;
            raiseBet.Visibility = System.Windows.Visibility.Hidden;
            slider.Visibility = System.Windows.Visibility.Hidden;
            }));

            newThread = new Thread(new ThreadStart(Run));
            newThread.Start();
        }

        private void raise_button_Click(object sender, RoutedEventArgs e)
        {
            BL.raise(user.ID, this.Game.GameID, int.Parse(raiseBet.Text));

            this.Dispatcher.Invoke((Action)(() =>
            {//this refer to form in WPF application
                fold_button.Visibility = System.Windows.Visibility.Hidden;
            check_button.Visibility = System.Windows.Visibility.Hidden;
            call_button.Visibility = System.Windows.Visibility.Hidden;
            raise_button.Visibility = System.Windows.Visibility.Hidden;
            Raise_to.Visibility = System.Windows.Visibility.Hidden;
            raiseBet.Visibility = System.Windows.Visibility.Hidden;
            slider.Visibility = System.Windows.Visibility.Hidden;
            }));

            newThread = new Thread(new ThreadStart(Run));
            newThread.Start();
        }

    }
}
