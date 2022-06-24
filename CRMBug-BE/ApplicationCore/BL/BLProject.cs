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
using static Library.Enumeration.Enumeration;

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
    protected override void AfterSave(Project entity)
    {
      base.AfterSave(entity);
      var userID = long.Parse(SessionData.UserID);
      List<long> userIDs = new List<long>()
      {
        userID
      };
      if(entity.EntityState == EntityState.Add)
      {
        var prop = entity.GetType().GetProperty("ProjectCode");
        entity = this.DLProject.GetEntityByProperty(entity, prop);
        var notification = new Notification()
        {
          Config = "",
          LayoutCode = "Project",
          ProjectID = entity.ID,
          FromUserID = userID,
          ToUserID = userID,
          Content = string.Format(Properties.Resources.WriteLog_Add, SessionData.FullName, $"project <b>{entity.ProjectName}</b>")
        };
        base.WriteLog(notification);
      }
      this.DLProject.InviteUser(entity.ID, userIDs);
    }
    #endregion
  }
}
