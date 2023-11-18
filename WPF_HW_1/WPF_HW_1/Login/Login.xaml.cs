using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_HW_1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
       
        Dictionary<string, DataUser> user;
        string hashPass;
        string hashLog;
        public Login()
        {
            InitializeComponent();
            user = new Dictionary<string, DataUser>();
            
        }

        private void SendButtonClic(object sender, RoutedEventArgs e)
        {
            var hash = MD5.Create();
            if (!string.IsNullOrEmpty(pass.Password)&& !string.IsNullOrEmpty(pass.Password))
            {
                hashPass = string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(pass.Password)).Select(x => x.ToString("X2")));
                hashLog = string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(login.Text)).Select(x => x.ToString("X2")));

                if (user.ContainsKey(hashLog))
                {
                    messageTextBlock.Text = "Such a user";
                    messageTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    user.Add(hashLog, new DataUser(hashLog, hashPass));
                    messageTextBlock.Text = "Successful";
                    messageTextBlock.Foreground = new SolidColorBrush(Colors.Green);
                }
                    
            }
            
            
        }
        private void CheckButton(object sender, RoutedEventArgs e)
        {
            var hash = MD5.Create();
            if (!string.IsNullOrEmpty(pass.Password) && !string.IsNullOrEmpty(pass.Password))
            {
                hashPass = string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(pass.Password)).Select(x => x.ToString("X2")));
                hashLog = string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(login.Text)).Select(x => x.ToString("X2")));

                if (user.ContainsKey(hashLog)&&user[hashLog].Pass.Equals(hashPass))
                {
                    messageTextBlock.Text = "Successful";
                    messageTextBlock.Foreground = new SolidColorBrush(Colors.Green);
                    
                }
                else
                {
                    messageTextBlock.Text = "Access denied";
                    messageTextBlock.Foreground = new SolidColorBrush(Colors.Red);

                }

            }

        }
    }
}
