using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.BL;
using BugTracking.API.Base;
using Library.Entities;
using Library.Entities.param;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTracking.API.Projects
{
  public class ProjectController : BaseApiController<Project>
  {
    #region DECLARE
    IBLProject BL;
    #endregion

    #region CONSTRUCTOR
    public ProjectController(IBLProject BLProject) : base(BLProject)
    {
      BL = BLProject;
    }
    #endregion

    #region APIs
    [HttpPost]
    [Authorize]
    [Route("InviteMember")]
    public IActionResult InviteMember(ParamInviteUser param)
    {
      try
      {
        _serviceResult.Success = true;
        _serviceResult.Data = this.BL.InviteMember(param);
        return Ok(_serviceResult);
      }
      catch (Exception ex)
      {
        return GetExceptionResult(ex);
      }
    }

    [HttpPost]
    [Authorize]
    [Route("RemoveMember")]
    public IActionResult RemoveMember(ParamInviteUser param)
    {
      try
      {
        _serviceResult.Success = true;
        _serviceResult.Data = this.BL.RemoveMember(param);
        return Ok(_serviceResult);
      }
      catch (Exception ex)
      {
        return GetExceptionResult(ex);
      }
    }
    #endregion
  }
}
