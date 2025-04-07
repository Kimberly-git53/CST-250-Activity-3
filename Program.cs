
namespace FloodFillVisual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowBoard();
        }


        private static void ShowBoard()
        {
            Board board = new Board(20);
            PrintBoard(board);

            Console.WriteLine("What row would you like to start with?");
            int startRow = int.Parse(Console.ReadLine());

            Console.WriteLine("What column would you like to start with?");
            int startCol = int.Parse(Console.ReadLine());

            board.FloodFill(startRow, startCol);

            Console.WriteLine("\nAfter Flood Fill:");
            PrintBoard(board);
        }
        public static void PrintBoard(Board board)
        {
            Console.WriteLine();
            //Print the comlumn numbers
            Console.Write("  ");
            for (int i = 0; i < board.Size; i++)
            {
                Console.Write($"{i,2}");
            }
            Console.WriteLine();
            for (int i = 0; i < board.Size; i++)
            {
                Console.Write($"{i,2}");

                for (int j = 0; j < board.Size; j++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    if ((board.Grid[i, j].Contents == "W"))
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        
                        Console.Write(" X");
                    }
                    else if (board.Grid[i, j].Contents == "E")
                    {
                        
                        Console.Write(" ?");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        
                        Console.Write(" .");
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    
                }
                Console.WriteLine();
            }

        }
    }
}
