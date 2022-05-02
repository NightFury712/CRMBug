using System;
using System.Collections.Generic;
using System.Linq;
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
  }
}
