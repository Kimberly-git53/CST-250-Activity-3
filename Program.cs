
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GreatestCommonDivisor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FindGCD();
        }
        // Function to find the GCD
        private static void FindGCD()
        {
            Console.WriteLine(" I will ask you for numbers in order to" +
                " calculate the greatest common divisor");
           

            // Loop until a valid integer is entered for first number
            while (true)
            {
                Console.WriteLine("Please enter the integers with a comma and space in between each one");
                string input = Console.ReadLine();

                string[] numberStrings = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                List<int> numberList = new List<int>();
                foreach (string numStr in numberStrings)
                {
                    // Check if the input is a valid integer
                    if (int.TryParse(numStr, out int number))
                    {
                        numberList.Add(number);
                    }
                    //Input invalid error handling
                    else
                    {
                        Console.WriteLine($" {numStr} is not a valid integer. Please try entering a valid integer.");
                        break;
                    }
                }
                // Check if the list has at least two numbers
                if (numberList.Count < 2)
                {
                    Console.WriteLine("Please enter at least two numbers to calculate the GCD.");
                    continue;
                }
                // Iterative approach speed test
                DateTime iterativeStart = DateTime.Now;
                // Iterative GCD of all numbers in the list
                int iterativeGCD = numberList[0];
                for (int i = 1; i < numberList.Count; i++)
                {
                    iterativeGCD = MultipleGCD(iterativeGCD, numberList[i]);
                }
                DateTime iterativeEnd = DateTime.Now;

                //Recursive approach speed test
                DateTime recursiveStart = DateTime.Now;
                // Recursive GCD for multiple numbers
                int recursiveGCD = numberList[0];
                for (int i = 1; i < numberList.Count; i++)
                {
                    recursiveGCD = GCDRecursive(recursiveGCD, numberList[i]);
                }
                DateTime recursiveEnd = DateTime.Now;

                // Output the GCD
                Console.WriteLine($"The GCD of the numbers is: {iterativeGCD} (iterative)");
                Console.WriteLine($"The GCD of the numbers is: {recursiveGCD} (recursive)");
                // Output the time taken for each approach
                Console.WriteLine($"Time taken for iterative approach: {iterativeEnd - iterativeStart} ms");
                Console.WriteLine($"Time taken for recursive approach: {recursiveEnd - recursiveStart} ms");
                break;
            }


            //Deactivated code to make the multiple GCD function work

            // Find divisors for both numbers
            //List<int> divisor1 = FindDivisors(number1);
            //List<int> divisor2 = FindDivisors(number2);

            //List<int> divisors = new List<int>();
            //for (int i = 1; i <= number; i++)
            //{
            //    if (number % i == 0)
            //    {
            //        divisors.Add(i);
            //    }
            //}
            //return divisors;



            // Output divisors
            //Console.WriteLine($"Divisors of {number1}: {string.Join(", ", divisor1)}");
            //Console.WriteLine($"Divisors of {number2}: {string.Join(", ", divisor2)}");

            // Find the GCD with iterations
            //int gcd = FindGCD(divisor1, divisor2);

            // Output the results for iteration
            //Console.WriteLine($"The GCD of {number1} and {number2} is {gcd} (Iteration).");

            // Call the GCD function
            //int answer = GCD(number1, number2);

            // Output the result in recursion
            //Console.WriteLine("The GCD of {0} and {1} is {2} (Recursion).", number1, number2, answer);
            //Console.ReadLine();
        }
        // Function to find the GCD using recursion
        private static int GCDRecursive(int number1, int number2)
        {
            // Check for zero values
            if (number1 == 0 && number2 == 0)
                return 0;
            // Base case
            if (number2 == 0)
                return number1;
            // Recursive case
            else
                Console.WriteLine("Not yet. {0} / {1} has a remainder of {2}", number1, number2, number1 % number2);
            return GCDRecursive(number2, number1 % number2);

        }

        // Function to find the GCD of multiple numbers using the iterative method
        private static int MultipleGCD(int number1, int number2)
        {
            // Check for zero values
            if (number1 == 0 || number2 == 0)
                return 0;
            // Base case
            while (number2 != 0)
            {
                int temp = number2;
                number2 = number1 % number2;
                number1 = temp;
            }
            return number1;
        }

        // Function to find the divisors of a number
        private static List<int> FindDivisors(int number1)
        {
            List<int> divisors = new List<int>();
            for (int i = 1; i <= number1; i++)
            {
                if (number1 % i == 0)
                {
                    divisors.Add(i);
                }
            }
            return divisors;
        }
        // Funstion to find GCD using iteration
        static int FindGCD(List<int> list1, List<int> list2)
        {
            int gcd = 1;
            foreach (int divisor1 in list1)
            {
                if (list2.Contains(divisor1) && divisor1 > gcd)

                    gcd = divisor1;
            }
            return gcd;
        }

        // Greatest Common Divisor function 
        private static int GCD(int number1, int number2)
        {
            if (number1 == 0 || number2 == 0)
                return 0;
            // Base case
            if (number2 == 0)
                return number1;
            // Recursive case
            else
                Console.WriteLine("Not yet. {0} / {1} has a remainder of {2}", number1, number2, number1 % number2);
            return GCD(number2, number1 % number2);
        }
    }
}
