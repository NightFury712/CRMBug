using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.BL;
using BugTracking.API.Base;
using ApplicationCore.Entities;
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
  }
}
