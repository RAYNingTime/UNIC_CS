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

namespace Ali_s_Supermarket
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string supermarketItemError = GetSupermarketItemError();

            if (false == string.IsNullOrWhiteSpace(supermarketItemError))
            {
                MessageBox.Show(supermarketItemError, "Invalid Item", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SupermarketItem item = GetSupermarketItem();
            AddSupermarketItemToOrders(item);
        }

        private void AddSupermarketItemToOrders(SupermarketItem item)
        {
            Grid grid = new Grid();

            Label label = new Label();
            label.HorizontalAlignment = HorizontalAlignment.Left;

            if (item.UnitType == UnitType.Weight)
                label.Content = item.Name + $"  ($ {item.UnitPrice.ToString("N2")} / Kg)";
            else
                label.Content = item.Name + $"  ($ {item.UnitPrice.ToString("N2")} each)";

            TextBox textBox = new TextBox();
            textBox.HorizontalAlignment = HorizontalAlignment.Right;
            textBox.Width = 30;
            textBox.TextChanged += TextBox_TextChanged;
            textBox.Tag = item;

            grid.Children.Add(label);
            grid.Children.Add(textBox);

            ItemStackPanel.Children.Add(grid);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RecalculateThePrice();
        }

        private void RecalculateThePrice()
        {
            double total = 0;
            foreach (Grid grid in ItemStackPanel.Children)
            {
                TextBox textBox = grid.Children[1] as TextBox;
                SupermarketItem item = textBox.Tag as SupermarketItem;

                if (false == double.TryParse(textBox.Text, out double quantityOrWeight))
                    continue;

                if (item.UnitType == UnitType.Quantity)
                    if ((int)quantityOrWeight != quantityOrWeight)
                        continue;

                if (quantityOrWeight > 0)
                    total += quantityOrWeight * item.UnitPrice;
            }

            OrderLabel.Content = "Order ($ " + total.ToString("N2") + ")";
        }

        private string GetSupermarketItemError()
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
                errors.Add("Please enter a valid name.");

            if ((bool)!WeightRadioButton.IsChecked && (bool)!QuantityRadioButton.IsChecked)
                errors.Add("Please select Unit Type.");

            if (false == double.TryParse(PriceTextBox.Text, out double unitPrice))
                errors.Add("Please enter a valid number for unit price.");
            else if (unitPrice <= 0)
                errors.Add("Please enter a positive number for unit price.");

            string errorsCombined = null;

            if (errors.Count > 0)
                errorsCombined = string.Join(Environment.NewLine, errors);

            return errorsCombined;
        }

        private SupermarketItem GetSupermarketItem()
        {
            string name = NameTextBox.Text;

            UnitType unitType;
            if (true == WeightRadioButton.IsChecked)
                unitType = UnitType.Weight;
            else
                unitType = UnitType.Quantity;

            double unitPrice = double.Parse(PriceTextBox.Text);

            return new SupermarketItem(name, unitType, unitPrice);
        }

        private void PlaceOrderButton_Click(object sender, RoutedEventArgs e)
        {
            string ordersDescription = "";
            double total = 0;

            foreach (Grid grid in ItemStackPanel.Children)
            {
                TextBox textBox = grid.Children[1] as TextBox;
                SupermarketItem item = textBox.Tag as SupermarketItem;

                double quantityOrWeight = double.Parse(textBox.Text);

                if (item.UnitType == UnitType.Quantity)
                    if ((int)quantityOrWeight != quantityOrWeight)
                          continue;

                if (quantityOrWeight <= 0)
                    continue;

                double itemCost = quantityOrWeight * item.UnitPrice;
                total += itemCost;

                string quantityDescription = "";
                if (item.UnitType == UnitType.Quantity)
                    quantityDescription = $"{quantityOrWeight} x";
                else if (item.UnitType == UnitType.Weight)
                    quantityDescription = $"{quantityOrWeight} Kg";

                ordersDescription += $"[{quantityDescription}] {item.Name}  > $ {itemCost.ToString("N2")}" + Environment.NewLine;
            }

            if (total == 0)
                MessageBox.Show("Please enter quantity/weight for at least 1 item.", "No Item Selected", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                MessageBoxResult userChoice = MessageBox.Show($"Are you sure you want to place the following order for the grand total of ($ {total.ToString("N2")})" + Environment.NewLine
                                                                + Environment.NewLine
                                                                + ordersDescription
                                                                , "Order Confirmation"
                                                                , MessageBoxButton.YesNo
                                                                , MessageBoxImage.Information);

                if (userChoice == MessageBoxResult.Yes)
                    MessageBox.Show("Your order will be delievered shortly.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


    }
}
