//-----------------------------------------------------------------------------

using GameEngine;
using GameEngine.Events;
using System;
using Xunit;

//-----------------------------------------------------------------------------

namespace GameEngine.Test {

//-----------------------------------------------------------------------------

public class BoxShould {

//-----------------------------------------------------------------------------

#region Arrange

//-----------------------------------------------------------------------------

private readonly Box sut = new Box();

//-----------------------------------------------------------------------------

#endregion
#region Tests

//-----------------------------------------------------------------------------

[Fact]
public void HaveDefaultMarkingToNone()
{
  Assert.Equal(Marking.None, sut.Marking);
}

//-----------------------------------------------------------------------------

[Fact]
public void RaiseMarkingEvent()
{
  Assert.Raises<MarkingEventArgs>(
  handler => sut.MarkingEvent += handler,  
  handler => sut.MarkingEvent -= handler,  
  () => sut.Marking = Marking.Circle);
}

//-----------------------------------------------------------------------------

[Fact]
public void RaiseMarkingOccupiedEvent()
{
  Assert.Raises<MarkingEventArgs>(
    handler => sut.MarkingOccupiedEvent += handler,
    handler => sut.MarkingOccupiedEvent -= handler,
    () => 
    {
      sut.Marking = Marking.Circle;
      sut.Marking = Marking.Cross;
    });    
}

// ----------------------------------------------------------------------------

#endregion

// ----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->
