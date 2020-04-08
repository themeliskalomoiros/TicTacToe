//-----------------------------------------------------------------------------

using GameEngine;
using System;
using System.Text;
using System.Threading;

//-----------------------------------------------------------------------------

namespace ConsoleApp {

//-----------------------------------------------------------------------------

public static class UserOutput {

//-----------------------------------------------------------------------------

#region Public Methods

//-----------------------------------------------------------------------------

public static void Print(Result result)
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
    "\n\t1. Choose who plays first (Crosses or Circles)." +
    "\n\t2. To move select an available position on the boarder.");
  Console.WriteLine();
}

//-----------------------------------------------------------------------------

public static void PrintCrossesMakeMove()
{
  Console.WriteLine();
  Console.WriteLine("Crosses it's your move.\t(Choose a position to place a cross)");
  Console.WriteLine();
}

//-----------------------------------------------------------------------------

public static void PrintCirclesMakeMove()
{
  Console.WriteLine();
  Console.WriteLine("Circles it's your move.\t(Choose a position to place a circle)");
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
    Thread.Sleep(1);
    Console.Write(welcome[i]);
  }

  Console.WriteLine();
  Console.WriteLine();
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
    if (i == LineHeight / 2 - 1)
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
  var text = " The TIC-TAC-TOE Game ";
  var line = GetWelcomeLine();
  var lineWithText = line.Insert(line.Length / 2 - text.Length / 2, text);
  return lineWithText.Remove(line.Length);
}

//-----------------------------------------------------------------------------

#endregion
#region Fields

//-----------------------------------------------------------------------------

private const int LineWidth = 70;
private const int LineHeight = 10;

//-----------------------------------------------------------------------------

#endregion

//-----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->

