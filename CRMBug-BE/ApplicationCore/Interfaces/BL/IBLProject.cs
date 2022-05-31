using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;
using Library.Entities.param;

namespace ApplicationCore.Interfaces.BL
{
  public interface IBLProject : IBLBase<Project>
  {
    bool InviteUser(ParamInviteUser param);
  }
}
