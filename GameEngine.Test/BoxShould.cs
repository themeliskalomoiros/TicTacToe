//-----------------------------------------------------------------------------

using GameEngine;
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
public void RaisePropertyChanged()
{
  Assert.PropertyChanged(
    sut,
    nameof(sut.Marking),
    () => sut.Marking = Marking.Circle);
}

//-----------------------------------------------------------------------------

[Fact]
public void NotRaisePropertyChangeWhenSameValueIsSet()
{
  int eventRaiseCount = 0;
  sut.PropertyChanged += (s, e) => ++eventRaiseCount;

  sut.Marking = Marking.Circle;
  Assert.Equal(1, eventRaiseCount);

  sut.Marking = Marking.Circle;
  Assert.Equal(1, eventRaiseCount);
}

//-----------------------------------------------------------------------------

[Fact]
public void RaiseAlreadyMarkedWhenSameValueIsSet()
{
  Assert.Raises<AlreadyMarkedEventArgs>(
    handler => sut.AlreadyMarkedEvent += handler,
    handler => sut.AlreadyMarkedEvent -= handler,
    () => 
    {
      sut.Marking = Marking.Circle;
      sut.Marking = Marking.Circle;
    });
}

// ----------------------------------------------------------------------------

#endregion

// ----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->
