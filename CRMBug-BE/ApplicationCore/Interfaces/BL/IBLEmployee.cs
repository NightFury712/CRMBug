using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;

namespace ApplicationCore.Interfaces.BL
{
  public interface IBLEmployee : IBLBase<Employee>
  {
    IEnumerable<Employee> GetEmployeeNotInProject(long projectID);
  }
}
