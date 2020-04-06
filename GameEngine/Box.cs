//-----------------------------------------------------------------------------

using GameEngine.Events;
using System;
using System.ComponentModel;

//-----------------------------------------------------------------------------

namespace GameEngine {

//-----------------------------------------------------------------------------

public class Box{

//-----------------------------------------------------------------------------

#region Properties

//-----------------------------------------------------------------------------

public Marking Marking 
{ 
  get => marking; 
  set
  {
    bool isNotSet = marking == Marking.None && value != Marking.None;
    if (isNotSet)
    {
      RaiseMarkEvent(marking = value);
    }
    else
    {
      RaiseAlreadyMarked(Marking);
    }
  }
}

//-----------------------------------------------------------------------------

#endregion
#region Event Handlers

//-----------------------------------------------------------------------------

public event EventHandler<MarkingEventArgs> MarkingEvent;
public event EventHandler<MarkingEventArgs> MarkingOccupiedEvent;

//-----------------------------------------------------------------------------

#endregion
#region Private Methods

//-----------------------------------------------------------------------------

private void RaiseMarkEvent(
  Marking marking)
{
  MarkingEvent?.Invoke(this, new MarkingEventArgs(marking));
}

//-----------------------------------------------------------------------------

private void RaiseAlreadyMarked(
  Marking marking)
{
  MarkingOccupiedEvent?.Invoke(this, new MarkingEventArgs(marking));
}

//-----------------------------------------------------------------------------

#endregion
#region Fields

//-----------------------------------------------------------------------------

private Marking marking = Marking.None;

//-----------------------------------------------------------------------------

#endregion

//-----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->
