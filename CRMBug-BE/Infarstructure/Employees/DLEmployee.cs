using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;
using ApplicationCore.Interfaces.DL;
using Infarstructure.Base;
using Microsoft.Extensions.Configuration;

namespace Infarstructure.Employees
{
  public class DLEmployee : DLBase<Employee>, IDLEmployee
  {
    #region Constructor
    public DLEmployee(IConfiguration configuration) : base(configuration)
    {

    }
    #endregion
  }
}
