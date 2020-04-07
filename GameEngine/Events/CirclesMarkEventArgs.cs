﻿//-----------------------------------------------------------------------------

using System;

//-----------------------------------------------------------------------------

namespace GameEngine.Events {

//-----------------------------------------------------------------------------

public class CirclesMarkEventArgs : EventArgs{

//-----------------------------------------------------------------------------

public int Position { get; set; }

// ----------------------------------------------------------------------------

public CirclesMarkEventArgs(
  int position)
{
  Position = position;
}

// ----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->
