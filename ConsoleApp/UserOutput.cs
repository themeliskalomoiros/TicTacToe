//-----------------------------------------------------------------------------

using System;
using System.Text;
using System.Threading;

//-----------------------------------------------------------------------------

namespace ConsoleApp {

//-----------------------------------------------------------------------------

public static class UserOutput {

//-----------------------------------------------------------------------------

#region Public Methods

//-----------------------------------------------------------------------------

public static void WriteWhoPlaysFirst()
{
  var s = "\nWho plays first? Crosses or Circles?\t(Apply with 'X' or 'O')\n";
  Console.WriteLine(s);
}

//-----------------------------------------------------------------------------

public static void WriteWelcome()
{
  var welcome = GetWelcomeMessage();
  for (int i = 0; i < welcome.Length; i++)
  {
    Thread.Sleep(1);
    Console.Write(welcome[i]);
  }

  Console.WriteLine();
}

//-----------------------------------------------------------------------------

#endregion
#region Private Methods

//-----------------------------------------------------------------------------

private static string GetWelcomeMessage()
{
  var sb = new StringBuilder();
  for (int i = 0; i < LineHeight; i++)
  {
    sb.Append("\n");
    if (i == LineHeight / 2 - 1)
    {
      sb.Append(GetWelcomeLineWithText());
    }
    else
    {
      sb.Append(GetWelcomeLine());
    }
  }

  return sb.ToString();
}

//-----------------------------------------------------------------------------

private static string GetWelcomeLine()
{
  var sb = new StringBuilder();
  for (int i = 0; i < LineWidth; i++)
    sb.Append("*");

  return sb.ToString();
}

//-----------------------------------------------------------------------------

private static string GetWelcomeLineWithText()
{
  var text = " The TIC-TAC-TOE Game ";
  var line = GetWelcomeLine();
  var lineWithText = line.Insert(line.Length / 2 - text.Length / 2, text);
  return lineWithText.Remove(line.Length);
}

//-----------------------------------------------------------------------------

#endregion
#region Fields

//-----------------------------------------------------------------------------

private const int LineWidth = 70;
private const int LineHeight = 10;

//-----------------------------------------------------------------------------

#endregion

//-----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->

