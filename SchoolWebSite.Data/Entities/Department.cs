using SchoolWebSite.Data.Commonds;
using System.ComponentModel.DataAnnotations;

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
        public int DID { get; set; }
        public string DNameAr { get; set; }
        public string DNameEn { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; } = new HashSet<DepartmetSubject>();
    }
}
