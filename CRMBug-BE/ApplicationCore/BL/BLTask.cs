using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationCore.Interfaces.BL;
using ApplicationCore.Interfaces.DL;
using Library;
using Library.Entities;
using static Library.Enumeration.Enumeration;

namespace ApplicationCore.BL
{
  public class BLTask: BLBase<Task>, IBLTask
  {
    #region DECLARE
    IDLTask DLTask;
    #endregion

    #region CONSTRUCTOR
    public BLTask(IDLTask dlTask) : base(dlTask)
    {
      DLTask = dlTask;
    }
    #endregion

    #region Methods

    public Dictionary<string, object> GetFormData(long projectID, long masterID, int formModeState)
    {
      Dictionary<string, object> data = base.GetDictionaryByLayoutCode();
      if (data != null)
      {
        if (formModeState == (int)EntityState.Edit)
        {
          data["CurrentData"] = DLTask.GetDataByID(masterID);
        }
        data["Employees"] = this.GetEmployeeByProjectID(projectID);
      }
      return data;
    }

    private IEnumerable<Employee> GetEmployeeByProjectID(long id)
    {
      return DLTask.GetEmployeeByProjectID(id);
    }
    protected override void AfterSave(Task entity)
    {
      base.AfterSave(entity);
      if (entity.EntityState == EntityState.Add)
      {
        var notification = new Notification()
        {
          Config = "",
          LayoutCode = "Task",
          ProjectID = entity.ProjectID,
          FromUserID = long.Parse(SessionData.UserID),
          ToUserID = entity.AssignedUserID,
          Content = string.Format(Properties.Resources.WriteLog_Add, SessionData.FullName, $"Task")
        };
        base.WriteLog(notification);
      }
    }
    #endregion
  }
}
