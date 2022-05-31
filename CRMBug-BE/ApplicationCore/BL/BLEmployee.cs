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

    protected override void BeforeSave(Employee entity)
    {
      var passwordDecode = Utils.Base64Decode(entity.Password);
      entity.Password = Hasher.BcryptHash(passwordDecode);
      base.BeforeSave(entity);
    }
    protected override string CreateAddQuery(IEnumerable<string> propertyNames, string tableName)
    {
      propertyNames.Append("PassWord");
      return base.CreateAddQuery(propertyNames, tableName);
    }

    #endregion
  }
}
