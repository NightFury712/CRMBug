using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.BL;
using ApplicationCore.Interfaces.DL;
using Library.Entities;

namespace ApplicationCore.BL
{
  public class BLNotification : BLBase<Notification>, IBLNotification
  {
    #region DECLARE
    IDLNotification DLNotification;
    #endregion

    #region CONSTRUCTOR
    public BLNotification(IDLNotification dlNotification) : base(dlNotification)
    {
      DLNotification = dlNotification;
    }
    #endregion
  }
}
