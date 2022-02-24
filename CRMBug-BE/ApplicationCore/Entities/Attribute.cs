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
    [AttributeUsage(AttributeTargets.Property)]
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

    [AttributeUsage(AttributeTargets.Property)]
    public class TableColumn : Attribute
    {

    }
    #endregion
}
