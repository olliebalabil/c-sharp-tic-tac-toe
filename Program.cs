using System;
using System.Linq;
namespace Scripts
{
  public class Program
  {
    public static void DisplayTable(string[] gridArr)
    {

      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          Console.Write(gridArr[j + 3 * i]);
          if (j != 2)
          {
            Console.Write("|");
          }
        }
        if (i != 2)
        {
          Console.WriteLine("\n-----");
        }
      }
    }
    public static void Move(int player, string[] gridArr)
    {
      Console.WriteLine($"\nPlayer {player}, enter your move!");
      string? input = Console.ReadLine();
      string[] validInputs = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];
      while (!validInputs.Contains(input))
      {
        Console.WriteLine($"\nThat is not a valid input. Player {player}, enter your move!");
        input = Console.ReadLine();
      }
      int move = Convert.ToInt32(input);
      if (gridArr[move - 1] != "X" && gridArr[move - 1] != "O")
      {
        gridArr[move - 1] = (player == 1) ? gridArr[move - 1] = "O" : gridArr[move - 1] = "X";
      }
      else
      {
        Console.WriteLine("A player has already gone in that space.");
        Move(player, gridArr);
      }
    }
    public static bool CheckWinner(string[] gridArr)
    {
      bool row1 = gridArr[0] == gridArr[1] && gridArr[1] == gridArr[2];
      bool row2 = gridArr[3] == gridArr[4] && gridArr[4] == gridArr[5];
      bool row3 = gridArr[6] == gridArr[7] && gridArr[7] == gridArr[8];
      bool col1 = gridArr[0] == gridArr[3] && gridArr[3] == gridArr[6];
      bool col2 = gridArr[1] == gridArr[4] && gridArr[4] == gridArr[7];
      bool col3 = gridArr[2] == gridArr[5] && gridArr[5] == gridArr[8];
      bool diagUp = gridArr[6] == gridArr[4] && gridArr[4] == gridArr[2];
      bool diagDown = gridArr[0] == gridArr[4] && gridArr[4] == gridArr[8];

      return row1 || row2 || row3 || col1 || col2 || col3 || diagUp || diagDown;
    }
    public static bool CheckDraw(string[] gridArr)
    {
      for (int i = 0; i < 9; i++)
      {
        if (gridArr[i] != "X" && gridArr[i] != "O")
        {
          return false;
        }
      }
      return true;
    }
    public static void Main(string[] args)
    {
      string[] grid = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];
      bool playing = !CheckWinner(grid);
      int player = 1;
      DisplayTable(grid);
      while (playing)
      {
        Move(player, grid);
        playing = !CheckWinner(grid) && !CheckDraw(grid);
        DisplayTable(grid);
        player = 3 - player;
      }
      if (CheckWinner(grid))
      {
        Console.WriteLine($"\nPlayer {3 - player} has won!");
      }
      else if (CheckDraw(grid))
      {
        Console.WriteLine("\nIt's a draw!");
      }
    }
  }
}

