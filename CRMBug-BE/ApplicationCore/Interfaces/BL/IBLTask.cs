using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Entities;

namespace ApplicationCore.Interfaces.BL
{
  public interface IBLTask : IBLBase<Task>
  {
    Dictionary<string, object> GetFormData(long projectID, long masterID, int formModeState);
  }
}
