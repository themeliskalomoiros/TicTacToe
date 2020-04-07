//-----------------------------------------------------------------------------

using System;
using System.Text;
using System.Threading;

//-----------------------------------------------------------------------------

namespace ConsoleApp {

//-----------------------------------------------------------------------------

public class MessagePrinter {

//-----------------------------------------------------------------------------

#region Public Methods

//-----------------------------------------------------------------------------

public void PrintWelcome()
{
  var welcome = GetWelcomeMessage();
  for (int i = 0; i < welcome.Length; i++)
  {
    Thread.Sleep(1);
    Console.Write(welcome[i]);
  }
}

//-----------------------------------------------------------------------------

#endregion
#region Private Methods

//-----------------------------------------------------------------------------

private string GetWelcomeMessage()
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

private string GetWelcomeLine()
{
  var sb = new StringBuilder();
  for (int i = 0; i < LineWidth; i++)
    sb.Append("*");

  return sb.ToString();
}

//-----------------------------------------------------------------------------

private string GetWelcomeLineWithText()
{
  var text = "TIC - TAC - TOE";
  var line = GetWelcomeLine();
  var lineWithText = line.Insert(line.Length / 2 - text.Length / 2, text);
  return lineWithText.Remove(line.Length);
}

//-----------------------------------------------------------------------------

#endregion
#region Fields

private const int LineWidth = 70;
private const int LineHeight = 10;

//-----------------------------------------------------------------------------

#endregion

//-----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->

