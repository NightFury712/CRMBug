using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.BL;
using ApplicationCore.Interfaces.DL;
using Library;
using Library.Entities;
using static Library.Enumeration.Enumeration;

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
        this.BeforeSave(entity);
        var rowAffects = DLBase.Save(entity);
        if (rowAffects >= 1)
        {
          serviceResult.Code = Code.Created;
          serviceResult.Data = rowAffects;
          this.AfterSave(entity);
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

    public Dictionary<string, object> GetDictionaryByLayoutCode()
    {
      return DLBase.GetDictionaryByLayoutCode();
    }

    public IEnumerable<T> Grid(string oWhere, string columns)
    {
      return this.DLBase.Grid(oWhere, columns);
    }

    public T GetDataByID(long id)
    {
      return this.DLBase.GetDataByID(id);
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

    protected virtual void BeforeSave(T entity)
    {

      // Build câu truy vấn
      entity.Query = this.CreateQuery(entity);
    }

    protected virtual void AfterSave(T entity)
    {

    }

    public string CreateQuery(T entity)
    {
      var properties = entity.GetType().GetProperties();
      var propertyNames = properties.Where(item => item.IsDefined(typeof(TableColumn), false)).Select(item => item.Name);
      string tableName = this.DLBase.GetTableName<T>();
      string query = string.Empty;
      switch (entity.EntityState)
      {
        case EntityState.Add:
          query = this.CreateAddQuery(propertyNames, tableName);
          break;
        case EntityState.Edit:
          query = this.CreateEditQuery(propertyNames, tableName);
          break;
      }
      return query;
    }

    protected virtual string CreateAddQuery(IEnumerable<string> propertyNames, string tableName)
    {
      string query = string.Empty;
      StringBuilder field = new StringBuilder("");
      StringBuilder value = new StringBuilder("");
      field.Append(string.Join(",", propertyNames));
      value.Append(string.Join(",", propertyNames.Select(item => $"@{item}")));
      field.Append(", CreatedDate, CreatedBy, ModifiedDate, ModifiedBy");
      value.Append($", NOW(), \'{SessionData.FullName}\', NOW(), \'{SessionData.FullName}\'");
      query = $"INSERT INTO {tableName} ({field}) VALUE ({value})";
      return query;
    }

    protected virtual string CreateEditQuery(IEnumerable<string> propertyNames, string tableName)
    {
      string query = string.Empty;
      StringBuilder queryUpdate =  new StringBuilder("");
      queryUpdate.Append(string.Join(",", propertyNames.Select(field => $"{field} = @{field}")));
      queryUpdate.Append($", ModifiedDate = NOW(), ModifiedBy = \'{SessionData.FullName}\'");
      query = $"UPDATE {tableName} SET {queryUpdate} WHERE ID = @ID";
      return query;
    }
    #endregion

  }
}
