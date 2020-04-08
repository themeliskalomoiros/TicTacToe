//-----------------------------------------------------------------------------

using GameEngine;
using GameEngine.Events;
using System;
using System.Text;

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
  Console.WriteLine("\t1 | 2 | 3\n\n\t4 | 5 | 6\n\n\t7 | 8 | 9");
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
      sb.Append("\n");
      sb.Append("\t" + GetBoardLine(m0,m1,m2));
      sb.Append("\n");
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
      return "_";
  }
}

//-----------------------------------------------------------------------------

#endregion
#region Private Static Methods

//-----------------------------------------------------------------------------

#endregion

//-----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->

