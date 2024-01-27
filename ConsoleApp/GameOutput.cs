//-----------------------------------------------------------------------------

using System;
using System.Text;
using System.Threading;
using GameEngine;

//-----------------------------------------------------------------------------

namespace ConsoleApp {

//-----------------------------------------------------------------------------

public static class GameOutput {

//-----------------------------------------------------------------------------

#region Public Methods

//-----------------------------------------------------------------------------

public static void PrintResult(Result result)
{
  Console.WriteLine("Game Over!");
  
  switch (result)
  {
    case Result.CrossesWin:
      Console.WriteLine("Congratulations Crosses, you win!");
      break;
    case Result.CirclesWin:
      Console.WriteLine("Congratulations Circles, you win!");
      break;
    default:
      Console.WriteLine("It's a draw!");
      break;
  }
  
  Console.WriteLine();
}

//-----------------------------------------------------------------------------

public static void PrintInstructions()
{
  Console.WriteLine(
    "How to Play:" +
    "\n\t1. Choose who plays first: X's or O's." +
    "\n\t2. To make a move, select an available position on the board.");
  Console.WriteLine();
}

//-----------------------------------------------------------------------------

public static void PrintInvalidMove()
{
  Console.WriteLine("Oops! That move isn't valid.");
}

//-----------------------------------------------------------------------------

public static void PrintCrossesMakeMove()
{
  Console.WriteLine();
  Console.WriteLine("Crosses, your move!\t(Decide where to place your X)");
  Console.WriteLine();
}

//-----------------------------------------------------------------------------

public static void PrintCirclesMakeMove()
{
  Console.WriteLine();
  Console.WriteLine("Circles, your move!\t(Decide where to place your O)");
  Console.WriteLine();
}

//-----------------------------------------------------------------------------

public static void PrintWhoPlaysFirst()
{
  var s = "\nWho plays first? Crosses or Circles?\t(Apply with 'X' or 'O')\n";
  Console.WriteLine(s);
}

//-----------------------------------------------------------------------------

public static void PrintWelcome()
{
  var welcome = GetWelcomeMessage();
  for (int i = 0; i < welcome.Length; i++)
  {
    Thread.Sleep(4);
    Console.Write(welcome[i]);
  }

  Console.WriteLine();
  Console.WriteLine();
}

//-----------------------------------------------------------------------------

public static void PrintValidMoves()
{
  Console.Write("Allowed positions: 1, 2, 3, 4, 5, 6, 7, 8, 9");
}

//-----------------------------------------------------------------------------

public static void DrawBoardWithPositions()
{
  Console.WriteLine("\tBoarder Positions");
  Console.WriteLine($"\t1 | 2 | 3\n\t{LineInBetween}\n\t4 | 5 | 6\n\t{LineInBetween}\n\t7 | 8 | 9");
  Console.WriteLine();
}

//-----------------------------------------------------------------------------

public static void DrawBoardOf(
  GameState game)
{
  var sb = new StringBuilder();
  for (int i = 0; i < 9; i++)
  {
    if (i % 3 == 0)
    {
      var m0 = game.GetMark(i);
      var m1 = game.GetMark(i+1);
      var m2 = game.GetMark(i+2);

      sb.Append('\n');
      sb.Append("\t" + GetBoardLine(m0, m1, m2));
      sb.Append('\n');
    }

    if (i == 2 || i == 5)
    {
      sb.Append("\t" + LineInBetween);
    }
  }

  Console.WriteLine(sb.ToString());
}

//-----------------------------------------------------------------------------

#endregion
#region Private Methods

//-----------------------------------------------------------------------------

private static string GetWelcomeMessage()
{
  var sb = new StringBuilder();
  for (int i = 0; i < LineHeight; i++)
  {
    sb.Append("\n");
    if (i == 1)
    {
      sb.Append(GetWelcomeLineWithText());
    }
    else
    {
      sb.Append(GetWelcomeLine());
    }
  }

  return sb.ToString();
}

//-----------------------------------------------------------------------------

private static string GetWelcomeLine()
{
  var sb = new StringBuilder();
  for (int i = 0; i < LineWidth; i++)
    sb.Append("*");

  return sb.ToString();
}

//-----------------------------------------------------------------------------

private static string GetWelcomeLineWithText()
{
  var text = " Welcome to Tic-Tac-Toe! ";
  var line = GetWelcomeLine();
  var lineWithText = line.Insert(line.Length / 2 - text.Length / 2, text);
  return lineWithText.Remove(line.Length);
}

//-----------------------------------------------------------------------------

private static string GetBoardLine(
  Marking m0, 
  Marking m1,
  Marking m2)
{
  return $"{GetSymbolOf(m0)} | {GetSymbolOf(m1)} | {GetSymbolOf(m2)}";
}

//-----------------------------------------------------------------------------

private static string GetSymbolOf(Marking m)
{
  switch(m)
  {
    case Marking.Circle:
      return "O";
    
    case Marking.Cross:
      return "X";
    
    default:
      return " ";
  }
}

//-----------------------------------------------------------------------------

#endregion
#region Fields

//-----------------------------------------------------------------------------

private const int LineHeight = 3;
private const int LineWidth = 70;
private const string LineInBetween = "---------";

//-----------------------------------------------------------------------------

#endregion

//-----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->

