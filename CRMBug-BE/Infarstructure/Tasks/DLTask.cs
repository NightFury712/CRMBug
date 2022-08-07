using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ApplicationCore.Interfaces.DL;
using Dapper;
using Infarstructure.Base;
using Library;
using Library.Constant;
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
      string sql = $"SELECT e.ID, CONCAT(e.FullName, \' (\',e.EmployeeCode,\')\') AS FullName FROM employee e JOIN employee_project_mapping epm ON e.ID = epm.EmployeeID WHERE epm.ProjectID = @ID";
      return _dbConnection.Query<Employee>(sql, new { ID = id }, commandType: CommandType.Text);
    }

    /// <summary>
    /// Phương thức lấy thông tin tóm lược về công việc trong dự án
    /// </summary>
    /// <param name="projectID">ID dự án</param>
    /// <returns></returns>
    public List<Dictionary<string, object>> GetSummaryData(long projectID)
    {
      var sql = Constant.DLTask_GetSumaryData;
      List<Dictionary<string, object>> datas = new List<Dictionary<string, object>>();
      using (var rd = _dbConnection.ExecuteReader(sql, new { ProjectID = projectID }, commandType: CommandType.Text))
      {
        if(rd != null)
        {
          datas = rd.ToListDictionary();
        } 
      }
      return datas;
    }

    public bool DeleteDependance(long taskID)
    {
      string sql = "DELETE FROM schedule WHERE TaskID = @ID";

      return _dbConnection.Execute(sql, new { ID = taskID }, commandType: CommandType.Text) > 0;
    }

    /// <summary>
    /// Phương thức lấy thông tin các công việc được xem gần đây
    /// </summary>
    /// <param name="taskIDs">danh sách ID công việc</param>
    /// <returns></returns>
    public List<Dictionary<string, object>> GetDataRecentlyViewed(List<long> taskIDs)
    {
      List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
      if(taskIDs != null  && taskIDs.Any())
      {
        var sql = Constant.DLTask_GetDataRecentlyViewed.Replace("@IDs", string.Join(",",taskIDs));
        using (var rd = _dbConnection.ExecuteReader(sql, commandType: CommandType.Text))
        {
          if (rd != null)
          {
            result = rd.ToListDictionary();
          }
        }
      }
      return result;
    }
    #endregion
  }
}
