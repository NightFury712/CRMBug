using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
  [TableName("employee")]
  public class Employee : BaseEntity
  {
    #region Properties
    public int ID { get; set; }
    [TableColumn]
    public string EmployeeID { get; set; }
    [TableColumn]
    public string FullName { get; set; }
    [TableColumn]
    public string EmployeeCode { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    #endregion
  }
}
