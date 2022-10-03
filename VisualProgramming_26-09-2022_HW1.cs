namespace VisualProgramming_27_9_2022_HW1
{
    internal class Program
    {
        /// <summary>
        /// This method converts integer grade to a letter.
        /// <example>
        /// For example:
        /// <code>
        /// int userGrade = 95;
        /// string gradeAsLetter = gradeLetter(userGrade);
        /// </code>
        /// results in <c>gradeAsLetter</c> single letter that symbolize a grade (A).
        /// </example>
        /// </summary>
        /// <param name="userGrade">the integer that is going to be transformed to an grade as a letter.</param>
        /// <returns>
        /// Returns letter of the grade ( from 0 to 100 )
        /// Otherwise it'll return an error message ( ERROR ).
        /// </returns>
        static string gradeLetter(int userGrade)
        {
            const int A_MIN_GRADE = 90, B_MIN_GRADE = 80, C_MIN_GRADE = 70, D_MIN_GRADE = 60, F_MIN_GRADE = 0;

            if (userGrade >= A_MIN_GRADE)
                return "A";
            else if (userGrade >= B_MIN_GRADE)
                return "B";
            else if (userGrade >= C_MIN_GRADE)
                return "C";
            else if (userGrade >= D_MIN_GRADE)
                return "D";
            else if (userGrade >= F_MIN_GRADE)
                return "F";
            return "ERROR";
        }

        /// <summary>
        /// The <c>Main</c> function serves as the starting point for program execution. 
        /// </summary>
        static void Main()
        {

            const int MAX_GRADE = 100, MIN_BORDER = 0;
            int userGrade = 0, lowestGrade = 100, highestGrade = 0, studentCount = 0;
            double gradeAverage = 0;
            string? userData;
            bool pass;

            do
            {
                do
                {
                    pass = false;

                    Console.Write("Please enter a grade 0-100 or W: (enter a negative number to exit): ");
                    userData = Console.ReadLine();

                    // Geting correct grade from a user ( W(w) OR number from 0 to 100 )
                    if (userData != null)
                    {
                        if (userData == "W" || userData == "w")
                        {
                            studentCount++;
                            pass = true;
                            Console.WriteLine("Added grade W (Withdrawn).");
                        }
                        else
                        {
                            // Parsing int grade from a string
                            if (int.TryParse(userData, out int validated))
                            {
                                if (validated >= MIN_BORDER)
                                {
                                    if (validated <= MAX_GRADE)
                                    {
                                        pass = true;
                                        userGrade = validated;
                                        studentCount++;
                                        gradeAverage += userGrade;
                                    }
                                    else Console.WriteLine($"You've entered number that is higher than {MAX_GRADE}! Try again!");
                                } else
                                {
                                    pass = true;
                                    userGrade = validated;
                                }
                            }
                            else Console.WriteLine("You've entered an invalid number! Try again!");
                        }
                    }
                    else Console.WriteLine("You've entered an empty data! Try again!");
                } while (!pass);

                // If user still wants to enter a grade ( enters a positive value )
                if (userGrade >= MIN_BORDER)
                {
                    if (userData != "W" && userData != "w" )
                        Console.WriteLine($"Added grade {userGrade} ({gradeLetter(userGrade)}).");

                    // Set up minimal and maximal grades for a first user
                    if (studentCount == 1)
                    {
                        lowestGrade = userGrade;
                        highestGrade = userGrade;
                    }
                    else if (userGrade < lowestGrade)
                        lowestGrade = userGrade;
                    else if (userGrade > highestGrade)
                        highestGrade = userGrade;
                }
            } while (userGrade >= MIN_BORDER);

            // If there are no student grades entered
            if (studentCount == 0)
            {
                Console.WriteLine("\n\n\t ERROR. You did not enter any student grades!");
            }
            else
            {   
                //Counting average grade and transforming to a double number
                gradeAverage /= studentCount * 1.0;

                Console.WriteLine("Class stats");
                Console.WriteLine($"\t-\tLowest grade: {lowestGrade} ({gradeLetter(lowestGrade)}) ");
                Console.WriteLine($"\t-\tHighest grade: {highestGrade} ({gradeLetter(highestGrade)}) ");
                Console.WriteLine($"\t-\tClass Average: {gradeAverage}");
                Console.WriteLine($"\t-\tNumber of students: {studentCount}");
            }
            }

    }
}

//NOTE: There is bug, if you going to enter W first and after try to enter another grades minimal grade will be 0