using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ApplicationCore.Interfaces.DL;
using Dapper;
using Infarstructure.Base;
using Library.Entities;
using Microsoft.Extensions.Configuration;

namespace Infarstructure.Tasks
{
  public class DLTask : DLBase<Task>, IDLTask
  {
    #region Constructor
    public DLTask(IConfiguration configuration) : base(configuration)
    {

    }
    #endregion

    #region Methods
    public IEnumerable<Employee> GetEmployeeByProjectID(long id)
    {
      string sql = $"SELECT e.ID, e.FullName FROM employee e JOIN employee_project_mapping epm ON e.ID = epm.EmployeeID WHERE epm.ProjectID = @ID";
      return _dbConnection.Query<Employee>(sql, new { ID = id }, commandType: CommandType.Text);
    }
    #endregion
  }
}
