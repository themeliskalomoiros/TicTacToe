//-----------------------------------------------------------------------------

using GameEngine;
using GameEngine.Events;
using System;
using Xunit;

//-----------------------------------------------------------------------------

namespace GameEngine.Test {

//-----------------------------------------------------------------------------

public class BoardShould {

//-----------------------------------------------------------------------------

#region Arrange

//-----------------------------------------------------------------------------

private readonly Board sut = new Board();

//-----------------------------------------------------------------------------

#endregion
#region Tests

//-----------------------------------------------------------------------------

[Fact]
public void HaveNineBoxes()
{
  int boxCount = 0;
  foreach (var b in sut.Boxes) boxCount++;
  
  Assert.Equal(9, boxCount);
}

//-----------------------------------------------------------------------------

[Fact]
public void SetMarkingAtSpecifiedPosition()
{
  sut.SetMarking(3, Marking.Cross);

  Assert.Equal(Marking.Cross, sut.GetMarking(3));
}

//-----------------------------------------------------------------------------

[Fact]
public void SetOnlyFirstMarkingAtSpecifiedPosition()
{
  sut.SetMarking(3, Marking.Cross);
  sut.SetMarking(3, Marking.Circle);
  sut.SetMarking(3, Marking.None);

  Assert.Equal(Marking.Cross, sut.GetMarking(3));
}

// ----------------------------------------------------------------------------

[Fact]
public void RaiseBoxMarkEvent()
{
  Assert.Raises<BoxMarkingEventArgs>( 
    handler => sut.BoxMarkEvent += handler,
    handler => sut.BoxMarkEvent -= handler,
    () => sut.SetMarking(3, Marking.Circle));
}

// ----------------------------------------------------------------------------

[Fact]
public void NotRaiseBoxMarkEventIfMarkingIsNone()
{
  int timesRaised = 0;
  sut.BoxMarkEvent += (s, e) => timesRaised++;
  
  sut.SetMarking(3, Marking.None);

  Assert.Equal(0, timesRaised);
}

// ----------------------------------------------------------------------------

[Fact]
public void RaiseBoxOccupiedEvent()
{
  Assert.Raises<BoxMarkingEventArgs>( 
    handler => sut.BoxOccupiedEvent += handler,
    handler => sut.BoxOccupiedEvent -= handler,
    () => 
    {
      sut.SetMarking(3, Marking.Circle);
      sut.SetMarking(3, Marking.Circle);
    });
}

// ----------------------------------------------------------------------------

[Fact]
public void RaiseBoxMarkFailEvent()
{
  Assert.Raises<EventArgs>( 
    handler => sut.BoxMarkFailEvent += handler,
    handler => sut.BoxMarkFailEvent -= handler,
    () => 
    {
      sut.SetMarking(-1, Marking.Circle);
    });
}

// ----------------------------------------------------------------------------

[Theory]
[InlineData(0)]
[InlineData(1)]
[InlineData(2)]
[InlineData(3)]
[InlineData(4)]
[InlineData(5)]
[InlineData(6)]
[InlineData(7)]
[InlineData(8)]
public void ReportValidPositionWhenBoxOccupiedEventIsRaised(int position)
{
  var expected = -1;
  sut.BoxOccupiedEvent += (s, e) => expected = e.Position;

  // Perform box occupation
  sut.SetMarking(position, Marking.Circle);
  sut.SetMarking(position, Marking.Circle);

  Assert.Equal(position, expected);
}

// ----------------------------------------------------------------------------

#endregion

// ----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->
