using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{
    public class Student
    {
        [Key]
        public int StudID { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        [StringLength(500)]
        public string Address { get; set; } = string.Empty;
        [StringLength(500)]
        public string Phone { get; set; } = string.Empty;
        public int? DID { get; set; }

        [ForeignKey("DID")]
        public virtual Department Department { get; set; }
    }
}
