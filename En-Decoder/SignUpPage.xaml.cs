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
    /// Логика взаимодействия для SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpPage(string UserLo)
        {
            InitializeComponent();
            UserLo = 1;
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

                      
                    }

                    else
                    {
                        //Chat.Text = "FALSE";
                    }

                }
            }         
        }

        private void SignButton_Click(object sender, RoutedEventArgs e)
        {
 
        }
    }
}
