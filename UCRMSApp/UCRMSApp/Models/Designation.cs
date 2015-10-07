using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UCRMSApp.Models
{
    [Table("Designation")]
    public class Designation
    {
        public int DesignationID { get; set; }
        public string DesignatioName { get; set; }

        public virtual ICollection<Teacher> Teachers { set; get; } 

    }
}