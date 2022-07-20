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
        static string librarypath = @"C:\Users\roman\source\repos\En-Decoder\library.txt";
        static string symbols = File.ReadAllText(librarypath);

        int LenghtSymbol = 16;

        Random random = new Random();

        string LibraryID = null;
        string Code = null;
        string Buf = null;
        int LibraryLenght = 32;

        public MainWindow()
        {
            InitializeComponent();

            using (var db = new ApplicationContext())
            {
                for (int i = 0; i < symbols.Length; i++)
                {
                    for (int j = 0; j < LenghtSymbol; j++)
                    {
                        Buf = Buf + symbols[random.Next(1, symbols.Length)];
                    }

                    Code = Code + Buf;
                    Buf = null;

                }

                for (int i = 0; i < LibraryLenght; i++)
                {
                    LibraryID = LibraryID + random.Next(0, 10);
                }

                CodeLibraries CodeLibrary = new CodeLibraries { LibraryID = LibraryID, Code = Code};

                db.CodeLibraries.Add(CodeLibrary);
                db.SaveChanges();
            }
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
