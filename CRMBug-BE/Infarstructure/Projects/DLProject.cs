using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;
using ApplicationCore.Interfaces.DL;
using Infarstructure.Base;
using Microsoft.Extensions.Configuration;
using Library;
using Dapper;
using System.Data;

namespace Infarstructure.Projects
{
  public class DLProject : DLBase<Project>, IDLProject
  {
    #region Constructor
    public DLProject(IConfiguration configuration) : base(configuration)
    {

    }
    #endregion

    #region Methods
    public bool InviteUser(long projectID, List<long> userIDs)
    {
      if (userIDs.Any())
      {
        string query = "INSERT INTO employee_project_mapping (EmployeeID, ProjectID, CreatedDate, ModifiedDate, CreatedBy, ModifiedBy) VALUES ";
        List<string> inserts = new List<string>();
        string userName = SessionData.FullName;
        foreach (var id in userIDs)
        {
          inserts.Add($"({id}, {projectID}, NOW(), NOW(), \'{userName}\', \'{userName}\')");
        }

        query = $"{query} {string.Join(",", inserts.Select(x => x))};";
        return _dbConnection.Execute(query, commandType: CommandType.Text) > 0;
      } else
      {
        return false;
      }
    }

    public bool DeleteDependance(long projectID)
    {
      string sql = "DELETE FROM task WHERE ProjectID = @ID;DELETE FROM employee_project_mapping WHERE ProjectID = @ID;DELETE FROM schedule WHERE ProjectID = @ID";

      return _dbConnection.Execute(sql, new { ID = projectID }, commandType: CommandType.Text) > 0;
    }
    #endregion
  }
}
