using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

    IEnumerable<T> Grid(string oWhere, string columns);

    T GetDataByID(long id);
  }
}
