using Microsoft.Win32;
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
using System.Windows.Media.TextFormatting;

namespace HW5Ex0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            // Error Handling
            if (string.IsNullOrEmpty(FirstNameTextBox.Text))
            {
                MessageBox.Show("Please enter first name", "Invalid first name", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrEmpty(LastNameTextBox.Text))
            {
                MessageBox.Show("Please enter last name", "Invalid last name", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrEmpty(AdressTextBox.Text))
            {
                MessageBox.Show("Please enter adress", "Invalid adress", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrEmpty(PostCodeTextBox.Text))
            {
                MessageBox.Show("Please enter post code", "Invalid post code", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!int.TryParse(PostCodeTextBox.Text, out int postCode))
            {
                MessageBox.Show("Please enter valid post code", "Invalid post code", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (postCode < 0)
            {
                MessageBox.Show("Please enter positive post code", "Invalid post code", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Creating new Student CheckBox
            CheckBox newCheckBox = new CheckBox();
            newCheckBox.Content = FirstNameTextBox.Text + " " + LastNameTextBox.Text + " (" + ClassStandingComboBox.Text + ")";
            StudentStackPanel.Children.Add(newCheckBox);
        }

        private void ImportStudentsButton_Click(object sender, RoutedEventArgs e)
        {
            // Importing new students line by line
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                String fileName = openFileDialog.FileName;
                String[] importedStudents = File.ReadAllLines(fileName);

                foreach(var student in importedStudents)
                {
                    CheckBox newCheckBox = new CheckBox();
                    newCheckBox.Content = student;
                    newCheckBox.Tag = student;
                    StudentStackPanel.Children.Add(newCheckBox);
                }
            }
        }

        private void ExportStudentsButton_Click(object sender, RoutedEventArgs e)
        {
            String saveData = "";
            bool selected = false;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == true)
            {
                String fileName = saveFileDialog.FileName;

                for (int i = 0; i < StudentStackPanel.Children.Count; i++)
                {
                    CheckBox studentCheckBox = StudentStackPanel.Children[i] as CheckBox;

                    if (studentCheckBox.IsChecked == true)
                    {
                        saveData += studentCheckBox.Content + "\n";
                        StudentStackPanel.Children.RemoveAt(i);
                        i--;

                        selected = true;
                    }

                }

                // Error Handling if no students selected
                if (!selected)
                    MessageBox.Show("To export data you should select minimum one student!", "Student is not selected", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    File.WriteAllText(fileName, saveData);
            }
        }
    }
}
