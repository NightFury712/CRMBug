using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.DL;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using MySqlX.XDevAPI.Relational;
using Newtonsoft.Json;
using Library;
using System.Reflection;
using Library.Entities;
using static Library.Enumeration.Enumeration;

namespace Infarstructure.Base
{
  public class DLBase<T> : IDLBase<T>, IDisposable where T : BaseEntity
  {
    #region DECLARE
    private readonly IConfiguration _configuration;
    string _connectionString = string.Empty;
    protected IDbConnection _dbConnection = null;
    protected string _tableName;
    #endregion

    #region Constructor
    public DLBase(IConfiguration configuration)
    {
      _configuration = configuration;
      _connectionString = configuration.GetConnectionString("DefaultConnectionString");// chuỗi config kết nối db
      _dbConnection = new MySqlConnection(_connectionString);
      _tableName = GetTableName<T>();
    }
    #endregion

    #region Methods
    /// <summary>
    /// Lấy toàn bộ thực thể
    /// </summary>
    /// <returns>Danh sách thực thể</returns>
    /// Author: HHDang 23.2.2022
    public IEnumerable<T> GetEntities()
    {
      try
      {
        // Khởi tạo các commandText:
        string query = $"select * from {_tableName}";
        var entities = _dbConnection.Query<T>(query, commandType: CommandType.Text);
        // Trả về dữ liệu:
        return entities;
      }
      catch (Exception)
      {
        return null;
      }
    }
    public IEnumerable<T> Grid(string oWhere, string columns)
    {
      string query = $"SELECT {columns} FROM {_tableName} WHERE {oWhere}";
      var entities = _dbConnection.Query<T>(query, commandType: CommandType.Text);
      return entities;
    }
    /// <summary>
    /// Thêm mới bản ghi
    /// </summary>
    /// <param name="entity">Thông tin bản ghi</param>
    /// <returns>Số cột bị ảnh hưởng</returns>
    /// Author: HHDang 23.2.2022
    public int Save(T entity)
    {
      var rowAffects = 0;
      _dbConnection.Open();
      // Xử lý các kiểu dữ liệu (mapping dataType):
      var parameters = MappingDbtype(entity);
      // Thực thi commandText
      rowAffects = _dbConnection.Execute(entity.Query, parameters, commandType: CommandType.Text);
      // Trả về kết quả (Số bản ghi thêm mới được)
      return rowAffects;
    }

    protected DynamicParameters MappingDbtype(T entity)
    {
      var properties = entity.GetType().GetProperties();
      var parameters = new DynamicParameters();

      foreach (var property in properties)
      {
        var propertyName = property.Name;
        var propertyValue = property.GetValue(entity);
        var propertyType = property.PropertyType;
        if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
        {
          parameters.Add($"@{propertyName}", propertyValue, DbType.String);
        }
        else if (propertyType == typeof(bool) || propertyType == typeof(bool?))
        {
          var dbValue = (bool)propertyValue == true ? 1 : 0;
          parameters.Add($"@{propertyName}", dbValue, DbType.Int32);
        }
        else
        {
          parameters.Add($"@{propertyName}", propertyValue);
        }
      }
      return parameters;
    }

    public int Delete(int entityID)
    {
      string query = $"DELETE FROM {_tableName} WHERE ID = @ID";
      _dbConnection.Open();
      int rowAffects = _dbConnection.Execute(query, new { ID = entityID }, commandType: CommandType.Text);
      return rowAffects;
    }

    public Dictionary<string, object> GetDictionaryByLayoutCode()
    {
      Dictionary<string, object> datas = new Dictionary<string, object>();
      List<List<Dictionary<string, object>>> listData = new List<List<Dictionary<string, object>>>();
      string procedures = "Proc_GetDictionaryByFormLayout";
      using (var rd = _dbConnection.ExecuteReader(procedures, new { v_LayoutCode = _tableName }, commandType: CommandType.StoredProcedure))
      {
        if(rd != null)
        {
          listData.Add(ExtensionMethod.ToListDictionary(rd));
          while(rd.NextResult())
          {
            listData.Add(ExtensionMethod.ToListDictionary(rd));
          }
        }
      }
      datas.Add("Dictionary", listData);
      return datas;
    }

    public T GetDataByID(long id)
    {
      var query = string.Empty;
      var properties = typeof(T).GetProperties();
      var propertyNames = string.Join(",", properties.Where(item => item.IsDefined(typeof(TableColumn), false)).Select(item => item.Name));
      propertyNames = $"{propertyNames},ID,ModifiedDate,CreatedDate,ModifiedBy,CreatedBy";
      query = $"SELECT {propertyNames} FROM {_tableName} WHERE ID = @ID";
      return _dbConnection.QueryFirstOrDefault<T>(query, new { ID = id });
    }

    public string GetTableName<BEntity>()
    {
      var tableName = typeof(BEntity).GetCustomAttributes(typeof(TableNameAttribute), true).FirstOrDefault() as TableNameAttribute;
      if (tableName != null)
      {
        return tableName.Name;
      }
      return "";
    }

    public T GetEntityByProperty(T entity, PropertyInfo property, string columns = "*")
    {
      var propertyName = property.Name;
      var propertyValue = property.GetValue(entity);
      var keyValue = entity.GetType().GetProperty("ID").GetValue(entity);

      var query = string.Empty;
      switch(entity.EntityState)
      {
        case EntityState.Add:
          query = $"SELECT {columns} FROM {_tableName} WHERE {propertyName} = '{propertyValue}'";
          break;
        case EntityState.Edit:
          query = $"SELECT {columns} FROM {_tableName} WHERE {propertyName} = '{propertyValue}' AND ID <> '{keyValue}'";
          break;
        default:
          return null;
      }

      var res = _dbConnection.QueryFirstOrDefault<T>(query, commandType: CommandType.Text);
      return res;
    }

    /// <summary>
    /// Đóng kết nối đến database
    /// </summary>
    /// Author: HHDang 23.2.2022
    public void Dispose()
    {
      if (_dbConnection.State == ConnectionState.Open)
      {
        _dbConnection.Close();
      }
    }
  }
  #endregion
}
