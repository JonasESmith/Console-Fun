// Recreate snake with AI

using System;
using System.Drawing;
using Consoles = Colorful.Console;

namespace Simple_Graphic
{
  class Program
  {
    static int height = 8, width = 8;
    static int[,] display = new int[height, width];
    static int sRow = height / 2, sCol = width / 2,
               count = 0, moves = 0, iterate = height + width + 2;
    static int fRow, fCol, lastDir = 0, scoreCount = 1;
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
      bool iterate = true;
      do
      {
        row = (rnd.Next(1, height-1)); fRow = (int)row;
        col = (rnd.Next(1, width-1)); fCol = (int)col;
        if ((display[(int)row, (int)col] == 0) || display[(int)row, (int)col] == 15)
        {
          display[(int)row, (int)col] = 8;
          iterate = false; 
        }
        else
        {
          iterate = true;
        }
      } while (iterate == true);
    }
    static void CheckGrowth()
    {
      if (moves >= iterate)
      {
        death = true;
        Consoles.WriteAscii("Game Over", Color.Orange);
      }
      if (15 % scoreCount == 0)
      {
        iterate = width + height - 2; 
      }
    }
    static void PrintMatrix()
    {
      int row = 0, col = 0;
      Console.ResetColor();
      for (uint i = 1; i <= width * 2 + 2; i++) Console.Write("-");
      Console.WriteLine();

      foreach (int element in display)
      {
        if (col == 0)
        {
          Console.ResetColor();
          Console.Write("|");
        }

        if ((sRow == row) && (sCol == col))
        {
          Consoles.BackgroundColor = Color.FromArgb(250, 100, 30);
          Console.Write("{0} ", ' ');
          display[row, col] = 6;
          Console.ResetColor();
        }
        else
        {
          if (display[row, col] == 0)
          {
            Consoles.BackgroundColor = Color.Black;
            Console.Write("  ");
            Console.ResetColor();
          }
          else if (display[row, col] == 15)
          {
            Consoles.BackgroundColor = Color.FromArgb(10, 10, 10);
            Console.Write("  ");
            Console.ResetColor();
          }
          else if (display[row, col] == 6)
          {
            Consoles.BackgroundColor = Color.FromArgb(225, 100, 30);
            Console.Write("  ");
            Console.ResetColor();
            display[row, col] = 5;
          }
          else if (display[row, col] == 5)
          {
            Consoles.BackgroundColor = Color.FromArgb(200, 110, 30);
            Console.Write("  ");
            Console.ResetColor();
            display[row, col] = 4;
          }
          else if (display[row, col] == 4)
          {
            Consoles.BackgroundColor = Color.FromArgb(175, 120, 30);
            Console.Write("  ");
            Console.ResetColor();
            display[row, col] = 3;
          }
          else if (display[row, col] == 3)
          {
            Consoles.BackgroundColor = Color.FromArgb(150, 130, 30);
            Console.Write("  ");
            Console.ResetColor();
            display[row, col] = 2;
          }
          else if (display[row, col] == 2)
          {
            Consoles.BackgroundColor = Color.FromArgb(125, 140, 30);
            Console.Write("  ");
            Console.ResetColor();
            display[row, col] = 1;
          }
          else if (display[row, col] == 1)
          {
            Consoles.BackgroundColor = Color.FromArgb(100, 150, 30);
            Console.Write("  ");
            Console.ResetColor();
            display[row, col] = 15;
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
          display[sRow, sCol] = 6;
          SpawnFood();
          moves = 0;
          scoreCount++;
        }
        Console.ResetColor();
        if (col == height - 1) Console.Write("|");
        count++; col++;
        Console.ResetColor();
        if (count % height == 0)
        {
          Console.WriteLine();
          row++;
          count = 0;
          col = 0;
        }
      }
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
      Console.WriteLine(" Score : {0}", scoreCount);
      Console.WriteLine(" Distance to food : {0:f2}", distance);
      Console.WriteLine(" Moves :{0}/{1}", moves, iterate);

      // Four temporary distances
      // distance 1 = move up.
      // distance 2 = move down.
      // distance 3 = move right.
      // distance 4 = move left.
      double upDistance    = Math.Sqrt(Math.Pow(((sRow - 1) - fRow), 2) + Math.Pow((sCol - fCol), 2));
      double downDistance  = Math.Sqrt(Math.Pow(((sRow + 1) - fRow), 2) + Math.Pow((sCol - fCol), 2));
      double leftDistance  = Math.Sqrt(Math.Pow( (sRow - fRow), 2) + Math.Pow(((sCol - 1) - fCol), 2));
      double rightDistance = Math.Sqrt(Math.Pow( (sRow - fRow), 2) + Math.Pow(((sCol + 1) - fCol), 2));

      if (upDistance < distance)         // go up
      {
        lastDir = 1;
        sRow--;
        if (sRow < 0)
          sRow = height - 1;
      }
      else if (downDistance < distance)  // go down 
      {
        lastDir = 0;
        sRow++;
        if (sRow > height - 1)
          sRow = 0;
      }
      else if (leftDistance < distance)  // go left
      {
        lastDir = 10;
        sCol--;
        if (sCol < 0)
          sCol = width - 1;
      }
      else if (rightDistance < distance) // go right
      {
        lastDir = 11;
        sCol++;
        if (sCol > width - 1) // right arrow 
          sCol = 0;
      }
      else // If there is a glitch with it going backwards. 
      {
        if (lastDir == 1)
        {
          lastDir = 0;
          sRow--;
        }
        else if (lastDir == 0)
        {
          lastDir = 1;
          sRow++;
        }
        else if (lastDir == 10)
        {
          lastDir = 11;
          sCol--;
        }
        else if (lastDir == 11)
        {
          lastDir = 10;
          sCol++;
        }
      }

      #region not allowing the snake to go ontop of itself
      /*
      if ((upDistance < distance) && (lastDir != 0))         // go up
      {
        lastDir = 1;
        sRow--;
        if (sRow < 0)
          sRow = height - 1;
      }
      else if ((downDistance < distance) && (lastDir != 1))  // go down 
      {
        lastDir = 0;
        sRow++;
        if (sRow > height - 1)
          sRow = 0;
      }
      else if ((leftDistance < distance) && (lastDir != 11))  // go left
      {
        lastDir = 10;
        sCol--;
        if (sCol < 0)
          sCol = width - 1;
      }
      else if ((rightDistance < distance) && (lastDir != 10)) // go right
      {
        lastDir = 11;
        sCol++;
        if (sCol > width - 1) // right arrow 
          sCol = 0;
      }
      else // If there is a glitch with it going backwards. 
      {
        if (lastDir == 1)
        {
          lastDir = 0;
          sRow--;
        }
        else if (lastDir == 0)
        {
          lastDir = 1;
          sRow++;
        }
        else if (lastDir == 10)
        {
          lastDir = 11;
          sCol--;
        }
        else if (lastDir == 11)
        {
          lastDir = 10;
          sCol++;
        }
      }
      */
    #endregion
      moves++;
      System.Threading.Thread.Sleep(33); // waits exactly 1 second between moves 
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
            if (sCol > height - 1)
              sCol = 0;
            userValue = false;
            break;

          case ConsoleKey.LeftArrow:
            sCol--;
            if (sCol < 0)
              sCol = height - 1;
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
