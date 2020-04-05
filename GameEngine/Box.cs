//-----------------------------------------------------------------------------

using System;
using System.ComponentModel;

//-----------------------------------------------------------------------------

namespace GameEngine {

//-----------------------------------------------------------------------------

public class Box : INotifyPropertyChanged{

//-----------------------------------------------------------------------------

#region Properties

//-----------------------------------------------------------------------------

public Marking Marking 
{ 
  get => marking; 
  set
  {
    if (marking != value)
    {
      marking = value;
      RaisePropertyChange(nameof(Marking));
    }
  }
}

//-----------------------------------------------------------------------------

#endregion
#region Event Handlers

//-----------------------------------------------------------------------------

public event PropertyChangedEventHandler PropertyChanged;

//-----------------------------------------------------------------------------

#endregion
#region Private Methods

//-----------------------------------------------------------------------------

private void RaisePropertyChange(string propertyName)
{
  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

//-----------------------------------------------------------------------------

#endregion
#region Fields

//-----------------------------------------------------------------------------

private Marking marking = Marking.None;

//-----------------------------------------------------------------------------

#endregion

//-----------------------------------------------------------------------------

} // <-- end of type body -->

// ----------------------------------------------------------------------------

} // <-- end of namespace body -->
