// Creating Ripples 
// To get the custom Colors I used Install-Package Colorful.Console

using System;
using System.Drawing;
using Consoles = Colorful.Console;

namespace Coloring_Matrix
{
  class Program
  {

    static int length = 25, width = 100;
    static int[,] display = new int[length, width];
    static int sRow = length / 2, sCol = width / 2, count = 0;
    static void Main()
    {
      FillMatrix();
      for (uint i = 1; i <= 4; i++)
      {
        DesignateMatrix();
      }
      Console.Clear();
      PrintMatrix();
      Console.ReadLine();
      //System.Threading.Thread.Sleep(2000);
    }

    static void FillMatrix()
    {
      // This picks random locations to start furthering the matrix levels. 
      Random rnd = new Random(); double row = 0, col = 0;

      for (uint i = 1; i <= length * width / 4; i++)
      {
        row = (rnd.Next(0, length));
        col = (rnd.Next(0, width));
        display[(int)row, (int)col] = 1;
      }

    }

    static void DesignateMatrix()
    {
      count = 0;
      int row = 0, col = 0;

      // For all elements in matrix print 
      foreach (int element in display)
      {
        if (col == 0)
        {
        }
        else
        {
          if (display[row, col] == 0) // If position hasnt been moved to print space
          {
            Consoles.BackgroundColor = Color.Orange;
            Console.Write(" ");
            Console.ResetColor();
          }
          else if (display[row, col] == 1)
          {
            if ((row - 1 >= 0) || row + 1 <= length - 1)
            {
              if ((row - 1 > -1) && (display[row - 1, col] == 0))
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
            if ((row - 1 >= 0) || row + 1 <= length - 1)
            {
              if ((row - 1 > -1) && (display[row - 1, col] == 0))
                display[row - 1, col] = 5;
              if ((row + 1 < length) && (display[row + 1, col] == 0))
                display[row + 1, col] = 5;
            }
            if ((col - 1 >= 0) || col + 1 <= width - 1)
            {
              if ((col - 1 > -1) && (display[row, col - 1] == 0))
                display[row, col - 1] = 5;
              if ((col + 1 < width) && (display[row, col + 1] == 0))
                display[row, col + 1] = 5;
            }
          }
          else if (display[row, col] == 5)
          {
            if ((row - 1 >= 0) || row + 1 <= length - 1)
            {
              if ((row - 1 > -1) && (display[row - 1, col] == 0))
                display[row - 1, col] = 6;
              if ((row + 1 < length) && (display[row + 1, col] == 0))
                display[row + 1, col] = 6;
            }
            if ((col - 1 >= 0) || col + 1 <= width - 1)
            {
              if ((col - 1 > -1) && (display[row, col - 1] == 0))
                display[row, col - 1] = 6;
              if ((col + 1 < width) && (display[row, col + 1] == 0))
                display[row, col + 1] = 6;
            }
          }
          else if (display[row, col] == 6)
          {
            if ((row - 1 >= 0) || row + 1 <= length - 1)
            {
              if ((row - 1 > -1) && (display[row - 1, col] == 0))
                display[row - 1, col] = 7;
              if ((row + 1 < length) && (display[row + 1, col] == 0))
                display[row + 1, col] = 7;
            }
            if ((col - 1 >= 0) || col + 1 <= width - 1)
            {
              if ((col - 1 > -1) && (display[row, col - 1] == 0))
                display[row, col - 1] = 7;
              if ((col + 1 < width) && (display[row, col + 1] == 0))
                display[row, col + 1] = 7;
            }
          }
        }
        count++; col++;
        if (count % width == 0)
        {
          Console.WriteLine();
          row++;
          count = 0;
          col = 0; } } }

    static void PrintMatrix()
    {
      count = 0;
      int row = 0, col = 0;
      Console.ForegroundColor = ConsoleColor.Green;

      // Top border
      for (uint i = 1; i <= width + 2; i++) Console.Write("-");
      Console.WriteLine();

      // For all elements in matrix print 
      foreach (int element in display)
      {
        if (col == 0)
        {
          Console.ForegroundColor = ConsoleColor.Green;
          Console.Write("|");
          Console.ResetColor();
        }
        else
        {
          if (display[row, col] == 0) // If position hasnt been moved to print space
          {
            Consoles.BackgroundColor = Color.Black;
            Console.Write(" ");
            Console.ResetColor();
          }
          else if (display[row, col] == 1)
          {
            Consoles.BackgroundColor = Color.FromArgb(15,50,50);
            Console.Write(" ");
            Console.ResetColor();
            if ((row - 1 >= 0) || row + 1 <= length - 1)
            {
              if ((row - 1 > -1) && (display[row - 1, col] == 0))
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
            Consoles.BackgroundColor = Color.FromArgb(15, 60, 60);
            Console.Write(" ");
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
            Consoles.BackgroundColor = Color.FromArgb(15, 70, 70);
            Console.Write(" ");
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
            Consoles.BackgroundColor = Color.FromArgb(15, 80, 80);
            Console.Write(" ");
            Console.ResetColor();
            if ((row - 1 >= 0) || row + 1 <= length - 1)
            {
              if ((row - 1 > -1) && (display[row - 1, col] == 0))
                display[row - 1, col] = 5;
              if ((row + 1 < length) && (display[row + 1, col] == 0))
                display[row + 1, col] = 5;
            }
            if ((col - 1 >= 0) || col + 1 <= width - 1)
            {
              if ((col - 1 > -1) && (display[row, col - 1] == 0))
                display[row, col - 1] = 5;
              if ((col + 1 < width) && (display[row, col + 1] == 0))
                display[row, col + 1] = 5;
            }
          }
          else if (display[row, col] == 5)
          {
            Consoles.BackgroundColor = Color.FromArgb(15, 90, 90);
            Console.Write(" ");
            Console.ResetColor();
            if ((row - 1 >= 0) || row + 1 <= length - 1)
            {
              if ((row - 1 > -1) && (display[row - 1, col] == 0))
                display[row - 1, col] = 6;
              if ((row + 1 < length) && (display[row + 1, col] == 0))
                display[row + 1, col] = 6;
            }
            if ((col - 1 >= 0) || col + 1 <= width - 1)
            {
              if ((col - 1 > -1) && (display[row, col - 1] == 0))
                display[row, col - 1] = 6;
              if ((col + 1 < width) && (display[row, col + 1] == 0))
                display[row, col + 1] = 6;
            }
          }
          else if (display[row, col] == 6)
          {
            Consoles.BackgroundColor = Color.FromArgb(15, 100, 100);
            Consoles.Write(" ",Color.Black);
            Console.ResetColor();
            if ((row - 1 >= 0) || row + 1 <= length - 1)
            {
              if ((row - 1 > -1) && (display[row - 1, col] == 0))
                display[row - 1, col] = 7;
              if ((row + 1 < length) && (display[row + 1, col] == 0))
                display[row + 1, col] = 7;
            }
            if ((col - 1 >= 0) || col + 1 <= width - 1)
            {
              if ((col - 1 > -1) && (display[row, col - 1] == 0))
                display[row, col - 1] = 7;
              if ((col + 1 < width) && (display[row, col + 1] == 0))
                display[row, col + 1] = 7;
            }
          }
          else if (display[row, col] == 7)
          {
            Consoles.BackgroundColor = Color.FromArgb(15, 110, 110);
            Consoles.Write(" ", Color.Black);
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
      for (uint i = 1; i <= width + 2; i++) Console.Write("-");
      Console.WriteLine();
    }
  }
}
