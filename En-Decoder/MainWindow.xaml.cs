using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        public DateTime date = new DateTime();

        public MainWindow()
        {
            InitializeComponent();

            Binding binding = new Binding();
            binding.ElementName = DataBank.UserLog;
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            
            MainFrame.Content = new SignUpPage();
            
            //UserLabel.Content = DataBank.UserLog;

        }

        private void Chat_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ChatPage();
            UserLabel.Content = App.Current.Resources["UserLog"];
        }
    }
}
