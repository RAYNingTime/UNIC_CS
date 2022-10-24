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

using UserClass;

namespace VP_23_10_HW2
{
    public partial class MainWindow : Window
    {
        // Global user list that can be called from every action
        List<User> _users = new List<User>();

        public MainWindow()
        {
            InitializeComponent();

            // Creating 3 users as you said
            _users.Add(new User("firstUser", "qwerty123"));
            _users.Add(new User("secondUser", "poiuy098"));
            _users.Add(new User("admin", "admin"));
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            bool isSuccessful = false;

            // Getting data from boxes
            string inputUsername = usernameTextBox.Text;
            string inputPassword = passwordBox.Password;

            foreach (User user in _users)
            {
                if (user.Username == inputUsername && user.Password == inputPassword)
                {
                    isSuccessful = true;
                    // If user is found breakout of the loop
                    break;
                }
            }

            // As I learned incorrect password is an error
            if (isSuccessful)
                MessageBox.Show("Successful!","Success",MessageBoxButton.OK,MessageBoxImage.Information);
            else
                MessageBox.Show("Invalid data!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
