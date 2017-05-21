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
        int[] cards = new int[52];
        String[] royalFamily = { "jack", "queen", "king", "ace" };
        public game(businessLayer bl, BL.game Game)
        {
            InitializeComponent();
            this.BL = bl;
            this.Game = Game;

            for (int i = 0; i < 52; i++)
                cards[i] = i;

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
        }
    }
}
