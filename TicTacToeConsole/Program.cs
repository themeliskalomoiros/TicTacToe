using System;
using GameEngine;
using GameEngine.Events;

namespace TicTacToeConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      var game = new GameState();
      for (int i = 0; i < 9; i++)
      {
        game.Mark(i);
      }
    }
  }
}
