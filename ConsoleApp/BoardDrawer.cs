//-----------------------------------------------------------------------------

using System;
using System.Text;
using GameEngine;
//-----------------------------------------------------------------------------

namespace ConsoleApp {

//-----------------------------------------------------------------------------

public static class BoardDrawer {

//-----------------------------------------------------------------------------

#region Public Static Methods

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
#region Private Static Methods

//-----------------------------------------------------------------------------

#endregion
#region Constants

//-----------------------------------------------------------------------------

private const string LineInBetween = "---------";

//-----------------------------------------------------------------------------

#endregion

//-----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->

