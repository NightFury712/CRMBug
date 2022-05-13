using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
  [TableName("employee")]
  public class Employee : BaseEntity
  {
    #region Properties
    public int ID { get; set; }
    [TableColumn]
    public string EmployeeID { get; set; }
    [TableColumn]
    public string FirstName { get; set; }
    [TableColumn]
    public string LastName { get; set; }
    [TableColumn]
    public string Email { get; set; }
    [TableColumn]
    public string PhoneNumber { get; set; }
    public int Role { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    #endregion
  }
}
