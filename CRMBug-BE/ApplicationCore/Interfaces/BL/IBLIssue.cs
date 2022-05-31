using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;

namespace ApplicationCore.Interfaces.BL
{
    public interface IBLIssue : IBLBase<Issue>
    {
      Dictionary<string, object> GetFormData(long projectID, long masterID, int formModeState);
    }
}
