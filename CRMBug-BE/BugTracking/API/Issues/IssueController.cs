using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Entities;
using ApplicationCore.Interfaces.BL;
using BugTracking.API.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using static Library.Enumeration.Enumeration;

namespace BugTracking.API.Issues
{
    public class IssueController : BaseApiController<Issue>
    {
        #region DECLARE
        IBLIssue BL;
        #endregion

        #region CONSTRUCTOR
        public IssueController(IBLIssue BLIssue):base(BLIssue)
        {
            BL = BLIssue;
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
