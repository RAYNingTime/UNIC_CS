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

/** Work made on 11.10.2022
* By Ivan Kosiakov
* ID: U214N1534
*
* Description: This is a pizza calculator.
* You can select size of the pizza and toppings
* and the app will show you a price.
*/

namespace VP_09_10_HW2
{
    public partial class MainWindow : Window
    {
        // Prices for different sizes of pizza
        const double SMALL_SIZE = 5.00, MEDIUM_SIZE = 6.25, LARGE_SIZE = 7.75;
        // Price for different Toppings is the same
        const double TOPPINGS = 0.5;

        // Check statuses from every Checkbox & Radio button
        bool smallChecked = false, mediumChecked = false, largeChecked = false, 
            onionChecked = false, tomatoChecked = false, pepperChecked = false; 

        double totalPrice = 0;
        public MainWindow()
        {
            InitializeComponent();
            TotalPrice.Text = totalPrice.ToString();
        }

        private void OptionChanged(object sender, RoutedEventArgs e)
        {
            // Small pizza size check
            if ((bool)SmallPizza.IsChecked && !smallChecked)
            {
                totalPrice += SMALL_SIZE;
                smallChecked = true;
            } else if (!(bool)SmallPizza.IsChecked && smallChecked) {
                totalPrice -= SMALL_SIZE;
                smallChecked = false;
            }

            // Medium pizza size check
            if ((bool)MediumPizza.IsChecked && !mediumChecked)
            {
                totalPrice += MEDIUM_SIZE;
                mediumChecked = true;
            } else if (!(bool)MediumPizza.IsChecked && mediumChecked) {
                totalPrice -= MEDIUM_SIZE;
                mediumChecked = false;
            }

            // Large pizza size check
            if ((bool)LargePizza.IsChecked && !largeChecked)
            {
                totalPrice += LARGE_SIZE;
                largeChecked = true;
            } else if (!(bool)LargePizza.IsChecked && largeChecked) {
                totalPrice -= LARGE_SIZE;
                largeChecked = false;
            }

            // <--- All toppings checks --->
            // Tomato check
            if ((bool)TomatoTopping.IsChecked && !tomatoChecked)
            {
                totalPrice += TOPPINGS;
                tomatoChecked = true;
            }
            else if (!(bool)TomatoTopping.IsChecked && tomatoChecked) {
                totalPrice -= TOPPINGS;
                tomatoChecked = false;
            }
            
            // Onion check
            if ((bool)OnionTopping.IsChecked && !onionChecked)
            {
                totalPrice += TOPPINGS;
                onionChecked = true;
            } else if (!(bool)OnionTopping.IsChecked && onionChecked) {
                totalPrice -= TOPPINGS;
                onionChecked = false;
            }

            // Pepper check
            if ((bool)PepperTopping.IsChecked && !pepperChecked)
            {
                totalPrice += TOPPINGS;
                pepperChecked = true;
            } else if (!(bool)PepperTopping.IsChecked && pepperChecked){
                totalPrice -= TOPPINGS;
                pepperChecked = false;
            }

            TotalPrice.Text = totalPrice.ToString();
        }
    }
}
