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
    /// Логика взаимодействия для ChatPage.xaml
    /// </summary>
    public partial class ChatPage : Page
    {
        string mess;
        public ChatPage()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            mess = "TEST123 " + DateTime.Now.ToShortTimeString() + ": " + Message.Text + "\r\n";

            using (var db = new ApplicationContext())
            {
                var chatRooms = db.ChatRooms.ToList();

                foreach(ChatRooms c in chatRooms)
                { 
                    if(c.CodeID == "123")
                    {
                        c.ChatHistory += mess;
                        db.SaveChanges();
                        Chat.Text = null;
                        mess = null;
                        Chat.Text = c.ChatHistory;
                    }
                }


            }

            Message.Text = null;
        }
    }
}
