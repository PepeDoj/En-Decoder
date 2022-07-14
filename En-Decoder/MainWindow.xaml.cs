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

        public string UserLog;

        public void Update()
        {
  
        }
        public MainWindow()
        {
            InitializeComponent();

            Thread.Sleep(1);

        }
        private void Enter_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void Chat_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ChatPage();
        }
    }
}
