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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        businessLayer BL;

        public MainWindow()
        {
            InitializeComponent();
                this.BL = new businessLayer(); 
        }
        public MainWindow(businessLayer bl)
        {
            InitializeComponent();
             this.BL = bl;
        }

        private void signup_Click(object sender, RoutedEventArgs e)
        {
            signUp SU = new signUp(BL);
            SU.Show();
            this.Close();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            bool isUserExist;
            User user=null;
            isUserExist = BL.login(id_textBox.Text, pass_textBox.Text);
            if(!isUserExist)
            {
                //TODO: show appropriate message to the user
            }
            else
            {
                user = BL.getUser(id_textBox.Text);
            }

            gameCenter GC = new gameCenter(BL, user);
            GC.Show();
            this.Close();
        }
    }
}
