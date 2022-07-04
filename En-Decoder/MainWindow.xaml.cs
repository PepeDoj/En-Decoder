using System;
using System.Collections.Generic;
using System.IO;
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

namespace En_Decoder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string librarypath = @"C:\Users\roman\source\repos\En-Decoder\library.txt";
        public string userspath = @"C:\Users\roman\source\repos\En-Decoder\users\users.txt";

        Random rnd = new Random();

        public DateTime date1 = new DateTime();
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Chat.Text = Chat.Text + "TEST " + DateTime.Now.ToShortTimeString() + ": " + Message.Text;

            Chat.Text += "\r\n";

            Message.Text = null;

            //Chat.Text = File.ReadAllText(librarypath);
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            

            if (pass.Password == passproof.Password)
            {
                File.AppendAllTextAsync(userspath, nickname.Text + " " + pass.Password + " " + rnd.Next(1000000, 9999999) + "\n");

                nickname.Text = null;
                pass.Password = null;
                passproof.Password = null;
            }

            else
            {
                pass.Password = null;
                passproof.Password= null;
            }

            //Chat.Text = File.ReadAllLines(userspath);
        }
    }
}
