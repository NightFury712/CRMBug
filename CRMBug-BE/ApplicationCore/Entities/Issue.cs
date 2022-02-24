using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationCore.Enumeration.Enumeration;

namespace ApplicationCore.Entities
{
    /// <summary>
    /// Thông tin vấn đề
    /// </summary>
    /// Author: HHDang 23.2.2022
    public class Issue : BaseEntity
    {
        #region Properties
        public string ID { get; set; }

        [TableColumn]
        public int TypeID { get; set; }
        [TableColumn]
        public string TypeIDText { get; set; }
        [TableColumn]
        public string Subject { get; set; }
        [TableColumn]
        public int PriorityID { get; set; }
        [TableColumn]
        public string PriorityIDText { get; set; }
        [TableColumn]
        public int StatusID { get; set; }
        [TableColumn]
        public string StatusIDText { get; set; }
        [TableColumn]
        public string AssignedTo { get; set; }
        [TableColumn]
        public string FoundInBuild { get; set; }
        [TableColumn]
        public string IntergratedBuild { get; set; }

        #endregion
    }
}
