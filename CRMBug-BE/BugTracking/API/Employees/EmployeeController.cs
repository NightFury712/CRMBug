using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracking.API.Base;
using Microsoft.AspNetCore.Mvc;
using Library.Entities;
using ApplicationCore.Interfaces.BL;
using Microsoft.AspNetCore.Authorization;

namespace BugTracking.API.Employees
{
  public class EmployeeController : BaseApiController<Employee>
  {
    #region DECLARE
    IBLEmployee BL;
    #endregion
    #region CONSTRUCTOR
    public EmployeeController(IBLEmployee BLEmployee) : base(BLEmployee) 
    {
      BL = BLEmployee;
    }
    #endregion

    #region API
    [HttpGet]
    [Authorize]
    [Route("GetEmployeeNotInProject/{projectID}")]
    public IActionResult GetEmployeeNotInProject(long projectID)
    {
      try
      {
        var datas = BL.GetEmployeeNotInProject(projectID);
        if (datas != null && datas.Count() > 0)
        {
          _serviceResult.Data = datas;
          _serviceResult.Success = true;
          return Ok(_serviceResult);

        }
        return NoContent();
      }
      catch (Exception ex)
      {
        return GetExceptionResult(ex);
      }
    }
    #endregion
  }
}
