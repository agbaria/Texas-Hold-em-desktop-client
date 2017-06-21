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
    /// Interaction logic for privateMessage.xaml
    /// </summary>
    public partial class privateMessage : Window
    {
        businessLayer BL;
        String myName, ReceieverID, ReceiverName;

        public privateMessage(businessLayer bl, String myName, String ReceieverID, String ReceiverName)
        {
            InitializeComponent();
            this.BL = bl;
            this.myName = myName;
            this.ReceiverName = ReceiverName;
            this.ReceieverID = ReceieverID;
            this.label.Content = "write your private message for " + ReceiverName;
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            String message = myName + " say: "+ messageBox.Text+"\n";
            this.BL.sendPrivateMessage(ReceieverID, message);
            this.Close();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
