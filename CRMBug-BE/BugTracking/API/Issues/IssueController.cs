using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Entities;
using ApplicationCore.Interfaces.BL;
using BugTracking.API.Base;
using Microsoft.AspNetCore.Mvc;

namespace BugTracking.API.Issues
{
    public class IssueController : BaseApiController<Issue>
    {
        #region DECLARE
        IBLIssue BL;
        #endregion

        #region CONSTRUCTOR
        public IssueController(IBLIssue BLIssue):base(BLIssue)
        {
            BL = BLIssue;
        }
        #endregion
    }
}
