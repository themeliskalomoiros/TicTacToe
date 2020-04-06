//-----------------------------------------------------------------------------

using GameEngine;
using GameEngine.Events;
using System;
using Xunit;

//-----------------------------------------------------------------------------

namespace GameEngine.Test
{

//-----------------------------------------------------------------------------

public class GameStateShould {

//-----------------------------------------------------------------------------

#region Arrange

private GameState sut = new GameState();

//-----------------------------------------------------------------------------

#endregion
#region Tests

// ----------------------------------------------------------------------------

[Fact]
public void StartWithCrossesTurnByDefault()
{
  Assert.True(sut.IsCrossesTurn);
}

// ----------------------------------------------------------------------------

[Fact]
public void StartWithCirclesTurnIfConfigured()
{
  sut = new GameState(false);
  Assert.False(sut.IsCrossesTurn);
}

// ----------------------------------------------------------------------------

[Fact]
public void MarkCrossesWhenItsCrossesTurn()
{
  sut.Mark(3);

  Assert.Equal(Marking.Cross, sut.GetMark(3));
}

// ----------------------------------------------------------------------------

[Fact]
public void MarkCirclesWhenItsCirclesTurn()
{
  // By default crosses plays first
  sut.Mark(0); 
  sut.Mark(1);

  Assert.Equal(Marking.Circle, sut.GetMark(1));
}

// ----------------------------------------------------------------------------

[Fact]
public void RaiseCrossesMarkEvent()
{
  Assert.Raises<CrossesMarkEventArgs>(
    handler => sut.CrossesMarkEvent += handler,
    handler => sut.CrossesMarkEvent += handler,
    () => sut.Mark(4));
}

// ----------------------------------------------------------------------------

[Fact]
public void RaiseCirclesMarkEvent()
{
  Assert.Raises<CirclesMarkEventArgs>(
    handler => sut.CirclesMarkEvent += handler,
    handler => sut.CirclesMarkEvent += handler,
    () => 
    { 
      sut.Mark(4);
      sut.Mark(5);
    });
}

// ----------------------------------------------------------------------------

[Fact]
public void ReportDraw()
{
  Action draw = () => 
  {
    sut.Mark(0);
    sut.Mark(1);
    sut.Mark(2);
    sut.Mark(4);
    sut.Mark(7);
    sut.Mark(3);
    sut.Mark(5);
    sut.Mark(8);
    sut.Mark(6);
  };
  
  sut.CompletionEvent += (s, e) => Assert.Equal(Result.Draw, e.Result); 
  
  draw();
}

// ----------------------------------------------------------------------------

[Fact]
public void ReportCrossesWin()
{
  Action win = () => 
  {
    sut.Mark(4);
    sut.Mark(1);
    sut.Mark(2);
    sut.Mark(3);
    sut.Mark(7);
  };

  sut.CompletionEvent += (s, e) => Assert.Equal(Result.Draw, e.Result);

  win();
}

// ----------------------------------------------------------------------------

[Fact]
public void ReportCirclesWin()
{
  Action win = () => 
  {
    sut.Mark(4);
    sut.Mark(0);
    sut.Mark(8);
    sut.Mark(2);
    sut.Mark(7);
    sut.Mark(1);
  };

  sut.CompletionEvent += (s, e) => Assert.Equal(Result.Draw, e.Result);

  win();
}

// ----------------------------------------------------------------------------

#endregion

// ----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->
