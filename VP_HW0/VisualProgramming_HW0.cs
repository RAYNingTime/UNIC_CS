namespace HMW1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MINIMAL_YEAR = 1900, MINIMAL_MONTH = 1, MINIMAL_DAY = 1;

            Console.Write("Enter your year of birth: ");
            string? userYear = Console.ReadLine();
            Console.Write("Enter your month of birth(1-12): ");
            string? userMonth = Console.ReadLine();
            Console.Write("Enter your day of birth: ");
            string? userDay = Console.ReadLine();

            DateTime nowDateTime = DateTime.Now;
            Console.WriteLine();

            int year = isValid(userYear);
            int month = isValid(userMonth);
            int day = isValid(userDay);

            if (day == -1 || month == -1 || year == -1)
            {
                Console.WriteLine("You've entered a string!");
            }
            else
            {
                //Checking Year for valid date
                if ((year < MINIMAL_YEAR || year > nowDateTime.Year) || (month < MINIMAL_MONTH || month > nowDateTime.Month) || (day < MINIMAL_DAY || day > nowDateTime.Day))
                {
                    Console.WriteLine("You've entered an invalid date!");
                }
                else
                {
                    DateTime userDate = new DateTime(year, month, day);

                    int differenceInDays = (nowDateTime - userDate).Days;
                    if (differenceInDays % 365 == 0)
                    {
                        Console.WriteLine("HAPPY BIRTHDAY!!!");
                    }
                    else
                    {
                        int userOld = differenceInDays / 365;
                        Console.WriteLine($"You are {userOld} years old");
                    }
                }
            }
        }
        public static int isValid(string stringForValid)
        {
            if (int.TryParse(stringForValid, out int validated))
            {
                return validated;
            }
            return -1;
        }
    }
}

/*
  
            bool repeat = true;
            do {
                string answer = Console.ReadLine();
                if (int.TryParse(answer, out int answerNumber))
                {
                    // Checking valid grade

                    if (answerNumber < 0)
                        repeat = false;
                }
                else
                {
                    Console.WriteLine("Invalid Integer");
                }



            } while (repeat); 

 */
