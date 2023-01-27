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

namespace VS_16._10_HW1
{
    public partial class MainWindow : Window
    {
        List<PizzaSize> pizzaSizes = new List<PizzaSize>();
        List<PizzaTopping> pizzaToppings = new List<PizzaTopping>();

        private double _currentPrice = 0;
        public MainWindow()
        {
            InitializeComponent();

            // Initializing and showing all the components of pizza
            SetDefaultSizeAndToppings();
            InitializeSizes();
            InitializeToppings();

            // Updating Total Price Counter
            IncreaseTotalPrice(0);
        }

        // This method adds some default values for the lists of Sizes and Toppings
        private void SetDefaultSizeAndToppings()
        {
            // Default Sizes
            pizzaSizes.Add(new PizzaSize("Small", 5.0));
            pizzaSizes.Add(new PizzaSize("Medium", 6.0));
            pizzaSizes.Add(new PizzaSize("Large", 7.0));

            // Default Toppings
            pizzaToppings.Add(new PizzaTopping("Tomato", 0.5));
            pizzaToppings.Add(new PizzaTopping("Onion", 0.5));
            pizzaToppings.Add(new PizzaTopping("Pepper", 0.5));
        }

        // This method initializes all the sizes that are currently at the list
        private void InitializeSizes()
        {
            foreach (PizzaSize singleSize in pizzaSizes)
            {
                RadioButton sizeRadioButton = new RadioButton();
                sizeRadioButton.Content = singleSize.Name;
                sizeRadioButton.Tag = singleSize;

                sizeRadioButton.Checked += SizeRadioButton_Checked;
                sizeRadioButton.Unchecked += SizeRadioButton_Unchecked;

                pizzaSizeStackPanel.Children.Add(sizeRadioButton);
            }
        }

        // This method decreases total price every time when Size RadioButton is unchecked 
        private void SizeRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            // As showed in the example of the HW
            RadioButton checkBox = sender as RadioButton;
            PizzaSize pizzaSize = checkBox.Tag as PizzaSize;

            DecreaseTotalPrice(pizzaSize.Price);
        }

        // This method increases total price every time when Size RadioButton is checked 
        private void SizeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // As showed in the example of the HW
            RadioButton checkBox = sender as RadioButton;
            PizzaSize pizzaSize = checkBox.Tag as PizzaSize;

            IncreaseTotalPrice(pizzaSize.Price);
        }

        // This method initializes all the toppings that are currently at the list
        private void InitializeToppings()
        {
            foreach (PizzaTopping singleTopping in pizzaToppings)
            {
                CheckBox ToppingCheckBox = new CheckBox();
                ToppingCheckBox.Content = singleTopping.Name;
                ToppingCheckBox.Tag = singleTopping;

                ToppingCheckBox.Checked += ToppingCheckBox_Checked;
                ToppingCheckBox.Unchecked += ToppingCheckBox_Unchecked;

                pizzaToppingStackPanel.Children.Add(ToppingCheckBox);
            }
        }

        // This method decreases total price every time when Topping CheckBox is unchecked 
        private void ToppingCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // As showed in the example of the HW
            CheckBox checkBox = sender as CheckBox;
            PizzaTopping pizzaTopping = checkBox.Tag as PizzaTopping;

            DecreaseTotalPrice(pizzaTopping.Price);
        }

        // This method increases total price every time when Topping CheckBox is checked 
        private void ToppingCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // As showed in the example of the HW
            CheckBox checkBox = sender as CheckBox;
            PizzaTopping pizzaTopping = checkBox.Tag as PizzaTopping;

            IncreaseTotalPrice(pizzaTopping.Price);
        }

        // This method increases the total balance and shows it
        private void IncreaseTotalPrice(double valueToAdd)
        {
            _currentPrice += valueToAdd;

            PriceLabel.Text = _currentPrice.ToString();
        }

        // This method decreases the total balance and shows it
        private void DecreaseTotalPrice(double valueToAdd)
        {
            _currentPrice -= valueToAdd;

            PriceLabel.Text = _currentPrice.ToString();
        }

        // This event check every radio button of the menu to ADD or REMOVE some TOPPING or SIZE
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            double inputDouble;

            // Checking the ADD section
            if ((bool)AddToppingButton.IsChecked)
            {
                // Reseting Button
                AddToppingButton.IsChecked = false;

                if (double.TryParse(AddPriceTextBox.Text, out inputDouble))
                    pizzaToppings.Add(new PizzaTopping(AddNameTextBox.Text, inputDouble));
            }
            else if ((bool)AddSizeButton.IsChecked)
            {
                // Reseting button
                AddSizeButton.IsChecked = false;

                if (double.TryParse(AddPriceTextBox.Text, out inputDouble))
                    pizzaSizes.Add(new PizzaSize(AddNameTextBox.Text, inputDouble));
            }

            // Checking the REMOVE section
            if ((bool)RemoveToppingButton.IsChecked)
            {
                // Reseting button
                RemoveToppingButton.IsChecked = false;

                for (int i = 0; i < pizzaToppings.Count; i++)
                    if (pizzaToppings.ElementAt(i).Name == RemoveTextBox.Text)
                        pizzaToppings.Remove(pizzaToppings[i]);
            }
            else if ((bool)RemoveSizeButton.IsChecked)
            {
                // Reseting button
                RemoveSizeButton.IsChecked = false;

                for (int i = 0; i < pizzaSizes.Count; i++)
                    if (pizzaSizes.ElementAt(i).Name == RemoveTextBox.Text)
                        pizzaSizes.Remove(pizzaSizes[i]);
            }

            // Reseting all the panel and creating it again from scratch
            ClearStackPanels();
            InitializeSizes();
            InitializeToppings();
        }

        // This method clears all the stackpanels and current price
        private void ClearStackPanels()
        {
            pizzaSizeStackPanel.Children.Clear();
            pizzaToppingStackPanel.Children.Clear();
            _currentPrice = 0;
            IncreaseTotalPrice(0);
        }
    }
}
