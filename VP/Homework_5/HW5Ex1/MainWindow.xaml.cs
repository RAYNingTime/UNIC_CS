using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace HW5Ex1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Error Handling
            if (string.IsNullOrEmpty(TitleTextBox.Text))
            {
                MessageBox.Show("Please enter title", "Invalid title", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrEmpty(DescriptionTextBox.Text))
            {
                MessageBox.Show("Please enter description", "Invalid description", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Creating Remove Button
            Button button = new Button();
            button.Content = "Remove";
            button.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#8B0000");
            button.Foreground = new SolidColorBrush(Colors.White);
            button.VerticalAlignment = VerticalAlignment.Center;
            button.HorizontalAlignment = HorizontalAlignment.Left;
            button.Tag = button;
            button.Click += Button_Click;

            // Creating TextBlock that is going to contain Description
            // TextBlock instead of label because I want use TextWrapping
            TextBlock textBlock = new TextBlock();
            textBlock.Text = DescriptionTextBox.Text;
            textBlock.TextWrapping = TextWrapping.Wrap;

            // Creating Stack Panel to put inside of the expander
            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(button);

            // Creating Expander that contains Title as a header and Stack Panel as a Content
            Expander expander = new Expander();
            expander.Header = TitleTextBox.Text;
            expander.Content = stackPanel;

            BoardStackPanel.Children.Add(expander);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                // For Each expander in Stack panel
                foreach(Expander expander in BoardStackPanel.Children)
                {
                    // Selecting Content of the Expander
                    StackPanel stackPanel = expander.Content as StackPanel;

                    // And checking if Children at position 1 (Always button) is the same as our sender of the event
                    if (stackPanel.Children[1] == button)
                    {
                        BoardStackPanel.Children.Remove(expander);
                        // If found leaving the event, otherwise it'll crash...
                        return;
                    }
                }
            }

        }
    }
}
