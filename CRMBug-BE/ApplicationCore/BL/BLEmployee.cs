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
    #endregion

    #region Methods
    public IEnumerable<Employee> GetEmployeeByProjectID(long projectID, bool isInProject)
    {
      return DLEmployee.GetEmployeeByProjectID(projectID, isInProject);
    }
    public List<Dictionary<string, object>> GetAllRole()
    {
      return this.DLEmployee.GetAllRole();
    }
    #endregion

    #region Overrides
    protected override void BeforeSave(Employee entity)
    {
      if (entity.EntityState == EntityState.Add)
      {
        var passwordDecode = Utils.Base64Decode(entity.Password);
        entity.Password = Hasher.BcryptHash(passwordDecode);
        entity.EmployeeID = (Guid.NewGuid()).ToString();
        var employeeCode = this.DLEmployee.GenerateAutoNumber(nameof(Employee.EmployeeCode));
        entity.EmployeeCode = employeeCode;
      }
      entity.FullName = $"{entity.FirstName} {entity.LastName}";
      base.BeforeSave(entity);
    }
    protected override string CreateAddQuery(List<string> propertyNames, string tableName)
    {
      propertyNames.Add("Username");
      propertyNames.Add("PassWord");
      return base.CreateAddQuery(propertyNames, tableName);
    }
    #endregion
  }
}
