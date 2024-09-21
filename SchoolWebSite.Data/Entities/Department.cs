using SchoolWebSite.Data.Commonds;
using SchoolWebSite.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Department : GeneralLocalizableEntity
    {
        //public Department()
        //{
        //    Students = new HashSet<Student>();
        //    DepartmentSubjects = new HashSet<DepartmetSubject>();
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }
        [StringLength(30)]
        public string DNameAr { get; set; } = string.Empty;
        [StringLength(30)]
        public string DNameEn { get; set; } = string.Empty;
        public int? InsManger { get; set; }


        [InverseProperty("Department")]
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

        [InverseProperty("Department")]
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; } = new HashSet<DepartmetSubject>();

        [InverseProperty("department")]
        public virtual ICollection<Instructor> Instructors { get; set; }

        [ForeignKey("InsManger")]
        [InverseProperty("deptManger")]
        public virtual Instructor Instructor { get; set; }
    }
}
