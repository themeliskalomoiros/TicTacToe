﻿//-----------------------------------------------------------------------------

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

public static int ReadMove()
{
  var input = Console.ReadLine();
  return int.Parse(input) - 1;
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

