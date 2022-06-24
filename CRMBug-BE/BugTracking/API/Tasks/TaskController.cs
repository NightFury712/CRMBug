using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Interfaces.BL;
using BugTracking.API.Base;
using Library.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Library.Enumeration.Enumeration;

namespace BugTracking.API.Tasks
{
  public class TaskController : BaseApiController<Task>
  {
    #region DECLARE
    IBLTask BL;
    #endregion

    #region CONSTRUCTOR
    public TaskController(IBLTask BLTask) : base(BLTask)
    {
      BL = BLTask;
    }
    #endregion

    #region Methods
    [HttpGet]
    [Route("FormData/{projectID}/{masterID}/{formModeState}")]
    [Authorize]
    public IActionResult GetFormData(long projectID, long masterID, int formModeState)
    {
      try
      {
        _serviceResult.Success = true;
        _serviceResult.Code = Code.Ok;
        _serviceResult.Data = BL.GetFormData(projectID, masterID, formModeState);

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
