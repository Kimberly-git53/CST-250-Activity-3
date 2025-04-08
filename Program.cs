using System;
namespace Factorial
{


    class Program
    {
        // Initialize step counter
        static int stepCounter = 0;

        // This program calculates the factorial of a non-negative integer using recursion.
        static void Main(string[] args)
        {   
            
            stepCounter = 0;
           
            
                // Validate input needs to be a non-negative integer
                while (true)
                {
                        Console.WriteLine("Enter a integer to calculate its factorial:");
                        int number = int.Parse(Console.ReadLine());

                    // Input is valid
                     if (number < 0)
                     {
                        Console.WriteLine("Factorial is not defined for negative numbers. Please try again.");
                        number = int.Parse(Console.ReadLine());
                     }
                
               

                    // Recursive approach
                    DateTime recursiveStart = DateTime.Now;
                    Factorial(number);
                    DateTime recursiveEnd = DateTime.Now;

                    // Iterative approach
                    DateTime iterativeStart = DateTime.Now;
                    IterativeFactorial(number);
                    DateTime iterativeEnd = DateTime.Now;

                    // Print results
                    Console.WriteLine($"Recursive Factorial of {number} is: {Factorial(number)}");
                    Console.WriteLine($"Iterative Factorial of {number} is: {IterativeFactorial(number)}");

                    Console.WriteLine($"Time taken for {number} iterations of recursion: " +
                        $"{(recursiveEnd - recursiveStart).TotalMilliseconds} ms");
                    Console.WriteLine($"Time taken for {number} iterations of iteration: " +
                        $"{(iterativeEnd - iterativeStart).TotalMilliseconds} ms");
                    
                }
            
            // Recursive factorial method
            static long Factorial(int n)
            {
                // Increment step counter
                stepCounter++;
                Console.WriteLine("Step {0}: n is {1}", stepCounter, n);
                // Base case
                if (n == 0 || n == 1)
                { return 1; }
                // Recursive case
                return n * Factorial(n - 1);
            }
            // Iterative factorial method
            static long IterativeFactorial(int n)
            {
                long result = 1;
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }
                return result;

            }

        }
    }
}
