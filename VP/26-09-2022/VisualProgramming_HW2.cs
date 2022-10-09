using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using System.Xml;
using System;

namespace VisualProgramming_27_9_2022_HW2
{
    /// <summary>
    /// Class <c>Program</c> asks the user to play a number-guessing game
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The <c>Main</c> function serves as the starting point for program execution. 
        /// </summary>
        static void Main()
        {
            // To check the code there is option to see a random result
            const bool VISIBLE_RESULT = false;

            const int MIN = 1, MAX = 9, GUESS_SIZE = 4;
            Random rnd = new Random();
            bool isUnique, found, win;
            string userAnswer;
            int[] correctAnswer = new int[GUESS_SIZE];
            int suggestedDigit;

            // Catching errors with constants sizes
            if (GUESS_SIZE > MAX || MIN > MAX || MIN > GUESS_SIZE)
            {
                Console.WriteLine("\n\n\nERROR. INCORRECT CONST SETTINGS!!!\n\n\n");
                throw new System.Exception("Incorrect content of constants.");
            }
            
            // Preparing correct preset
            for (int i = 0; i < GUESS_SIZE; i++)
            {
                isUnique = true;
                suggestedDigit = rnd.Next(MIN, MAX + 1);
                for (int j = 0; j < i; j++)
                {
                    if (correctAnswer[j] == suggestedDigit)
                        isUnique = false;
                }

                // If number is not unique decreases "i" by one
                if (!isUnique)
                    i--;
                else correctAnswer[i] = suggestedDigit;
            }

            // To show correct combination of code activate VISIBLE_RESULT
            if (VISIBLE_RESULT)
            {
                for(int i = 0; i < GUESS_SIZE; i++)
                {
                    Console.Write($"{correctAnswer[i]} ");
                }
                Console.WriteLine();
            }


            // Loop to guess a correct answer
            Console.WriteLine($"Try to guess the secret {GUESS_SIZE}-digit number:");
            userAnswer = Console.ReadLine();

            do
            {
                win = true;

                for (int i = 0; i < GUESS_SIZE; i++)
                {
                    found = false;
                    // One by one trying to parse string numbers by .Split function
                    if (int.TryParse(userAnswer.Split(" ")[i], out int number))
                    {
                        if (number == correctAnswer[i])
                            Console.Write("+ ");
                        else
                        {
                            // If number was not in the spot of "i" => This guess incorrect
                            for (int j = 0; j < GUESS_SIZE; j++)
                            {
                                win = false;
                                if (number == correctAnswer[j])
                                {
                                    Console.Write("X ");
                                    found = true;
                                    break;
                                }
                            }
                            if (!found) Console.Write("- ");
                        }
                    }
                }

                if(!win)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Try again:");
                    userAnswer = Console.ReadLine();
                }
            } while (!win);

            Console.WriteLine("\nYou won!");
        }
    }
}
