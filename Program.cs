using System;


namespace ConsoleApplication1
{
    internal class Program
    {
        // Initialize step counter
        static int stepCounter = 0;

        // This is the main method
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an integer. I will do some math and eventually arrive at 1 ");
            int startingNumber = int.Parse(Console.ReadLine());
            int x = countToOne(startingNumber);
            stepCounter = 0;
            Console.ReadLine();
        }
        // This method will take an integer and return the number of steps it takes to reach 1
        private static int countToOne(int n)
        {
            stepCounter++;
            Console.Out.WriteLine("Step {0}: N is {1}", stepCounter, n);
            // Base case: if n is 1, return the step counter
            if (n == 1)
            {
                return 1;
            }
            // If n is divisible by 3, multiply by 4
            else if (n % 3 == 0)
            {
                Console.Out.WriteLine("N is divisible by 3. Multiplying by 4.");
                n = n * 4;

                return countToOne(n); 

            }
            // If n is even, divide by 2
            else if (n % 2 == 0)
            {
                Console.Out.WriteLine("N is even. Divide by 2.");
                n = n / 2;
                return countToOne(n);
            }
            // If n is odd, multiply by 3 and add 1
            else
            {
                Console.Out.WriteLine("N is odd. Multiply 3, Add 1");
                n = (3 * n + 1);

                return countToOne(n);
            }
        }
    }
}
