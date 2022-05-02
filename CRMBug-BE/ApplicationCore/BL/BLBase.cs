using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.BL;
using ApplicationCore.Interfaces.DL;
using static ApplicationCore.Enumeration.Enumeration;

namespace ApplicationCore.BL
{
  public class BLBase<T> : IBLBase<T> where T : BaseEntity
  {
    #region Declare
    IDLBase<T> DLBase;
    protected ServiceResult serviceResult;
    private bool isValid;
    #endregion

    #region Constructor 
    public BLBase(IDLBase<T> dlBase)
    {
      DLBase = dlBase;
      serviceResult = new ServiceResult();
      serviceResult.Code = Code.Ok;
      serviceResult.ValidateInfo = new List<string>();
      isValid = true;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Lấy danh sách thực thể
    /// </summary>
    /// <returns>Danh sách thực thể</returns>
    /// Author: HHDang 23.2.2022
    public IEnumerable<T> GetEntities()
    {
      return DLBase.GetEntities();
    }

    public virtual ServiceResult Save(T entity)
    {
      entity.EntityState = EntityState.Add;
      isValid = Validate(entity);
      // Thêm mới dữ liệu khi đã hợp lệ:
      if (isValid)
      {
        isValid = ValidateCustom(entity);
      }
      if (isValid)
      {
        var rowAffects = DLBase.Save(entity);
        if (rowAffects >= 1)
        {
          serviceResult.Code = Code.Created;
          serviceResult.Data = rowAffects;
        }
        else
        {
          serviceResult.Code = Code.Exception;
          serviceResult.Data = rowAffects;
        }
      } else
      {
        serviceResult.Code = Code.NotValid;
        serviceResult.Data = 0;
      }
      return serviceResult;
    }
    public ServiceResult Delete(int entityID)
    {
      var rowAffects = DLBase.Delete(entityID);
      if (rowAffects >= 1)
      {
        serviceResult.Code = Code.Created;
        serviceResult.Messenger = "Created Success";
        serviceResult.Data = rowAffects;
      }
      else
      {
        serviceResult.Code = Code.Exception;
        serviceResult.Data = rowAffects;
      }
      return serviceResult;
    }

    public ServiceResult GetDictionaryByLayoutCode()
    {
      var data = DLBase.GetDictionaryByLayoutCode();
      if (data != null)
      {
        serviceResult.Code = Code.Ok;
        serviceResult.Data = data;
      }
      else
      {
        serviceResult.Code = Code.Exception;
        serviceResult.Data = data;
      }
      return serviceResult;
    }

    public bool Validate(T entity)
    {
      bool isValid = true;
      // Đọc các property
      var properties = entity.GetType().GetProperties();
      foreach(var prop in properties)
      {
        /// Lấy giá trị của property hiện tại
        var propertyValue = prop.GetValue(entity);
        /// Lấy tên hiển thị của property
        var displayName = string.Empty;
        DisplayNameAttribute displayNameAttribute = prop.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().SingleOrDefault();
        if (displayNameAttribute != null)
        {
          displayName = displayNameAttribute.DisplayName;
        }
        if (prop.IsDefined(typeof(Required), false))
        {
          // Check bắt buộc nhập:
          var messenger = string.Format(Properties.Resources.Fail_ValidateRequired, displayName);
          if (propertyValue == null || string.IsNullOrEmpty(propertyValue.ToString()))
          {
            serviceResult.ValidateInfo.Add(messenger);
            isValid = false;
          }
        }
      }
      
      return isValid;
    }

    public bool ValidateCustom(T entity)
    {
      return true;
    }
    #endregion

  }
}
