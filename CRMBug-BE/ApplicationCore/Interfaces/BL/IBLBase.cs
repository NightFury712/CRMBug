using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.BL
{
  public interface IBLBase<T>
  {
    IEnumerable<T> GetEntities();

    ServiceResult Save(T entity);

    ServiceResult Delete(int entityID);

    ServiceResult GetDictionaryByLayoutCode();
  }
}
