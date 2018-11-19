// Creating simple fully colored simbles 

using System;

namespace Coloring_Matrix
{
  class Coloring
  {

    static int length = 10, width = 10;
    static int[,] display = new int[width, length];
    static int sRow = length / 2, sCol = width / 2, count = 0, moves = 0, iterate = 100;
    static void Main()
    {
      FillMatrix();
      do
      {
        Console.Clear();
        PrintMatrix();
        GetInput();
      } while (moves <= iterate);
    }

    static void FillMatrix()
    {
      Random rnd = new Random(); double value = 0;
      int row = 0, col = 0;
      foreach (int square in display)
      {
        value = rnd.NextDouble();
        if (value < 0.25)
          display[row, col] = 1;
        else if (value < 0.5)
          display[row, col] = 2;
        else if (value < 0.75)
          display[row, col] = 3;
        else
          display[row, col] = 4;
        col++; count++;
        if (count % length == 0)
        {
          row++;
          count = 0;
          col = 0;
        }
      }


    }

    static void PrintMatrix()
    {
      count = 0; 
      int row = 0, col = 0;
      Console.ForegroundColor = ConsoleColor.Green;

      // Top border
      for (uint i = 1; i <= width * 2 + 2; i++) Console.Write("-");
      Console.WriteLine();

      // For all elements in matrix print 
      foreach (int element in display)
      {
        if (col == 0)
          Console.Write("|");

        if ((sRow == row) && (sCol == col)) // Write current position
        {
          Console.BackgroundColor = ConsoleColor.Magenta;
          Console.Write("{0} ", ' ');
          Console.ResetColor();
          display[row, col] = 8;
        }
        else
        {
          if (display[row, col] == 8) // If position hasnt been moved to print space
          {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write("{0} ", ' ');
            Console.ResetColor();
          }
          else if (display[row, col] == 1) // Position has been traveled to 
          {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write("{0} ", ' ');
            Console.ResetColor();
          }
          else if (display[row, col] == 2) // Position has been traveled to 
          {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("{0} ", ' ');
            Console.ResetColor();
          }
          else if (display[row, col] == 3) // Position has been traveled to 
          {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("{0} ", ' ');
            Console.ResetColor();
          }
          else if (display[row, col] == 4) // Position has been traveled to 
          {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("{0} ", ' ');
            Console.ResetColor();
          }
        }
        if (col == length - 1) { Console.ForegroundColor = ConsoleColor.Green; Console.Write("|"); }
        count++; col++;
        if (count % length == 0)
        {
          Console.WriteLine();
          row++;
          count = 0;
          col = 0;
        }
      }

      // Bottom border
      for (uint i = 1; i <= width * 2 + 2; i++) Console.Write("-");
      Console.WriteLine();
    }
    static void GetInput()
    {
      bool userValue = true;
      Console.WriteLine("press an arrow key to move the * in a direction | Moves :{0}/{1}", moves, iterate);
      var userInput = Console.ReadKey(true).Key;

      do
      {
        switch (userInput)
        {
          case ConsoleKey.RightArrow:
            sCol++;
            if (sCol > length - 1)
              sCol = 0;
            userValue = false;
            break;

          case ConsoleKey.LeftArrow:
            sCol--;
            if (sCol < 0)
              sCol = length - 1;
            userValue = false;
            break;

          case ConsoleKey.DownArrow:
            sRow++;
            if (sRow > width - 1)
              sRow = 0;
            userValue = false;
            break;

          case ConsoleKey.UpArrow:
            sRow--;
            if (sRow < 0)
              sRow = width - 1;
            userValue = false;
            break;

          default:
            userValue = false;
            GetInput();
            break;
        }
      } while (userValue == true);
      moves++;
    }
  }
}
