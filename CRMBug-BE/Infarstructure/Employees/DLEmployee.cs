using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;
using ApplicationCore.Interfaces.DL;
using Infarstructure.Base;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;

namespace Infarstructure.Employees
{
  public class DLEmployee : DLBase<Employee>, IDLEmployee
  {
    #region Constructor
    public DLEmployee(IConfiguration configuration) : base(configuration)
    {

    }
    #endregion

    #region Methods
    public IEnumerable<Employee> GetEmployeeNotInProject(long projectID)
    {
      string sql = "SELECT e.ID,e.FullName,e.Email FROM employee e WHERE IsActived = true AND e.ID NOT IN ( SELECT epm.EmployeeID FROM employee_project_mapping epm WHERE epm.ProjectID = 4 );";
      return _dbConnection.Query<Employee>(sql, new { ID = projectID }, commandType: CommandType.Text);
    }
    #endregion
  }
}
