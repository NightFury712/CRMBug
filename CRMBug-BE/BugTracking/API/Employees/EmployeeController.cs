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
    [Route("GetEmployeeByProjectID/{projectID}/{isInProject}")]
    public IActionResult GetEmployeeNotInProject(long projectID, bool isInProject)
    {
      try
      {
        var datas = BL.GetEmployeeByProjectID(projectID, isInProject);
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

    /// <summary>
    /// Đăng ký tài khoản
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("register")]
    public override IActionResult Post(Employee entity)
    {
      try
      {
        //Gọi service xác thực tài khoản
        _serviceResult = BL.Save(entity);

        return Ok(_serviceResult);
      }
      catch (Exception ex)
      {
        _serviceResult.Success = false;
        _serviceResult.Data = ex;
        return Ok(_serviceResult);
      }
    }
    #endregion
  }
}
