using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;

namespace ApplicationCore.Interfaces.DL
{
  public interface IDLProject : IDLBase<Project>
  {
    bool InviteUser(long projectID, List<long> userIDs);
  }
}
