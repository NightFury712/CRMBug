using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;

namespace ApplicationCore.Interfaces.DL
{
  public interface IDLBase<T>
  {
    IEnumerable<T> GetEntities();

    int Save(T entity);

    int Delete(int entityID);

    Dictionary<string, object> GetDictionaryByLayoutCode();

    T GetEntityByProperty(T entity, PropertyInfo property, string columns = "*");

    string GetTableName<BEntity>();

    Dictionary<string, object> Grid(string oWhere, string columns, string limit);

    T GetDataByID(long id);

    bool WriteLog(Notification notification);
  }
}
