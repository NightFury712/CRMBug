using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Library.Enumeration.Enumeration;

namespace Library.Entities
{
  public class BaseEntity
  {
    #region Properties
    /// <summary>
    /// Trạng thái bản ghi (thêm, xóa, sửa)
    /// </summary>
    public EntityState EntityState { get; set; } = EntityState.Add;
    /// <summary>
    /// Truy vấn
    /// </summary>
    public string Query { get; set; }
    /// <summary>
    /// Thời gian tạo
    /// </summary>
    public DateTime? CreatedDate { get; set; }
    /// <summary>
    /// Người tạo
    /// </summary>
    public string CreatedBy { get; set; }
    /// <summary>
    /// Thời gian thay đổi
    /// </summary>
    public DateTime? ModifiedDate { get; set; }
    /// <summary>
    /// Người thay đổi
    /// </summary>
    public string ModifiedBy { get; set; }
    #endregion
  }
}
