//-----------------------------------------------------------------------------

using GameEngine;
using System;
using System.Text;
using System.Threading;

//-----------------------------------------------------------------------------

namespace ConsoleApp {

//-----------------------------------------------------------------------------

public static class UserInput {

//-----------------------------------------------------------------------------

#region Public Methods

public static GameState ReadGame()
{
  var s = Console.ReadLine();

  if (s.ToUpper() == "O")
  {
    Console.WriteLine("Circles plays first!");
    return new GameState(false);
  }
  else
  {
    Console.WriteLine("Crosses plays first!");
    return new GameState();
  }
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

