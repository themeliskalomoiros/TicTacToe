//-----------------------------------------------------------------------------

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

public IEnumerable<Box> Boxes
{
  get => boxes;
}

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

public event EventHandler<MarkEventArgs> MarkEvent;

//-----------------------------------------------------------------------------

#endregion
#region Constructors

//-----------------------------------------------------------------------------

public Board()
{
  boxes = new Box[9];
  for (int i = 0; i < boxes.Length; i++)
  {
    var b = new Box();
    b.PropertyChanged += (s, e) => OnMark(new MarkEventArgs(i, b.Marking));
    boxes[i] = b;
  }
}

//-----------------------------------------------------------------------------

#endregion
#region Private Methods

//-----------------------------------------------------------------------------

private void OnMark(
  MarkEventArgs args)
{
  MarkEvent?.Invoke(this, args);
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
