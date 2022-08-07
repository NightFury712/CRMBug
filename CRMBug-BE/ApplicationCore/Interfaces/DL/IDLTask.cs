using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Entities;

namespace ApplicationCore.Interfaces.DL
{
  public interface IDLTask : IDLBase<Task>
  {
    IEnumerable<Employee> GetEmployeeByProjectID(long id);

    /// <summary>
    /// Phương thức lấy thông tin tóm lược về công việc trong dự án
    /// </summary>
    /// <param name="projectID">ID dự án</param>
    /// <returns></returns>
    List<Dictionary<string, object>> GetSummaryData(long projectID);

    bool DeleteDependance(long taskID);

    /// <summary>
    /// Phương thức lấy thông tin các công việc được xem gần đây
    /// </summary>
    /// <param name="taskIDs">danh sách ID công việc</param>
    /// <returns></returns>
    List<Dictionary<string, object>> GetDataRecentlyViewed(List<long> taskIDs);
  }
}
