using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Library.Enumerations.Enumeration;

namespace Library.Entities
{
  public class FilterField
  {
    public string FieldName { get; set; }
    public string Value { get; set; }
    public Operator Operator { get; set; }
    public Addition Addition { get; set; }
  }
}
