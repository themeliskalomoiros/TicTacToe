﻿//-----------------------------------------------------------------------------

using GameEngine;
using GameEngine.Events;
using System;
using System.Threading;

//-----------------------------------------------------------------------------

namespace ConsoleApp {

//-----------------------------------------------------------------------------

public class Program {

//-----------------------------------------------------------------------------

#region Public Static Methods

//-----------------------------------------------------------------------------

public static void Main(string[] args)
{
  UserOutput.PrintWelcome();
  UserOutput.PrintInstructions();
  BoardDrawer.DrawBoardWithPositions();

  UserOutput.PrintWhoPlaysFirst();
  var game = UserInput.ReadGame();
  AttachListenersTo(game);

  while (true)
  {
    if (game.IsCrossesTurn)
    {
      UserOutput.PrintCrossesMakeMove();
    }
    else
    {
      UserOutput.PrintCirclesMakeMove();
    }

    game.Mark(UserInput.ReadMove());
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
}

//-----------------------------------------------------------------------------

private static void Game_CompletionEvent(
  object s, 
  CompletionEventArgs e)
{
  UserOutput.Print(e.Result);
  Thread.Sleep(3000);
  Environment.Exit(0);
}

//-----------------------------------------------------------------------------

private static void Game_CirclesMarkEvent(
  object s, 
  CirclesMarkEventArgs e)
{
  BoardDrawer.DrawBoardOf(s as GameState);
}

//-----------------------------------------------------------------------------

private static void Game_CrossesMarkEvent(
  object s, 
  CrossesMarkEventArgs e)
{
  BoardDrawer.DrawBoardOf(s as GameState);
}

//-----------------------------------------------------------------------------

private static void Game_MarkOccupiedEvent(
  object s, 
  BoxMarkingEventArgs e)
{
  Console.WriteLine("There is already an "+e.Marking+" at position "+e.Position);
}

//-----------------------------------------------------------------------------

#endregion
#region Fields

//-----------------------------------------------------------------------------

private static bool gameCompleted = false;

//-----------------------------------------------------------------------------

#endregion

//-----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->

