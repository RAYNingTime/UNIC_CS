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

namespace FinalPractisesVP
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

        private void ShoppingListOpenButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            ShoppingList shoppingList = new ShoppingList();
            shoppingList.ShowDialog();

            Show();
        }

        private void TaxCalculatorOpenButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            TaxCalculator taxCalculator = new TaxCalculator();
            taxCalculator.ShowDialog();

            Show();
        }

        private void HouseCustomizerOpenButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            HouseCustomizer houseCustomizer = new HouseCustomizer();
            houseCustomizer.ShowDialog();

            Show();
        }
    }
}
