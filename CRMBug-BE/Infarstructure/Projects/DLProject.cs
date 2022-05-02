using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.DL;
using Infarstructure.Base;
using Microsoft.Extensions.Configuration;

namespace Infarstructure.Projects
{
  public class DLProject : DLBase<Project>, IDLProject
  {
    #region Constructor
    public DLProject(IConfiguration configuration) : base(configuration)
    {

    }
    #endregion
  }
}
