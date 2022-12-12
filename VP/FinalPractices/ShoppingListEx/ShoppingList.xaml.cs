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
using System.Windows.Shapes;

namespace FinalPractisesVP
{
    public partial class ShoppingList : Window
    {
        public ShoppingList()
        {
            InitializeComponent();
        }

        private void AddShoppingListButton_Click(object sender, RoutedEventArgs e)
        {
            // Error Handling
            if (string.IsNullOrEmpty(ItemNameTextBox.Text))
            {
                MessageBox.Show("Please enter name", "Invalid name", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrEmpty(ItemQuantityTextBox.Text))
            {
                MessageBox.Show("Please enter quantity", "Invalid quantity", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!int.TryParse(ItemQuantityTextBox.Text, out int quantity))
            {
                MessageBox.Show("Please enter valid number for quantity", "Invalid quantity number", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // If all error handling passed add a checkBox with corresponding data
                CheckBox checkBox = new CheckBox();
                checkBox.Content = ItemQuantityTextBox.Text + "x " + ItemNameTextBox.Text;

                ShoppingListStackPanel.Children.Add(checkBox);
            }
        }

        private void ShoppingListButton_Click(object sender, RoutedEventArgs e)
        {
            // Deleting every selected checkBox
            for(int i = 0; i < ShoppingListStackPanel.Children.Count; i++)
            {
                CheckBox checkBox = ShoppingListStackPanel.Children[i] as CheckBox;
                if((bool)checkBox.IsChecked)
                {
                    ShoppingListStackPanel.Children.RemoveAt(i);
                    --i;
                }
            }
        }
    }
}
