using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodFillVisual
{
    internal class Board
    {
        public int Size;
        public Cell[,] Grid;

        public Board(int size)
        {
            this.Grid = new Cell[size, size];
            this.Size = size;
            CreateShapes();
        }
        private void CreateShapes()
        {
            // Initially fill the grid with empty cells
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Grid[i, j] = new Cell(i, j, "E");
                }
            }

            // Create three rectangles
            Random random = new Random();
            int rectangleSize = Size / 3;
            for (int i = 0; i < 5; i++)
            {
                // Upper left corner of rectangle
                int col = random.Next(Size - rectangleSize);
                int row = random.Next(Size - rectangleSize);
                // Vertical wall (left)
                for (int r = 0; r <= rectangleSize; r++)
                {
                    Grid[r + row, col] = new Cell(r + row, col, "W");
                }
                // Horizontal wall (top)
                for (int c = 0; c <= rectangleSize; c++)
                {
                    Grid[row, c + col] = new Cell(row, c + col, "W");
                }
                // Vertical wall (right)
                for (int r = 0; r <= rectangleSize; r++)
                {
                    Grid[r + row, col + rectangleSize] = new Cell(r + row, col + rectangleSize, "W");
                }
                // Horizontal wall (bottom)
                for (int c = 0; c <= rectangleSize; c++)
                {
                    Grid[row + rectangleSize, c + col] = new Cell(row + rectangleSize, c + col, "W");
                }
            }
        }
        public void FloodFill(int row, int col)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Filling at " + row + ", " + col + " ");
            Thread.Sleep(1000);

            if (row < 0 || row >= Size || col < 0 || col >= Size)
            {
                Console.WriteLine("Out of bounds. Stop"); // Out of bounds
                Thread.Sleep(1000);
                return;
            }
            // If the cell's color is a wall stop.
            if (Grid[row, col].Contents == "W")
            {
                Console.WriteLine("Bumped into a wall. Stop"); 
                Thread.Sleep(1000);
                return; // Wall
            }
            if (Grid[row, col].Contents == "F")
            {
                Console.WriteLine("Already filled. Stop"); 
                Thread.Sleep(1000);
                return; // Already filled
            }
            // Fill the cell
            Grid[row, col].Contents = "F";
            Thread.Sleep(1000);

            Console.Clear();
            Program.PrintBoard(this);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("East ");
            FloodFill(row, col + 1); // Right

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Northeast ");
            FloodFill(row - 1, col + 1); // Northeast

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("North ");
            FloodFill(row - 1, col); // Up

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Northwest ");
            FloodFill(row - 1, col - 1); // Northwest

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("South ");
            FloodFill(row + 1, col); // Down

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Southeast ");
            FloodFill(row + 1, col + 1); // Southeast

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("East ");
            FloodFill(row, col - 1); // Left

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Southwest ");
            FloodFill(row + 1, col - 1); // Southwest


        }
    }
}
