using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
  #region Attributes
  /// <summary>
  /// Attribute quy định tên bảng
  /// </summary>
  [AttributeUsage(AttributeTargets.Class)]
  public class TableNameAttribute : Attribute
  {
    public string Name;

    public TableNameAttribute()
    {
      Name = string.Empty;
    }

    public TableNameAttribute(string name)
    {
      Name = name;
    }
  }
  /// <summary>
  /// Attribute xác định các cột trong bảng của database
  /// </summary>
  [AttributeUsage(AttributeTargets.Property)]
  public class TableColumn : Attribute
  {

  }
  /// <summary>
  /// Attribute dùng để validate trường bắt buộc nhập
  /// </summary>
  [AttributeUsage(AttributeTargets.Property)]
  public class Required : Attribute
  {

  }
  #endregion
}
