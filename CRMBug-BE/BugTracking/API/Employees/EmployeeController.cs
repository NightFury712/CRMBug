using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracking.API.Base;
using Microsoft.AspNetCore.Mvc;
using Library.Entities;
using ApplicationCore.Interfaces.BL;

namespace BugTracking.API.Employees
{
  public class EmployeeController : BaseApiController<Employee>
  {

    #region CONSTRUCTOR
    public EmployeeController(IBLEmployee BLEmployee) : base(BLEmployee) 
    {

    }
    #endregion
  }
}
