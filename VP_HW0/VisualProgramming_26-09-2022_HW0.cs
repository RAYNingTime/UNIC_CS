
namespace HMW1_1
{
    /// <summary>
    /// Class <c>Program</c> counts a birthday date of the user. It asks user to enter Year, Month and Day of his/her birthday. 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// This method converts string to an positive integer.
        /// <example>
        /// For example:
        /// <code>
        /// string userData = "15";
        /// int userInt = strToInt(userData);
        /// </code>
        /// results in <c>userInt</c> integer having the value that was in a string (15).
        /// </example>
        /// </summary>
        /// <param name="stringForValid">the string that is going to be transformed to an integer.</param>
        /// <returns>
        /// If parsing was successful it'll return an integer that was in a string.
        /// Otherwise it'll return "-1" that means unsuccessful operation and should be caught in error handling.
        /// </returns>
        public static int StrToInt(string stringForValid)
        {
            if (int.TryParse(stringForValid, out int validated))
                return validated;
            return -1;
        }

        /// <summary>
        /// This method checks integer to the corresponding minimal and maximal value.
        /// <example>
        /// For example:
        /// <code>
        /// int userData = 2000;
        /// const int MAX_YEAR = 2022;
        /// bool isValid = checkDate(userData, MAX_YEAR);
        /// </code>
        /// results in <c>isValid</c> boolean having the result of the check - true or false (true).
        /// </example>
        /// </summary>
        /// <param name="valueCheck">the integer that is going to be checked for a minimal and a maximal value.</param>
        /// <param name="max">the integer that is going to be a maximal value. </param>
        /// <param name="min">the integer that is going to be a minimal value. 
        /// If minimal value is not entered it will be set as "1" by the default. </param>
        /// <returns>
        /// If checking was successful and integer inside of range AND min value is less then max it'll return true.
        /// Otherwise it'll return false that means unsuccessful operation and should be caught in error handling.
        /// </returns>
        public static bool CheckDate(int valueCheck, int max, int min = 1)
        {
            if ((max < min) || (valueCheck > max || valueCheck < min))
                return false;
            return true;
        }

        /// <summary>
        /// This method gets <c>integer</c> data from a user for a special "name" (example: Year, Month, Day) of birth.
        /// <example>
        /// For example:
        /// <code>
        /// int userData = getData("year");
        /// </code>
        /// results in <c>userData</c> validated integer of the user input for a special requirement of a name.
        /// </example>
        /// </summary>
        /// <param name="name">the string that is going to be shown to a user to make a correct request of the data.</param>
        /// <returns>
        /// Returns correct integer value for a special requirement after the validation of it.
        /// </returns>
        public static int getData(string name)
        {
            do
            {
                Console.Write($"Enter your {name} of birth: ");
                string? userData = Console.ReadLine();
                if (userData != null)
                {
                    int userInt = StrToInt(userData);
                    if (userInt != -1)
                    {
                        return userInt;
                    }
                    else Console.WriteLine($"You've entered an invalid {name} number! Try again!");
                } else Console.WriteLine($"You've entered an empty {name}! Try again!");
            } while (true);
        }

        /// <summary>
        /// The <c>Main</c> function serves as the starting point for program execution. 
        /// </summary>
        static void Main()
        {
            // As I googled there are 365.242199 days in a year
            const double daysInYear = 365.242199;
            const int MINIMAL_YEAR = 1900, MAX_MONTH = 12;
            DateTime todayDateTime = DateTime.Today;
            bool repeat;
            int userYear, userMonth, userDay;

            //Infinite loop to get the correct input from a user without any incorrect or outOfRange values
            do
            {
                userYear = getData("year");
                repeat = CheckDate(userYear, todayDateTime.Year, MINIMAL_YEAR);
                if (repeat)
                {
                    userMonth = getData("month");
                    repeat = CheckDate(userMonth, MAX_MONTH);
                    if (repeat)
                    {
                        userDay = getData("day");
                        // Got DateTime.DaysInMonth from the documentation of the DateTime to avoid problems with manual counting
                        repeat = CheckDate(userDay, DateTime.DaysInMonth(userYear, userMonth));
                    }
                }
                Console.WriteLine($"You've entered value out of range! Try again!");
            } while (!repeat);

            var userDateTime = new DateTime(userYear, userMonth, userDay);

            // Counting age of the user by dividing total days between dates on 365.242199
            int userAge = (int)((todayDateTime - userDateTime).TotalDays / daysInYear);

            // Creating variable that going to contain birthday date in this year
            DateTime nextBirthday = new DateTime(todayDateTime.Year, userDateTime.Month, userDateTime.Day);

            // If birthday was earlier this year I add one extra year to count days
            if (nextBirthday < todayDateTime)
                nextBirthday = nextBirthday.AddYears(1);

            var nextBirthdayInDays = (nextBirthday - todayDateTime).Days;

            // Checking if birthday is today, if no then show days
            if (nextBirthdayInDays == 0)
                Console.WriteLine($"Happy birthday! You're {userAge} years old!");
            else
                Console.WriteLine($"You're {userAge} years old. Your next birthday will be in {nextBirthdayInDays} days!");
        }
    }
}

// NOTE #1: This code fails If user enteres this year and months/day that will be later than current date
// NOTE #2: If user enteres current date AND prev. year same date it'll send him "Happy Birthday for 0 years"

