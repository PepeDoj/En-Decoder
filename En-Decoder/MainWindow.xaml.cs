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
using TestDB;

namespace En_Decoder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string UserID = null;

        Random random = new Random();

        public DateTime date = new DateTime();

        int LevelID1 = 16;
        int LevelID2 = 8;
        int LevelID3 = 8;
        int LevelID4 = 8;


        /*const int LenghtCodeLibrary = 8;      

        static string librarypath = @"C:\Users\roman\source\repos\En-Decoder\library.txt";
        static string userspath = @"C:\Users\roman\source\repos\En-Decoder\users\users.txt";
        static string codelibrary = @"C:\Users\roman\source\repos\En-Decoder\codelibrary\";
        static string codelibrarybuf = null;

        public string code = "";
        public string codebuf = "";

        static string symbols = File.ReadAllText(librarypath);*/




        public MainWindow()
        {
            InitializeComponent();





            /*codelibrarybuf = codelibrary + rnd.Next(1000000, 9999999) + ".txt"; 

            string[] lines = File.ReadAllLines(codelibrarybuf);

            for (int i = 0; i < symbols.Length; i++)
            { 
                for (int j = 0; j < LenghtCodeLibrary; j++)
                {
                    code = code + symbols[rnd.Next(0, symbols.Length)];

                    if(code == codebuf)
                    {
                        code = "";
                        j--;
                    }

                    foreach (string s in lines)
                    {
                        for (int k = 0; k < LenghtCodeLibrary; k++)
                        {
                            codebuf = codebuf + s[k];
                        }

                        if (code == codebuf)
                        {
                            Chat.Text = Chat.Text + "true";

                            code = "";
                            codebuf = "";

                            j--;


                        }

                        else
                        {
                            File.AppendAllText(codelibrarybuf, symbols[i].ToString() + " - " + code + "\n");

                            code = "";
                            codebuf = "";
                        }


                    }
                }    
            }*/


            /*private void Button_Click(object sender, RoutedEventArgs e)
            {
                Chat.Text = Chat.Text + "TEST " + DateTime.Now.ToShortTimeString() + ": " + Message.Text;

                Chat.Text += "\r\n";

                Message.Text = null;
            }*/


        }



        private void Enter_Click(object sender, RoutedEventArgs e)
        {
           /* using (var db = new ApplicationContext())
            {
                var users = db.Users.ToList();

                foreach (Users u in users)
                {
                    Chat.Text = Chat.Text + u.ID + " " + u.Nickname + " " + u.Login + " " + u.Password + "\n";
                }
            }*/
        }
        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordSignIn == PasswordProofSignIn)
            {
                PasswordSignIn.Password = null;
                PasswordProofSignIn.Password = null;
            }

            else
            {
                using (var db = new ApplicationContext())
                {
                    for (int i = 0; i < LevelID1; i++)
                    {
                        UserID = UserID + random.Next(0, 10);
                    }

                    UserID = UserID + "-";

                    for (int i = 0; i < LevelID2; i++)
                    {
                        UserID = UserID + random.Next(0, 10);
                    }

                    UserID = UserID + "-";

                    for (int i = 0; i < LevelID3; i++)
                    {
                        UserID = UserID + random.Next(0, 10);
                    }

                    UserID = UserID + "-";

                    for (int i = 0; i < LevelID4; i++)
                    {
                        UserID = UserID + random.Next(0, 10);
                    }

                    // создаем два объекта User
                    Users user = new Users { ID = UserID, Nickname = NicknameSignIn.Text, Login = LoginSignIn.Text, Password = PasswordSignIn.Password };

                    // добавляем их в бд
                    db.Users.Add(user);
                    db.SaveChanges();

                    PasswordSignIn.Password = null;
                    PasswordProofSignIn.Password = null;
                    LoginSignIn.Text = null;
                    NicknameSignIn.Text = null;
                }

            }
        }

        

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new SignInPage();
        }
    }
}
