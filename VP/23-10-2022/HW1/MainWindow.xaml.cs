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

namespace VP_23_10
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

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            String allTasks = "";

            // Saving all the tasks from panel to the string
            for (int i = 0; i < TaskStackPanel.Children.Count; i++)
            {
                CheckBox taskCheckBox = TaskStackPanel.Children[i] as CheckBox;
                allTasks += taskCheckBox.Content + "\n";
            }

            // Clearing of the Stack Panel
            TaskStackPanel.Children.Clear();

            // Saving string as a file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == true)
            {
                String fileName = saveFileDialog.FileName;
                System.IO.File.WriteAllText(fileName, allTasks);
            }

        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            // Opening of the file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                String fileName = openFileDialog.FileName;
                String allTasks = System.IO.File.ReadAllText(fileName);
                String mergedTasks = "";

                // Taking all the data from file and creating a checkbox for each one
                mergedTasks = string.Join(Environment.NewLine, allTasks);
                var separatedTasks = mergedTasks.Split("\n");

                foreach (String task in separatedTasks)
                {
                    if (task != "") { 
                        CheckBox myCheckBox = new CheckBox();
                        myCheckBox.Content = task;
                        TaskStackPanel.Children.Add(myCheckBox);
                    }
                }
            }
        }

        private void NewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            // Checking for an empty textbox
            if (NewTaskTextBox.Text == "")
                MessageBox.Show("You didn't enter a task!", "Empty fields", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                // Creating a new CheckBox
                CheckBox myCheckBox = new CheckBox();
                myCheckBox.Content = NewTaskTextBox.Text;
                TaskStackPanel.Children.Add(myCheckBox);
            }
        }

        private void RemoveTaskButton_Click(object sender, RoutedEventArgs e)
        {
            // Everything that is going to be shown in message box
            string messageBoxText = "Are you sure you want to delete these tasks?\nThis tasks will be deleted immediately. You can't undo this action.";
            string caption = "Confirm Deletion";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

            // Saving the result from Message Box
            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

            if (result == MessageBoxResult.Yes)
            {
                // Checking all the checkboxes for a check
                for (int i = 0; i < TaskStackPanel.Children.Count; i++)
                {
                    CheckBox taskCheckBox = TaskStackPanel.Children[i] as CheckBox;

                    // If checkbox is checked => delete
                    if ((bool)taskCheckBox.IsChecked)
                    {
                        TaskStackPanel.Children.Remove(taskCheckBox);
                        --i;
                    }
                }
            }
            }
        }
    }
