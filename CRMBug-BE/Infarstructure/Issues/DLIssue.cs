using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infarstructure.Base;
using Library.Entities;
using ApplicationCore.Interfaces.DL;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;

namespace Infarstructure.Issues
{
  public class DLIssue : DLBase<Issue>, IDLIssue
  {
    #region Constructor
    public DLIssue(IConfiguration configuration) : base(configuration)
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
