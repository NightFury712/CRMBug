using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;
using ApplicationCore.Interfaces.BL;
using ApplicationCore.Interfaces.DL;

namespace ApplicationCore.BL
{
    public class BLIssue : BLBase<Issue>, IBLIssue
    {
        #region DECLARE
        IDLIssue DLIssue;
        #endregion

        #region CONSTRUCTOR
        public BLIssue(IDLIssue dlIssue) : base(dlIssue)
        {
            DLIssue = dlIssue;
        }
        #endregion
    }
}
