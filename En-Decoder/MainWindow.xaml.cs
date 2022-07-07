﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int LenghtCodeLibrary = 8;      

        static string librarypath = @"C:\Users\roman\source\repos\En-Decoder\library.txt";
        static string userspath = @"C:\Users\roman\source\repos\En-Decoder\users\users.txt";
        static string codelibrary = @"C:\Users\roman\source\repos\En-Decoder\codelibrary\";
        static string codelibrarybuf;

        public string code = null;
        public string codebuf = null;

        static string symbols = File.ReadAllText(librarypath);

        Random rnd = new Random();

        public DateTime date = new DateTime();

        

        public MainWindow()
        {
            InitializeComponent();

            string[] lines = File.ReadAllLines(codelibrarybuf);

            codelibrarybuf = codelibrary + rnd.Next(1000000, 9999999) + ".txt";

            for (int i = 0; i < symbols.Length; i++)
            { 
                for (int j = 0; j < LenghtCodeLibrary; j++)
                {
                    code = code + symbols[rnd.Next(0, symbols.Length)];

                    if(code == codebuf)
                    {
                        code = null;
                        j--;
                    }

                    else
                    {
                        File.AppendAllText(codelibrarybuf, symbols[i].ToString() + " - " + code + "\n");

                        code = null;
                    }
                }

                
                
                
            }

            

            foreach (string s in lines)
            {
                if (s[4
                    ] == '1')
                {
                    Chat.Text = s;
                }
            }

    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Chat.Text = Chat.Text + "TEST " + DateTime.Now.ToShortTimeString() + ": " + Message.Text;

            Chat.Text += "\r\n";

            Message.Text = null;
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            if (pass.Password == passproof.Password)
            {
                File.AppendAllTextAsync(userspath, nickname.Text + " " + pass.Password + " " + rnd.Next(1000000, 9999999) + "\n");

                nickname.Text = null;
                pass.Password = null;
                passproof.Password = null;

                File.OpenRead(librarypath);
            }

            else
            {
                pass.Password = null;
                passproof.Password= null;
            }
        }
    }
}
