using SchoolWebSite.Data.Commonds;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Student : GeneralLocalizableEntity
    {
        [Key]
        public int StudID { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        [StringLength(50)]
        public string Address { get; set; } = string.Empty;
        [StringLength(500)]
        public string Phone { get; set; } = string.Empty;
        public int? DID { get; set; }

        [ForeignKey("DID")]
        public virtual Department Department { get; set; }
    }
}
