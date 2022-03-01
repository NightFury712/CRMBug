using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
  public class Employee : BaseEntity
  {
    #region Properties
    public int ID { get; set; }
    public string EmployeeID { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeeCode { get; set; }
    #endregion
  }
}
