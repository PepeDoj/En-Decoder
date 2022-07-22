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
using System.IO;
using DocumentFormat.OpenXml.Bibliography;

namespace En_Decoder
{
    /// <summary>
    /// Логика взаимодействия для SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent(); 
            
        }

        public event EventHandler ButtonClicked;
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                
                foreach (Users u in users)
                {
                    if (LoginSignUp.Text == u.Login && PasswordSignUp.Password == u.Password)
                    {                        
                        DataBank.UserLog = u.Nickname;
                        Label1.Content = DataBank.UserLog;


                        LoginSignUp.Text = null;
                        PasswordSignUp.Password = null;     
                    }
                }
            }         
        }

        private void SignButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignInPage());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            DataBank.UserLog = " ";
            Label1.Content = DataBank.UserLog;
        }
    }
}
