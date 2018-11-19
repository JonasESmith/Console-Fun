// Recreate snake 

using System;
using System.Drawing;
using Consoles = Colorful.Console;

namespace Simple_Graphic
{
  class Program
  {
    static int length = 15, width = 15;
    static int[,] display = new int[width, length];
    static int sRow = length / 2, sCol = width / 2, count = 0, moves = 0, iterate = length * 2 + 2;
    static int fRow, fCol;
    static double distance = 0;
    static bool death = false;
    static void Main()
    {
      SpawnFood();
      do
      {
        Console.Clear();
        CheckDistance();
        PrintMatrix();
        AiInput();
        //GetInput();
        CheckGrowth(); // Checks death really 
      } while (death == false);
    }

    static void SpawnFood()
    {
      Random rnd = new Random(); double row = 0, col = 0;
      row = (rnd.Next(0, length)); fRow = (int)row;
      col = (rnd.Next(0, width)); fCol = (int)col;
      display[(int)row, (int)col] = 8;
    }
    static void CheckGrowth()
    {
      if (moves >= iterate)
        death = true;
    }
    static void PrintMatrix()
    {
      int row = 0, col = 0;
      for (uint i = 1; i <= width * 2 + 2; i++) Console.Write("-");
      Console.WriteLine();

      foreach (int element in display)
      {
        if (col == 0)
          Console.Write("|");

        if ((sRow == row) && (sCol == col))
        {
          Consoles.BackgroundColor = Color.FromArgb(250, 100, 30);
          Console.Write("{0} ", ' ');
          display[row, col] = 4;
        }
        else
        {
          if (display[row, col] == 0)
          {
            Consoles.BackgroundColor = Color.Black;
            Console.Write("  ");
            Console.ResetColor();
          }
          else if (display[row, col] == 4)
          {
            Consoles.BackgroundColor = Color.FromArgb(220, 100, 30);
            Console.Write("  ");
            Console.ResetColor();
            display[row, col] = 3;
          }
          else if (display[row, col] == 3)
          {
            Consoles.BackgroundColor = Color.FromArgb(200, 100, 30);
            Console.Write("  ");
            Console.ResetColor();
            display[row, col] = 2;
          }
          else if (display[row, col] == 2)
          {
            Consoles.BackgroundColor = Color.FromArgb(180, 100, 30);
            Console.Write("  ");
            Console.ResetColor();
            display[row, col] = 1;
          }
          else if (display[row, col] == 1)
          {
            Consoles.BackgroundColor = Color.FromArgb(160, 100, 30);
            Console.Write("  ");
            Console.ResetColor();
            display[row, col] = 0;
          }
          else if (display[row, col] == 8)
          {
            Consoles.BackgroundColor = Color.FromArgb(250, 10, 70);
            Console.Write("  ");
            Console.ResetColor();
          }
        }
        if (display[sRow, sCol] == 8)
        {
          display[sRow, sCol] = 4;
          SpawnFood();
          moves = (iterate / 4);
        }
        if (col == length - 1) Console.Write("|");
        count++; col++;
        if (count % length == 0)
        {
          Console.WriteLine();
          row++;
          count = 0;
          col = 0;
        }
      }
      Console.BackgroundColor = ConsoleColor.DarkMagenta;
      for (uint i = 1; i <= width * 2 + 2; i++) Console.Write("-");
      Console.ResetColor(); Console.WriteLine();
    }

    static void CheckDistance()
    {
      // This wil show the difference between the players head point and the food
      distance = Math.Sqrt(Math.Pow((sRow - fRow), 2) + Math.Pow((sCol - fCol), 2));
    }
    static void AiInput()
    {
      // Four temporary distances
      // distance 1 = move up.
      // distance 2 = move down.
      // distance 3 = move right.
      // distance 4 = move left.
      double upDistance = Math.Sqrt(Math.Pow(((sRow - 1) - fRow), 2) + Math.Pow((sCol - fCol), 2));
      double downDistance = Math.Sqrt(Math.Pow(((sRow + 1) - fRow), 2) + Math.Pow((sCol - fCol), 2));
      double leftDistance = Math.Sqrt(Math.Pow((sRow - fRow), 2) + Math.Pow(((sCol - 1) - fCol), 2));
      double rightDistance = Math.Sqrt(Math.Pow((sRow - fRow), 2) + Math.Pow(((sCol + 1) - fCol), 2));

      if (upDistance < distance)
      {
        sRow--;
        if (sRow < 0)
          sRow = length - 1;
      }
      else if (downDistance < distance)
      {
        sRow++;
        if (sRow > length - 1)
          sRow = 0;
      }
      else if (leftDistance < distance)
      {
        sCol--;
        if (sCol < 0)
          sCol = width - 1;
      }
      else if (rightDistance < distance)
      {
        sCol++;
        if (sCol > width - 1) // right arrow 
          sCol = 0;
      }
      moves++;
      System.Threading.Thread.Sleep(1000); // waits exactly 1 second between moves 
    }

    // User inputs 
    static void GetInput()
    {
      bool userValue = true;

      Console.WriteLine(" Distance to food : {0:f2}", distance);
      Console.WriteLine(" Moves :{0}/{1}", moves, iterate);
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
