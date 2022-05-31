using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;
using ApplicationCore.Interfaces.BL;
using ApplicationCore.Interfaces.DL;
using Library;
using Library.Entities.param;

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

    #region Methods
    public bool InviteUser(ParamInviteUser param)
    {
      return this.DLProject.InviteUser(param.ProjectID, param.UserIDs);
    }

    #endregion

    #region Methods Override
    protected override void AfterSave(Project project)
    {
      List<int> userIDs = new List<int>()
      {
        Int32.Parse(SessionData.UserID)
      };
      this.DLProject.InviteUser(project.ID, userIDs);
    }
    #endregion
  }
}
