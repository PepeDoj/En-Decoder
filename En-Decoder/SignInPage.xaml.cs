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


namespace En_Decoder
{
    /// <summary>
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        string UserID = null;

        Random random = new Random();

        int LevelID1 = 16;
        int LevelID2 = 8;
        int LevelID3 = 8;
        int LevelID4 = 8;

        public SignInPage()
        {
            InitializeComponent();
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
    }
}
    
