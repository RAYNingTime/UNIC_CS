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

// Connecting User class file
// Otherwise it didn't work ¯\_(ツ)_/¯
using UserClass;

/** Work made on 09.10.2022
* By Ivan Kosiakov
* ID: U214N1534
*
* Description: This is a login menu for users that checks 
* if the password and username are correct.
* 
* If they are the same as those registered, you will get the correct answer,
* otherwise you will get an error.
*/

// I'm using names for the programs as
// [FIRST LETTERS OF SUBJECT]-[DD]_[MM]-HW[NUMBER OF THE EXERCISE]
namespace VP_03_10_HW0
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

            if (isSuccessful)
            {
                messageTextBlock.Text = "Successful!";
                messageTextBlock.Background = Brushes.LightGreen;
                messageTextBlock.Foreground = Brushes.Black;
            }
            else
            {
                messageTextBlock.Text = "Invalid data!";
                messageTextBlock.Background = Brushes.Red;
                messageTextBlock.Foreground = Brushes.White;
            }

        }
    }
}

// Note: All files was made by handwriting without that weird placing system
// God bless HTML and CSS o(*￣▽￣*)ブ
