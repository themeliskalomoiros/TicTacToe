//-----------------------------------------------------------------------------

using GameEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

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
  Debug.WriteLine($"Board reports that its box in position {position} is occupied. The marking is {marking}");
  BoxOccupiedEvent?.Invoke(this, new BoxMarkingEventArgs(position, marking));
}

//-----------------------------------------------------------------------------

private void Populate(
  Box[] boxes)
{
  
//for (int i = 0; i < boxes.Length; i++)
  //{
  //  var b = new Box();
  //  b.MarkingEvent += (s, e) => OnBoxMark(i, e.Marking);
  //  b.MarkingOccupiedEvent += (s, e) => OnBoxMarkOccupied(i, e.Marking);
  //  boxes[i] = b;
  //}

  var b = new Box();
  b.MarkingEvent += (s, e) => OnBoxMark(0, e.Marking);
  b.MarkingOccupiedEvent += (s, e) => OnBoxMarkOccupied(0, e.Marking);
  boxes[0] = b;

  b = new Box();
  b.MarkingEvent += (s, e) => OnBoxMark(1, e.Marking);
  b.MarkingOccupiedEvent += (s, e) => OnBoxMarkOccupied(1, e.Marking);
  boxes[1] = b;

  b = new Box();
  b.MarkingEvent += (s, e) => OnBoxMark(2, e.Marking);
  b.MarkingOccupiedEvent += (s, e) => OnBoxMarkOccupied(2, e.Marking);
  boxes[2] = b;

  b = new Box();
  b.MarkingEvent += (s, e) => OnBoxMark(3, e.Marking);
  b.MarkingOccupiedEvent += (s, e) => OnBoxMarkOccupied(3, e.Marking);
  boxes[3] = b;

  b = new Box();
  b.MarkingEvent += (s, e) => OnBoxMark(4, e.Marking);
  b.MarkingOccupiedEvent += (s, e) => OnBoxMarkOccupied(4, e.Marking);
  boxes[4] = b;

  b = new Box();
  b.MarkingEvent += (s, e) => OnBoxMark(5, e.Marking);
  b.MarkingOccupiedEvent += (s, e) => OnBoxMarkOccupied(5, e.Marking);
  boxes[5] = b;

  b = new Box();
  b.MarkingEvent += (s, e) => OnBoxMark(6, e.Marking);
  b.MarkingOccupiedEvent += (s, e) => OnBoxMarkOccupied(6, e.Marking);
  boxes[6] = b;

  b = new Box();
  b.MarkingEvent += (s, e) => OnBoxMark(7, e.Marking);
  b.MarkingOccupiedEvent += (s, e) => OnBoxMarkOccupied(7, e.Marking);
  boxes[7] = b;

  b = new Box();
  b.MarkingEvent += (s, e) => OnBoxMark(8, e.Marking);
  b.MarkingOccupiedEvent += (s, e) => OnBoxMarkOccupied(8, e.Marking);
  boxes[8] = b;
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
