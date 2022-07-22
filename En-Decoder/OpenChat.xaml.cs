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
    /// Логика взаимодействия для OpenChat.xaml
    /// </summary>
    public partial class OpenChat : Page
    {
        public OpenChat()
        {
            InitializeComponent();
        }

        private void OpenChatButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                var chatrooms = db.ChatRooms.ToList();

                foreach (ChatRooms cr in chatrooms)
                {
                    if (OpenChatLogin.Text == cr.Login && OpenChatPassword.Password == cr.Password)
                    {
                        DataBank.ChatRoom = cr.RoomID;

                        OpenChatLogin.Text = null;
                        OpenChatPassword.Password = null;
                    }
                }
            }

        }   
    }
}
