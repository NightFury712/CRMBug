using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infarstructure.Base;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.DL;
using Microsoft.Extensions.Configuration;

namespace Infarstructure.Issues
{
    public class DLIssue : DLBase<Issue>, IDLIssue
    {
        #region Constructor
        public DLIssue(IConfiguration configuration):base(configuration)
        {

        }
        #endregion
    }
}
