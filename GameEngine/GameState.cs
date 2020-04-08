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
  board.BoxMarkFailEvent += Board_BoxMarkFailEvent;
}

//-----------------------------------------------------------------------------

#endregion
#region Event Handlers

//-----------------------------------------------------------------------------

public event EventHandler<EventArgs> MarkFailedEvent;
public event EventHandler<CrossesMarkEventArgs> CrossesMarkEvent;
public event EventHandler<CirclesMarkEventArgs> CirclesMarkEvent;
public event EventHandler<CompletionEventArgs> CompletionEvent;
public event EventHandler<BoxMarkingEventArgs> MarkOccupiedEvent;

//-----------------------------------------------------------------------------

#endregion
#region Private Methods

//-----------------------------------------------------------------------------

private void Board_BoxMarkFailEvent(object sender, EventArgs e)
{
  MarkFailedEvent?.Invoke(this, e);
}

//-----------------------------------------------------------------------------

private void Board_BoxOccupiedEvent(
  object s, 
  BoxMarkingEventArgs e)
{
  Debug.WriteLine($"Game reports that the box of board with position {e.Position} is occupied.");
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
    crossPositions.Add(e.Position);
    RaiseCrossesMarkEvent(e.Position);
  }
  else
  {
    IsCrossesTurn = true;
    circlePositions.Add(e.Position);
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
  bool winIsPossible = crossPositions.Count + circlePositions.Count>= 5;
  if (winIsPossible)
  {
    if (IsCrossesTurn)
    {
      if (HasWon(circlePositions))
      {
        RaiseCompletionEvent(Result.CirclesWin);
        return;
      }
    }
    else
    {
      if (HasWon(crossPositions))
      {
        RaiseCompletionEvent(Result.CrossesWin);
        return;
      }
    }

    bool allMarked = crossPositions.Count + circlePositions.Count == 9;
    if (allMarked)
    {
      RaiseCompletionEvent(Result.Draw);
    }
  }
}

//-----------------------------------------------------------------------------

private bool HasWon(List<int> positions)
{
  return 
    positions.Contains(0) && positions.Contains(1) && positions.Contains(2) ||
    positions.Contains(3) && positions.Contains(4) && positions.Contains(5) ||
    positions.Contains(6) && positions.Contains(7) && positions.Contains(8) ||
    positions.Contains(0) && positions.Contains(3) && positions.Contains(6) ||
    positions.Contains(1) && positions.Contains(4) && positions.Contains(7) ||
    positions.Contains(2) && positions.Contains(5) && positions.Contains(8) ||
    positions.Contains(0) && positions.Contains(4) && positions.Contains(8) ||
    positions.Contains(2) && positions.Contains(4) && positions.Contains(6);
}

//-----------------------------------------------------------------------------

#endregion
#region Fields

//-----------------------------------------------------------------------------

private Board board = new Board();

//-----------------------------------------------------------------------------

private List<int> crossPositions = new List<int>();
private List<int> circlePositions = new List<int>();

//-----------------------------------------------------------------------------

#endregion

//-----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->
