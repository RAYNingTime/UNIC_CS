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
    public partial class HouseCustomizer : Window
    {
        public HouseCustomizer()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

            if (!int.TryParse(NumberOfBedroomsTextBox.Text, out int amountOfBedrooms))
            {
                MessageBox.Show("Please enter a valid value for Number of Bedrooms.", "Invalid amount of bedrooms", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (amountOfBedrooms < 0)
            {
                MessageBox.Show("Please enter a positive value for Number of Bedrooms.", "Invalid amount of bedrooms", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } else if (!((bool)RedColorRadioButton.IsChecked || (bool)GreenColorRadioButton.IsChecked || (bool)BlueColorRadioButton.IsChecked))
            {
                MessageBox.Show("Please select a color of the walls.", "Select color of walls.", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            String outputMessage = "Please confirm your order for a house: ";

            // Select Color of the Walls
            if ((bool)RedColorRadioButton.IsChecked)
                outputMessage += "Red Walls ";
            else if ((bool)GreenColorRadioButton.IsChecked)
                outputMessage += "Green Walls ";
            else if ((bool)BlueColorRadioButton.IsChecked)
                outputMessage += "Blue Walls ";

            // Select Amount of Bedrooms
            outputMessage += "and " + NumberOfBedroomsTextBox.Text + " bedrooms";

            // Select Options
            if ((bool)SwimmingPoolCheckBox.IsChecked || (bool)SolarRoofCheckBox.IsChecked || (bool)GardenCheckBox.IsChecked)
            {
                outputMessage += " with following options: ";

                if ((bool)SwimmingPoolCheckBox.IsChecked)
                    outputMessage += " Swimming Pool";

                if ((bool)SolarRoofCheckBox.IsChecked)
                    outputMessage += " Solar Roof";

                if ((bool)GardenCheckBox.IsChecked)
                    outputMessage += " Garden";
            }

            outputMessage += ".";

            // Output message creation
            var userChoice = MessageBox.Show(outputMessage, "Order", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (userChoice == MessageBoxResult.Yes)
                MessageBox.Show("Thank you for your order!", "Order Placed", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
