//-----------------------------------------------------------------------------

using System;
using System.Threading;
using GameEngine;
using GameEngine.Events;

//-----------------------------------------------------------------------------

namespace ConsoleApp {

//-----------------------------------------------------------------------------

public class Program {

//-----------------------------------------------------------------------------

#region Public Static Methods

//-----------------------------------------------------------------------------

public static void Main(string[] args)
{
  GameOutput.PrintWelcome();
  GameOutput.PrintInstructions();
  GameOutput.DrawBoardWithPositions();
  GameOutput.PrintWhoPlaysFirst();
  
  var game = GameInput.ReadGame();
  AttachListenersTo(game);

  while (true)
  {
    if (game.IsCrossesTurn)
    {
      GameOutput.PrintCrossesMakeMove();
    }
    else
    {
      GameOutput.PrintCirclesMakeMove();
    }

    int move;
    if (GameInput.ReadMove(out move))
    {
      game.Mark(move);
    }
    else
    {
      GameOutput.PrintInvalidMove();
    }
  }
}

//-----------------------------------------------------------------------------

#endregion
#region Private Static Methods

//-----------------------------------------------------------------------------

private static void AttachListenersTo(GameState game)
{
  game.CompletionEvent += Game_CompletionEvent;
  game.CirclesMarkEvent += Game_CirclesMarkEvent;
  game.CrossesMarkEvent += Game_CrossesMarkEvent;
  game.MarkOccupiedEvent += Game_MarkOccupiedEvent;
  game.MarkFailedEvent += Game_MarkFailedEvent;
}

//-----------------------------------------------------------------------------

private static void Game_CompletionEvent(
  object s, 
  CompletionEventArgs e)
{
  GameOutput.PrintResult(e.Result);
  Thread.Sleep(3000);
  Environment.Exit(0);
}

//-----------------------------------------------------------------------------

private static void Game_CirclesMarkEvent(
  object s, 
  CirclesMarkEventArgs e)
{
  GameOutput.DrawBoardOf(s as GameState);
}

//-----------------------------------------------------------------------------

private static void Game_CrossesMarkEvent(
  object s, 
  CrossesMarkEventArgs e)
{
  GameOutput.DrawBoardOf(s as GameState);
}

//-----------------------------------------------------------------------------

private static void Game_MarkOccupiedEvent(
  object s, 
  BoxMarkingEventArgs e)
{
  Console.WriteLine("There is already a " + e.Marking + " at position " + (e.Position + 1));
}

//-----------------------------------------------------------------------------

private static void Game_MarkFailedEvent(object sender, EventArgs e)
{
  GameOutput.PrintInvalidMove();
  GameOutput.PrintValidMoves();
}

//-----------------------------------------------------------------------------

#endregion

//-----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->

