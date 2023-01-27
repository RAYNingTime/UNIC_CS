using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ExamClass;

public class Exam
{
    public string Question { get; set; }
    public string CorrectAnswer { get; set; }
    public string[] AnswerPool { get; set; }

    public Exam(string question, string answer, string[] incorrectAnswers)
    {
        Random random = new Random();
        int i;

        Question = question;

        CorrectAnswer = answer;

        // Collapsing two arrays to one, so it'll put one correct answer between incorrect onces
        string[] tempArray = incorrectAnswers;
        string[] newArr = new string[incorrectAnswers.Length + 1];
        for (i = 0; i < tempArray.Length; i++)
            newArr[i] = tempArray[i];
        newArr[i] = answer;

        AnswerPool = newArr;

        // Shuffle of the array
        AnswerPool = AnswerPool.OrderBy(x => random.Next()).ToArray();
    }
}
