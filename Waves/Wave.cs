// Creating Ripples 
// To get the custom Colors I used Install-Package Colorful.Console

using System;
using System.Drawing;
using Consoles = Colorful.Console;

namespace Coloring_Matrix
{
  class Program
  {

    static int length = 25, width = 45;
    static int[,] display = new int[length, width];
    static int sRow = length / 2, sCol = width / 2, count = 0, moves = 0, iterate = 1;
    static void Main()
    {
      FillMatrix();
      for (uint i = 1; i <= 4; i++)
      {
        Console.Clear();
        PrintMatrix();
      }
        GetInput();
    }

    static void FillMatrix()
    {
      Random rnd = new Random(); double value = 0;
      double row = 0, col = 0;

      for (uint i = 1; i <= length * width / 4; i++)
      {
        row = (rnd.Next(0, length));
        col = (rnd.Next(0, width));
        display[(int)row, (int)col] = 1;
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
          //Console.BackgroundColor = ConsoleColor.Magenta;
          Console.Write("{0} ", ' ');
          Console.ResetColor();
          display[row, col] = 0;
        }
        else
        {
          if (display[row, col] == 0) // If position hasnt been moved to print space
          {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("{0} ", ' ');
            Console.ResetColor();
          }
          else if (display[row, col] == 1)
          {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write("{0} ", '1');
            Console.ResetColor();
            if ((row - 1 >= 0) || row + 1 <= length - 1)
            {
              if ((row - 1 > -1)     && (display[row - 1, col] == 0))
                display[row - 1, col] = 2;
              else if ((row + 1 < length) && (display[row + 1, col] == 0))
                display[row + 1, col] = 2;
            }
            if ((col - 1 >= 0) || col + 1 <= width - 1)
            {
              if ((col - 1 > -1) && (display[row, col - 1] == 0))
                display[row, col - 1] = 2;
              else if ((col + 1 < width) && (display[row, col + 1] == 0))
                display[row, col + 1] = 2;
            }
            // Adjacent squares
            //if (((col - 1 >= 0) && (row - 1 >= 0)) || (col + 1 <= width - 1) && (row + 1 <= length - 1))
            //{
            //  if (((col - 1 > -1) && (row - 1 > -1) && ((display[row, col - 1] == 0) && (display[row - 1, col] == 0))))
            //    display[row - 1, col - 1] = 2;
            //  else if (((row + 1 < length) && (col + 1 < width)) && ((display[row + 1, col] == 0) && (display[row, col + 1] == 0)))
            //    display[row + 1, col + 1] = 2;
            //}
          }
          else if (display[row, col] == 2)
          {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("{0} ", '2');
            Console.ResetColor();
            if ((row - 1 >= 0) || row + 1 <= length - 1)
            {
              if ((row - 1 > -1) && (display[row - 1, col] == 0))
                display[row - 1, col] = 3;
              if ((row + 1 < length) && (display[row + 1, col] == 0))
                display[row + 1, col] = 3;
            }
            if ((col - 1 >= 0) || col + 1 <= width - 1)
            {
              if ((col - 1 > -1) && (display[row, col - 1] == 0))
                display[row, col - 1] = 3;
              if ((col + 1 < width) && (display[row, col + 1] == 0))
                display[row, col + 1] = 3;
            }
          }
          else if (display[row, col] == 3)
          {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("{0} ", ' ');
            Console.ResetColor();
            if ((row - 1 >= 0) || row + 1 <= length - 1)
            {
              if ((row - 1 > -1) && (display[row - 1, col] == 0))
                display[row - 1, col] = 4;
              if ((row + 1 < length) && (display[row + 1, col] == 0))
                display[row + 1, col] = 4;
            }
            if ((col - 1 >= 0) || col + 1 <= width - 1)
            {
              if ((col - 1 > -1) && (display[row, col - 1] == 0))
                display[row, col - 1] = 4;
              if ((col + 1 < width) && (display[row, col + 1] == 0))
                display[row, col + 1] = 4;
            }
          }
          else if (display[row, col] == 4)
          {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("{0} ", ' ');
            Console.ResetColor();
          }
        }
        if (col == width - 1) { Console.ForegroundColor = ConsoleColor.Green; Console.Write("|"); }
        count++; col++;
        if (count % width == 0)
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
