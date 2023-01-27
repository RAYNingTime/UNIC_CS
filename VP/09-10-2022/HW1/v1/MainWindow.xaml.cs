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
using ExamClass;

namespace VP_09_10_HW1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int MAX_QUESTION = 5;
        Exam exam = new Exam();

        int questionCounter = 0, scoreCounter = 0,incorrectCounter = 0;

        public MainWindow()
        {
            InitializeComponent();

            // Default and the most first question
            questionBlock.Text = exam.Question[questionCounter];
            firstButton.Content = exam.IncorrectAnswer[incorrectCounter++];
            secondButton.Content = exam.Answer[questionCounter];
            thirdButton.Content = exam.IncorrectAnswer[incorrectCounter++];
            fourthButton.Content = exam.IncorrectAnswer[incorrectCounter++];
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            switch (questionCounter++)
            {
                case 0:
                    {
                        if ((bool)secondButton.IsChecked)
                            scoreCounter++;

                        // Setting up a second question
                        questionBlock.Text = exam.Question[questionCounter];
                        firstButton.Content = exam.Answer[questionCounter];
                        secondButton.Content = exam.IncorrectAnswer[incorrectCounter++];
                        thirdButton.Content = exam.IncorrectAnswer[incorrectCounter++];
                        fourthButton.Content = exam.IncorrectAnswer[incorrectCounter++];
                        break;
                    }

                case 1:
                    {
                        if ((bool)firstButton.IsChecked)
                            scoreCounter++;

                        // Setting up a third question
                        questionBlock.Text = exam.Question[questionCounter];
                        firstButton.Content = exam.IncorrectAnswer[incorrectCounter++];
                        secondButton.Content = exam.IncorrectAnswer[incorrectCounter++];
                        thirdButton.Content = exam.IncorrectAnswer[incorrectCounter++];
                        fourthButton.Content = exam.Answer[questionCounter];
                        break;
                    }

                case 2:
                    {
                        if ((bool)fourthButton.IsChecked)
                            scoreCounter++;

                        // Setting up a fourth question
                        questionBlock.Text = exam.Question[questionCounter];
                        firstButton.Content = exam.IncorrectAnswer[incorrectCounter++];
                        secondButton.Content = exam.IncorrectAnswer[incorrectCounter++];
                        thirdButton.Content = exam.Answer[questionCounter];
                        fourthButton.Content = exam.IncorrectAnswer[incorrectCounter++];
                        break;
                    }

                case 3:
                    {
                        if ((bool)thirdButton.IsChecked)
                            scoreCounter++;

                        // Setting up a fifth question
                        questionBlock.Text = exam.Question[questionCounter];
                        firstButton.Content = exam.IncorrectAnswer[incorrectCounter++];
                        secondButton.Content = exam.IncorrectAnswer[incorrectCounter++];
                        thirdButton.Content = exam.Answer[questionCounter];
                        fourthButton.Content = exam.IncorrectAnswer[incorrectCounter++];
                        break;
                    }

                case 4:
                    {
                        if ((bool)thirdButton.IsChecked)
                            scoreCounter++;

                        // Hiding all the parts of the Window to show a final result
                        mainGrid.Visibility = Visibility.Hidden;

                        // Showing a final result
                        finalScore.Visibility = Visibility.Visible;
                        finalScore.Text = "Your final score: " + scoreCounter + "/" + MAX_QUESTION;
                        break;
                    }
            }

        }
    }
}
