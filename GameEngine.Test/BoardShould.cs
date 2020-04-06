//-----------------------------------------------------------------------------

using GameEngine;
using GameEngine.Events;
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
public void RaiseBoxOccupiedEvent()
{
  Assert.Raises<BoxMarkingEventArgs>( 
    handler => sut.BoxOccupiedEvent += handler,
    handler => sut.BoxOccupiedEvent -= handler,
    () => 
    {
      sut.SetMarking(3, Marking.Circle);
      sut.SetMarking(3, Marking.Cross);
    });
}

// ----------------------------------------------------------------------------

#endregion

// ----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->
