using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Authentication.Hashers;
using Library.Entities;
using ApplicationCore.Interfaces.BL;
using ApplicationCore.Interfaces.DL;
using Library;
using static Library.Enumeration.Enumeration;

namespace ApplicationCore.BL
{
  public class BLEmployee : BLBase<Employee>, IBLEmployee
  {
    #region DECLARE
    IDLEmployee DLEmployee;
    #endregion

    #region CONSTRUCTOR
    public BLEmployee(IDLEmployee dlEmployee) : base(dlEmployee)
    {
      DLEmployee = dlEmployee;
    }

    public IEnumerable<Employee> GetEmployeeNotInProject(long projectID)
    {
      return DLEmployee.GetEmployeeNotInProject(projectID);
    }

    protected override void BeforeSave<T>(BaseEntity entity)
    {
      var employee = entity as Employee;
      var passwordDecode = Utils.Base64Decode(employee.Password);
      employee.Password = Hasher.BcryptHash(passwordDecode);
      if (entity.EntityState == EntityState.Add)
      {
        employee.EmployeeID = (Guid.NewGuid()).ToString();
      }
      employee.FullName = $"{employee.FirstName} {employee.LastName}";
      base.BeforeSave<Employee>(employee);
    }
    protected override string CreateAddQuery(IEnumerable<string> propertyNames, string tableName)
    {
      propertyNames.Append("Username");
      propertyNames.Append("PassWord");
      return base.CreateAddQuery(propertyNames, tableName);
    }

    #endregion
  }
}
