//-----------------------------------------------------------------------------

using GameEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

//-----------------------------------------------------------------------------

namespace GameEngine {

//-----------------------------------------------------------------------------

public class Board {

//-----------------------------------------------------------------------------

#region Properties

//-----------------------------------------------------------------------------

public IEnumerable<Box> Boxes => boxes;

//-----------------------------------------------------------------------------

#endregion
#region Public Methods

//-----------------------------------------------------------------------------

public void SetMarking(
  int position, 
  Marking marking)
{
  boxes[position].Marking = marking;
}

//-----------------------------------------------------------------------------

public Marking GetMarking(
  int position)
{
  return boxes[position].Marking;
}

//-----------------------------------------------------------------------------

#endregion
#region Event Handlers

//-----------------------------------------------------------------------------

public event EventHandler<BoxMarkingEventArgs> BoxMarkEvent;
public event EventHandler<BoxMarkingEventArgs> BoxOccupiedEvent;

//-----------------------------------------------------------------------------

#endregion
#region Constructors

//-----------------------------------------------------------------------------

public Board()
{
  boxes = new Box[9];
  Populate(boxes);
}

//-----------------------------------------------------------------------------

#endregion
#region Private Methods

//-----------------------------------------------------------------------------

private void OnMark(
  int position,
  Marking marking)
{
  BoxMarkEvent?.Invoke(this, new BoxMarkingEventArgs(position, marking));
}

//-----------------------------------------------------------------------------

private void OnAlreadyMarked(
  int position,
  Marking marking)
{
  BoxOccupiedEvent?.Invoke(this, new BoxMarkingEventArgs(position, marking));
}

//-----------------------------------------------------------------------------

private void Populate(
  Box[] boxes)
{
  for (int i = 0; i < boxes.Length; i++)
  {
    var b = new Box();
    b.MarkingEvent += (s, e) => OnMark(i, b.Marking);
    b.MarkingOccupiedEvent += (s, e) => OnAlreadyMarked(i, b.Marking);
    boxes[i] = b;
  }
}

//-----------------------------------------------------------------------------

#endregion
#region Fields

//-----------------------------------------------------------------------------

private readonly Box[] boxes;

//-----------------------------------------------------------------------------

#endregion

//-----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->
