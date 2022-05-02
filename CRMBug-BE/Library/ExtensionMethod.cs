using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
  public static class ExtensionMethod
  {
    public static List<Dictionary<string, object>> ToListDictionary(IDataReader dataReader)
    {
      List<Dictionary<string, object>> listData = new List<Dictionary<string, object>>();
      while (dataReader.Read())
      {
        Dictionary<string, object> data = new Dictionary<string, object>();
        int fieldCount = dataReader.FieldCount;
        for (int i = 0; i < fieldCount; i++)
        {
          string name = dataReader.GetName(i);
          var value = dataReader[name];
          data.Add(name, value);
        }
        listData.Add(data);
      }
      return listData;
    }

  }
}
