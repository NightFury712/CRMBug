using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.DL;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using MySqlX.XDevAPI.Relational;

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
        public DLBase(IConfiguration configuration) {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnectionString");// chuỗi config kết nối db
            _dbConnection = new MySqlConnection(_connectionString);
            _tableName = typeof(T).Name;
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
            var properties = entity.GetType().GetProperties();
            var propertyNames = properties.Where(item => item.IsDefined(typeof(TableColumn), false)).Select(item => item.Name);
            string query = $"INSERT INTO issue ({string.Join(",", propertyNames)}) VALUE ({string.Join(",", propertyNames.Select(item => $"@{item}"))})";
            // Thực thi commandText
            rowAffects = _dbConnection.Execute(query, parameters, commandType: CommandType.Text);
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
