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

namespace GUI
{
    /// <summary>
    /// Interaction logic for game.xaml
    /// </summary>
    public partial class game : Window
    {
        businessLayer BL;
        BL.game Game;
        BitmapImage[] image = new BitmapImage[52];
        BitmapImage[] avatars = new BitmapImage[4];
        int[] cards = new int[52];
        int[] avatarsIndex = new int[4];
        String[] royalFamily = { "jack", "queen", "king", "ace" };
        public game(businessLayer bl, BL.game Game)
        {
            InitializeComponent();
            this.BL = bl;
            this.Game = Game;

            avatars[0] = new BitmapImage(new Uri("avatar1.jpg", UriKind.Relative));
            avatars[1] = new BitmapImage(new Uri("avatar2.png", UriKind.Relative));
            avatars[2] = new BitmapImage(new Uri("avatar3.jpg", UriKind.Relative));
            avatars[3] = new BitmapImage(new Uri("avatar4.jpg", UriKind.Relative));

            for (int i = 0; i < 52; i++)
                cards[i] = i;

            for (int i = 0; i < 4; i++)
                avatarsIndex[i] = i;

            for (int i=0; i<9; i++)
            {
                image[i] = new BitmapImage(new Uri((i+2)+ "_of_clubs.png", UriKind.Relative));
                image[i+13] = new BitmapImage(new Uri((i + 2) + "_of_diamonds.png", UriKind.Relative));
                image[i+26] = new BitmapImage(new Uri((i + 2) + "_of_hearts.png", UriKind.Relative));
                image[i+39] = new BitmapImage(new Uri((i + 2) + "_of_spades.png", UriKind.Relative));
            }

            for (int i = 9; i < 13; i++)
            {
                image[i] = new BitmapImage(new Uri(royalFamily[i - 9] + "_of_clubs.png", UriKind.Relative));
                image[i + 13] = new BitmapImage(new Uri(royalFamily[i - 9] + "_of_diamonds.png", UriKind.Relative));
                image[i + 26] = new BitmapImage(new Uri(royalFamily[i - 9] + "_of_hearts.png", UriKind.Relative));
                image[i + 39] = new BitmapImage(new Uri(royalFamily[i - 9] + "_of_spades.png", UriKind.Relative));
            }
        }

        private void shuffle_Click(object sender, RoutedEventArgs e)
        {
            shuffle_the_deck(cards);
            card1.Background = new ImageBrush(image[cards[0]]);
            card2.Background = new ImageBrush(image[cards[1]]);
            card3.Background = new ImageBrush(image[cards[2]]);
            card4.Background = new ImageBrush(image[cards[3]]);
            card5.Background = new ImageBrush(image[cards[4]]);

            player1_avatar.Background = new ImageBrush(avatars[avatarsIndex[0]]);
            player2_avatar.Background = new ImageBrush(avatars[avatarsIndex[1]]);
            player3_avatar.Background = new ImageBrush(avatars[avatarsIndex[2]]);
            player4_avatar.Background = new ImageBrush(avatars[avatarsIndex[3]]);

            player1_name.Visibility = System.Windows.Visibility.Visible;
            player1_cash.Visibility = System.Windows.Visibility.Visible;
            player2_name.Visibility = System.Windows.Visibility.Visible;
            player2_cash.Visibility = System.Windows.Visibility.Visible;
            player3_name.Visibility = System.Windows.Visibility.Visible;
            player3_cash.Visibility = System.Windows.Visibility.Visible;
            player4_name.Visibility = System.Windows.Visibility.Visible;
            player4_cash.Visibility = System.Windows.Visibility.Visible;
        }

        private void update_cards_images(card[] cards)
        {

        }
        private void shuffle_the_deck(int [] cards)
        {
            int newI;
            int temp;
            Random randIndex = new Random();

            for (int i = 0; i < 52; i++)
            {
                newI = randIndex.Next(52);

                // swap cards[i] and cards[newI]
                temp = cards[i];
                cards[i] = cards[newI];
                cards[newI] = temp;
            }
            
            for (int i = 0; i < 4; i++)
            {
                newI = randIndex.Next(4);

                // swap 
                temp = avatarsIndex[i];
                avatarsIndex[i] = avatarsIndex[newI];
                avatarsIndex[newI] = temp;
            }
            
        }
    }
}
