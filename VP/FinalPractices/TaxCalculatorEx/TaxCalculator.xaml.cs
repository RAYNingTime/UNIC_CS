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
    public partial class TaxCalculator : Window
    {
        public TaxCalculator()
        {
            InitializeComponent();
        }

        // All event catchers to update breakdown of taxes
        private void SalaryAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateInfo();
        }

        private void MonthlyRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateInfo();
        }

        private void AnnualRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateInfo();
        }

        private void Has13thMonthSalaryCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateInfo();
        }

        private void Has13thMonthSalaryCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateInfo();
        }

        /* Update Information function.
         * 
         * Function that is going to update all the fields of information in Annually 
         * and Monthly groups of labels
         **/
        private void UpdateInfo()
        {
            const double SOCIAL_INSURANCE = 0.0456, ANNUAL_TAX = 0.1, ANNUAL_TAX_MIN_AMOUNT = 25000;
            double annualSalary, socialInsuranceCoveredSalary, socialInsurance, taxForSalary = 0, netValueSalary;

            // By default there are 12 monthes
            int months = 12;

            if(!double.TryParse(SalaryAmountTextBox.Text, out double salaryAmount))
            {
                MessageBox.Show("Please enter a valid value for Salary Amount.", "Invalid Salary information", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } else if (salaryAmount < 0) { 
                MessageBox.Show("Please enter a positive value for Salary Amount.", "Invalid Salary information", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Checking if CheckBox of Has 13th Month Salary is checked
            if ((bool)Has13thMonthSalaryCheckBox.IsChecked)
                months = 13;

            if ((bool)AnnualRadioButton.IsChecked)
                annualSalary = salaryAmount;
            else
                annualSalary = salaryAmount * months;

            // Calculating social insurance
            socialInsurance = annualSalary * SOCIAL_INSURANCE;

            socialInsuranceCoveredSalary = annualSalary - socialInsurance;

            // Calculating the amount of tax ( Tax calculated only after 25000 )
            if (socialInsuranceCoveredSalary > ANNUAL_TAX_MIN_AMOUNT)
                taxForSalary = (socialInsuranceCoveredSalary - ANNUAL_TAX_MIN_AMOUNT) * ANNUAL_TAX;

            netValueSalary = socialInsuranceCoveredSalary - taxForSalary;

            // Annual Fields
            AnnualGrossLabel.Content = "$ " + annualSalary.ToString("N2"); 
            AnnualTaxLabel.Content = "$ " + taxForSalary.ToString("N2");
            AnnualSocialInsuranceLabel.Content = "$ " + socialInsurance.ToString("N2");
            AnnualNetLabel.Content = "$ " + netValueSalary.ToString("N2");

            // Monthly Fields
            MonthlyGrossLabel.Content = "$ " + (annualSalary / months).ToString("N2");
            MonthlyTaxLabel.Content = "$ " + (taxForSalary / months).ToString("N2");
            MonthlySocialInsuranceLabel.Content = "$ " + (socialInsurance / months).ToString("N2");
            MonthlyNetLabel.Content = "$ " + (netValueSalary / months).ToString("N2");
        }
    }
}
