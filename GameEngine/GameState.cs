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
  ReportMarking(position);
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
}

//-----------------------------------------------------------------------------

#endregion
#region Event Handlers

//-----------------------------------------------------------------------------

public event EventHandler<CrossesMarkEventArgs> CrossesMarkEvent;
public event EventHandler<CirclesMarkEventArgs> CirclesMarkEvent;
public event EventHandler<CompletionEventArgs> CompletionEvent;

//-----------------------------------------------------------------------------

#endregion
#region Private Methods

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

private void RaiseCompletionEvent(Result result)
{
  CompletionEvent?.Invoke(this, new CompletionEventArgs(result));
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

private void ReportMarking(int position)
{
  if (IsCrossesTurn)
  {
    board.SetMarking(position, Marking.Cross);
    IsCrossesTurn = false;
    crossPositions.Append(position);
    RaiseCrossesMarkEvent(position);
  }
  else
  {
    board.SetMarking(position, Marking.Circle);
    IsCrossesTurn = true;
    circlePositions.Append(position);
    RaiseCirclesMarkEvent(position);
  }
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
