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
    /// Логика взаимодействия для NewChat.xaml
    /// </summary>
    public partial class NewChat : Page
    {
        static string librarypath = @"C:\Users\roman\source\repos\En-Decoder\library.txt";
        static string symbols = File.ReadAllText(librarypath);

        int LenghtSymbol = 16;

        Random random = new Random();

        string LibraryID = null;
        //string LibraryIDKey = null;
        //string LibraryIDStrength = null;        

        string Code = null;

        string Buf = null;
        int LibraryLenghtLevel1 = 8;
        //int LibraryLenghtLevel2 = 8;
        //int LibraryLenghtLevel3 = 8;

        string RoomID = null;
        public NewChat()
        {
            InitializeComponent();
        }

        private void NewChatButton_Click(object sender, RoutedEventArgs e)
        {
            if(NewChatPassword.Password != NewChatPasswaordProof.Password)
            {
                NewChatPassword = null;
                NewChatPasswaordProof = null;
            }

            else
            {
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

                    for (int i = 2; i < LibraryLenghtLevel1; i++)
                    {
                        LibraryID = LibraryID + random.Next(0, 10);
                    }

                    CodeLibraries CodeLibrary = new CodeLibraries { LibraryID = LibraryID, Code = Code };

                    db.CodeLibraries.Add(CodeLibrary);
                    db.SaveChanges();

                    /////////////////////////////

                    for (int i = 0; i < 8; i++)
                    {
                        RoomID = RoomID + random.Next(0, 10);
                    }

                    ChatRooms chatRoom = new ChatRooms { RoomID = RoomID, CodeID = LibraryID, Login = NewChatLogin.Text, Password = NewChatPassword.Password };

                    db.ChatRooms.Add(chatRoom);
                    db.SaveChanges();

                    RoomID = null;
                    Code = null;
                    LibraryID = null;

                    NewChatPassword.Password = null;
                    NewChatPasswaordProof.Password = null;
                    NewChatLogin.Text = null;
                }

                using (var db = new ApplicationContext())
                {

                }
            }
        }

        private void OpenChat_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OpenChat());
        }
    }
}
