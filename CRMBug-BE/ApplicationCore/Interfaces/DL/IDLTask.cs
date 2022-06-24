using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Entities;

namespace ApplicationCore.Interfaces.DL
{
  public interface IDLTask : IDLBase<Task>
  {
    IEnumerable<Employee> GetEmployeeByProjectID(long id);
  }
}
