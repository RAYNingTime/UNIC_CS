using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamClass;

public class Exam
{
    public List<string> Question { get; set; }
    public List<string> Answer { get; set; }
    public List<string> IncorrectAnswer { get; set; }

    public Exam()
    {
        string[] questions = { "[1] What's Visual Programming's Course Code?" , "[2] How to create a Integer variable?", "[3] 2 + 2 = ?",
            "[4] Who created this app?", "[5] What is the grade for this app? (Only one correct answer)" };
        Question = new List<string>(questions);

        string[] correct = { "COMP-213", "int", "4", "Ivan Kosiakov", "A" };
        Answer = new List<string>(correct);

        string[] incorrect = { "COMP-111", "COMP-123", "PSY-100", "double", "string", "char", "1","2", "3",
            "Ivan Ivanou", "Ali Tayari", "Dmitry Apraksin", "B", "C", "F" };
        IncorrectAnswer = new List<string>(incorrect);
    }

    /*
    public int[] randomThreeAnswers(int maxAnswers = 3, int questionNumber = 0) {
    
        Random random = new Random();
        List<int> randomNumbers = new List<int>();

        randomNumbers.Add = random.Next(maxAnswers);

        foreach (int number in randomNumbers)
            number = number + questionNumber * maxAnswers;

        return { selectedAnsw, newSelectedAnsw, thirdSelectedAnsw};
    }
    */
}
