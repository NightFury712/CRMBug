using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.BL;
using ApplicationCore.Interfaces.DL;

namespace ApplicationCore.BL
{
  public class BLProject : BLBase<Project>, IBLProject
  {


    #region DECLARE
    IDLProject DLProject;
    #endregion

    #region CONSTRUCTOR
    public BLProject(IDLProject dlProject) : base(dlProject)
    {
      DLProject = dlProject;
    }
    #endregion
  }
}
