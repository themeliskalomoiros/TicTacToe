//-----------------------------------------------------------------------------

using GameEngine;
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
public void RaiseOnMarkEvent()
{
  Assert.Raises<MarkEventArgs>( 
    handler => sut.MarkEvent += handler,
    handler => sut.MarkEvent -= handler,
    () => sut.SetMarking(3, Marking.Circle));
}

// ----------------------------------------------------------------------------

#endregion

// ----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->
