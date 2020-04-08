//-----------------------------------------------------------------------------

using GameEngine.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

//-----------------------------------------------------------------------------

namespace GameEngine {

//-----------------------------------------------------------------------------

public class GameState {

//-----------------------------------------------------------------------------

#region Properties

//-----------------------------------------------------------------------------

public bool IsCrossesTurn { get; private set; } = true;

//-----------------------------------------------------------------------------

#endregion
#region Public Methods

//-----------------------------------------------------------------------------

public void Mark(
  int position)
{
  if (IsCrossesTurn)
  {
    board.SetMarking(position, Marking.Cross);
   
  }
  else
  {
    board.SetMarking(position, Marking.Circle);
  }
  ReportResult();
}

//-----------------------------------------------------------------------------

public Marking GetMark(
  int position)
{
  return board.GetMarking(position);
}

//-----------------------------------------------------------------------------

#endregion
#region Constructors

//-----------------------------------------------------------------------------

public GameState(
  bool isCrossesTurn = true)
{
  IsCrossesTurn = isCrossesTurn;
  board.BoxMarkEvent += Board_BoxMarkEvent;
  board.BoxOccupiedEvent += Board_BoxOccupiedEvent;
}

//-----------------------------------------------------------------------------

#endregion
#region Event Handlers

//-----------------------------------------------------------------------------

public event EventHandler<CrossesMarkEventArgs> CrossesMarkEvent;
public event EventHandler<CirclesMarkEventArgs> CirclesMarkEvent;
public event EventHandler<CompletionEventArgs> CompletionEvent;
public event EventHandler<BoxMarkingEventArgs> MarkOccupiedEvent;

//-----------------------------------------------------------------------------

#endregion
#region Private Methods

//-----------------------------------------------------------------------------

private void Board_BoxOccupiedEvent(
  object s, 
  BoxMarkingEventArgs e)
{
  MarkOccupiedEvent?.Invoke(this, e);
}

//-----------------------------------------------------------------------------

private void Board_BoxMarkEvent(
  object s, 
  BoxMarkingEventArgs e)
{
  if (e.Marking == Marking.Cross)
  {
    IsCrossesTurn = false;
    crossPositions.Append(e.Position);
    RaiseCrossesMarkEvent(e.Position);
  }
  else
  {
    IsCrossesTurn = true;
    circlePositions.Append(e.Position);
    RaiseCirclesMarkEvent(e.Position);
  }
}

//-----------------------------------------------------------------------------

private void RaiseCrossesMarkEvent(
  int position)
{
  CrossesMarkEvent?.Invoke(this, new CrossesMarkEventArgs(position));
}

//-----------------------------------------------------------------------------

private void RaiseCirclesMarkEvent(
  int position)
{
  CirclesMarkEvent?.Invoke(this, new CirclesMarkEventArgs(position));
}

//-----------------------------------------------------------------------------

private void RaiseCompletionEvent(
  Result r)
{
  CompletionEvent?.Invoke(this, new CompletionEventArgs(r));
}

//-----------------------------------------------------------------------------

private void ReportResult()
{
  bool winIsPossible = crossPositions.Length + circlePositions.Length >= 5;
  if (winIsPossible)
  {
    if (IsCrossesTurn)
    {
      if (HasWon(circlePositions.ToString()))
      {
        RaiseCompletionEvent(Result.CirclesWin);
        return;
      }
    }
    else
    {
      if (HasWon(crossPositions.ToString()))
      {
        RaiseCompletionEvent(Result.CrossesWin);
        return;
      }
    }

    bool allMarked = crossPositions.Length + circlePositions.Length == 9;
    if (allMarked)
    {
      RaiseCompletionEvent(Result.Draw);
    }
  }
}

//-----------------------------------------------------------------------------

private bool HasWon(string positions)
{
  return 
    positions.Contains("012") ||
    positions.Contains("345") ||
    positions.Contains("678") ||
    positions.Contains("036") ||
    positions.Contains("147") ||
    positions.Contains("258") ||
    positions.Contains("048") ||
    positions.Contains("246");  
}

//-----------------------------------------------------------------------------

#endregion
#region Fields

//-----------------------------------------------------------------------------

private Board board = new Board();

//-----------------------------------------------------------------------------

private StringBuilder crossPositions = new StringBuilder();
private StringBuilder circlePositions = new StringBuilder();

//-----------------------------------------------------------------------------

#endregion

//-----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->
