//-----------------------------------------------------------------------------

using GameEngine;
using System;
using System.Text;
using System.Threading;

//-----------------------------------------------------------------------------

namespace ConsoleApp {

//-----------------------------------------------------------------------------

public static class GameInput {

//-----------------------------------------------------------------------------

#region Public Methods

//-----------------------------------------------------------------------------

public static GameState ReadGame()
{
  var s = Console.ReadLine();

  if (s.ToUpper() == "O")
  {
    return new GameState(false);
  }
  else
  {
    return new GameState();
  }
}

//-----------------------------------------------------------------------------

public static bool ReadMove(out int move)
{
  var input = Console.ReadLine();
  return int.TryParse(input, out move);
}

//-----------------------------------------------------------------------------

#endregion
#region Private Methods

//-----------------------------------------------------------------------------

#endregion
#region Fields

//-----------------------------------------------------------------------------

#endregion

//-----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->

