//-----------------------------------------------------------------------------

using System;

//-----------------------------------------------------------------------------

namespace ConsoleApp {

//-----------------------------------------------------------------------------

public class Program {

//-----------------------------------------------------------------------------

static void Main(string[] args)
{
  //Console.WriteLine("Who plays first, Crosses or Circles?\t(Reply with 'X' or 'O')");
  var messages = new MessagePrinter();
  messages.PrintWelcome();
  
  var reply = Console.ReadLine();

  Console.ReadLine();
}

//-----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->

