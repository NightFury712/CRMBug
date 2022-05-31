using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;
using ApplicationCore.Interfaces.BL;
using ApplicationCore.Interfaces.DL;
using static Library.Enumeration.Enumeration;

namespace ApplicationCore.BL
{
  public class BLIssue : BLBase<Issue>, IBLIssue
  {
    #region DECLARE
    IDLIssue DLIssue;
    #endregion

    #region CONSTRUCTOR
    public BLIssue(IDLIssue dlIssue) : base(dlIssue)
    {
      DLIssue = dlIssue;
    }
    #endregion

    #region Methods
    public Dictionary<string, object> GetFormData(long projectID, long masterID, int formModeState)
    {
      Dictionary<string, object> data = base.GetDictionaryByLayoutCode();
      if (data != null)
      {
        if(formModeState == (int)EntityState.Edit)
        {
          data["CurrentData"] = DLIssue.GetDataByID(masterID);
        }
        data["Employees"] = DLIssue.GetEmployeeByProjectID(projectID);
      }
      return data;
    }

    private IEnumerable<Employee> GetEmployeeByProjectID(long id)
    {
      return DLIssue.GetEmployeeByProjectID(id);
    }
    #endregion
  }
}
