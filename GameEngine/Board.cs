//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GameEngine.Events;

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
  try
  {
    boxes[position].Marking = marking;
  }
  catch (IndexOutOfRangeException)
  {
    BoxMarkFailEvent?.Invoke(this, new EventArgs());
  }
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
public event EventHandler<EventArgs> BoxMarkFailEvent;
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

private void OnBoxMark(
  int position,
  Marking marking)
{
  BoxMarkEvent?.Invoke(this, new BoxMarkingEventArgs(position, marking));
}

//-----------------------------------------------------------------------------

private void OnBoxMarkOccupied(
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
    // Must create a copy, see 
    // https://stackoverflow.com/questions/61104500/wrong-value-when-event-handlers-are-attached-in-a-for-loop?noredirect=1#comment108101869_61104500
    var position = i;
    b.MarkingEvent += (s, e) => OnBoxMark(position, e.Marking);
    b.MarkingOccupiedEvent += (s, e) => OnBoxMarkOccupied(position, e.Marking);
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
