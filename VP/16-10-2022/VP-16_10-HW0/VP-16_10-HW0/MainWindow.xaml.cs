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

/** Work made on 17.10.2022
* By Ivan Kosiakov
* ID: U214N1534
*
* Description: This is app that allows Admin User
* to create and delete users with Name, Last name and Type
* of his choice.
* 
* Also this task helps to better understand a panels and grid
* and how to make your app more flexible
*/

namespace VP_16_10_HW0
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            String typeOfUser;

            // Small practice with MessageBoxes from lecture 17.10.2022
            if (FirstNameTextBox.Text == "" || LastNameTextBox.Text == "")
                MessageBox.Show("You didn't enter a first name OR last name!", "Empty fields", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {

                // Checking which radio button for Type of User is selected
                if ((bool)EmployeeButton.IsChecked)
                    typeOfUser = EmployeeButton.Content.ToString();
                else typeOfUser = StudentButton.Content.ToString();

                // There are NO ANY REASON for using class, but I want to, so Leave me alone ඞ
                User newUser = new User(FirstNameTextBox.Text, LastNameTextBox.Text, typeOfUser);

                CheckBox myCheckBox = new CheckBox();
                myCheckBox.Content = newUser.FirstName + " " + newUser.LastName + " ( " + newUser.Type + " )";
                UserStackPanel.Children.Add(myCheckBox);
            }
        }

        private void RemoveUserButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < UserStackPanel.Children.Count; i++)
            {
                CheckBox userCheckBox = UserStackPanel.Children[i] as CheckBox;

                if ((bool)userCheckBox.IsChecked)
                {
                    UserStackPanel.Children.Remove(userCheckBox);
                    --i;
                }
            }
        }
    }
}
