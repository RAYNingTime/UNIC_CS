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
        int questionCounter = 0, scoreCounter = 0, incorrectCounter = 0;
        Exam exam;


        // Arrays of the questions and answers
        string[] questions = { "[1] What's Visual Programming's Course Code?" , "[2] How to create a Integer variable?", "[3] 2 + 2 = ?",
            "[4] Who created this app?", "[5] What is the grade for this app? (Only one correct answer)" };

        string[] correct = { "COMP-213", "int", "4", "Ivan Kosiakov", "A" };

        string[] incorrect = { "COMP-111", "COMP-123", "PSY-100", "double", "string", "char", "1","2", "3",
            "Ivan Ivanou", "Ali Tayari", "Dmitry Apraksin", "B", "C", "F" };

        

        public MainWindow()
        {
            InitializeComponent();
            string[] incorrectAnswers = { incorrect[incorrectCounter++], incorrect[incorrectCounter++], incorrect[incorrectCounter++] };
            exam = new Exam(questions[questionCounter], correct[questionCounter], incorrectAnswers);

            // Default and the most first question
            SetupQuestions(exam);
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            switch (questionCounter++)
            {
                case 0:
                    {
                        if (CheckAnswer(exam))
                            scoreCounter++;

                        // Getting data from the arrays and inserting it to the class
                        string[] incorrectAnswers = { incorrect[incorrectCounter++], incorrect[incorrectCounter++], incorrect[incorrectCounter++] };
                        exam = new Exam(questions[questionCounter], correct[questionCounter], incorrectAnswers);

                        // Setting up a second question
                        SetupQuestions(exam);
                        break;
                    }

                case 1:
                    {
                        if (CheckAnswer(exam))
                            scoreCounter++;

                        // Getting data from the arrays and inserting it to the class
                        string[] incorrectAnswers = { incorrect[incorrectCounter++], incorrect[incorrectCounter++], incorrect[incorrectCounter++] };
                        exam = new Exam(questions[questionCounter], correct[questionCounter], incorrectAnswers);

                        // Setting up a second question
                        SetupQuestions(exam);
                        break;
                    }

                case 2:
                    {
                        if (CheckAnswer(exam))
                            scoreCounter++;

                        // Getting data from the arrays and inserting it to the class
                        string[] incorrectAnswers = { incorrect[incorrectCounter++], incorrect[incorrectCounter++], incorrect[incorrectCounter++] };
                        exam = new Exam(questions[questionCounter], correct[questionCounter], incorrectAnswers);

                        // Setting up a second question
                        SetupQuestions(exam);
                        break;
                    }

                case 3:
                    {
                        if (CheckAnswer(exam))
                            scoreCounter++;

                        // Getting data from the arrays and inserting it to the class
                        string[] incorrectAnswers = { incorrect[incorrectCounter++], incorrect[incorrectCounter++], incorrect[incorrectCounter++] };
                        exam = new Exam(questions[questionCounter], correct[questionCounter], incorrectAnswers);

                        // Setting up a second question
                        SetupQuestions(exam);
                        break;
                    }

                case 4:
                    {
                        if (CheckAnswer(exam))
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

        // This method setups the question textBlock and the answers buttons
        public void SetupQuestions(Exam exam)
        {
            int _numberOfAnswer = 0;

            questionBlock.Text = exam.Question;
            firstButton.Content = exam.AnswerPool[_numberOfAnswer++];
            secondButton.Content = exam.AnswerPool[_numberOfAnswer++];
            thirdButton.Content = exam.AnswerPool[_numberOfAnswer++];
            fourthButton.Content = exam.AnswerPool[_numberOfAnswer++];
        }

        // This method checks if there are a correct answer
        public bool CheckAnswer(Exam exam)
        {
            // IsChecked is initially bool?, so I changed it to the bool manualy
            if ((bool)firstButton.IsChecked && firstButton.Content.ToString() == exam.CorrectAnswer)
                return true;
            else if ((bool)secondButton.IsChecked && secondButton.Content.ToString() == exam.CorrectAnswer)
                return true;
            else if ((bool)thirdButton.IsChecked && thirdButton.Content.ToString() == exam.CorrectAnswer)
                return true;
            else if ((bool)fourthButton.IsChecked && fourthButton.Content.ToString() == exam.CorrectAnswer)
                return true;

            // If nothing of above => Answer is not correct
            return false;
        }
    }
}
