using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Authentication.Hashers;
using ApplicationCore.Authentication.JWT.Generators;
using ApplicationCore.Interfaces.BL;
using ApplicationCore.Interfaces.DL;
using Library;
using Library.Entities;
using Microsoft.AspNetCore.Http;
using static Library.Enumeration.Enumeration;

namespace ApplicationCore.BL
{
  public class BLAuth : BLBase<Employee>, IBLAuth
  {
    #region DECLARE
    IDLEmployee DLEmployee;
    private readonly AccessTokenGenerator _accessTokenGenerator;
    #endregion
    public BLAuth(
      IDLEmployee dlEmployee,
      AccessTokenGenerator jwtGenerator
      ) : base(dlEmployee)
    {
      DLEmployee = dlEmployee;
      _accessTokenGenerator = jwtGenerator;
    }

    public ServiceResult Authenticate(Employee entity)
    {
      var usernameProp = entity.GetType().GetProperty("Username");
      var user = DLEmployee.GetEntityByProperty(entity, usernameProp) as Employee;
      //Không tìm thấy user
      if(user == null)
      {
        serviceResult.Success = false;
        serviceResult.Code = Code.Authentication;
        return serviceResult;
      }
      var passwordDecode = Utils.Base64Decode(entity.Password);
      //Verify Password
      if (!Hasher.BCryptVerify(passwordDecode, user.Password))
      {
        serviceResult.Success = false;
        serviceResult.Code = Code.Authentication;
        serviceResult.Messenger = "Wrong username or password";
        return serviceResult;
      }
      var token = _accessTokenGenerator.GenerateToken(user);
      serviceResult.Success = true;
      serviceResult.Data = new
      {
        AccessToken = token
      };
      serviceResult.Code = Code.Ok;
      return serviceResult;
    }
    public ServiceResult SaveData(Employee entity)
    {
      return base.Save(entity);
    }
  }
}
