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
        public int DID { get; set; }
        public string DNameAr { get; set; }
        public string DNameEn { get; set; }
        public int InsManger { get; set; }


        [InverseProperty(nameof(Student.Department))]  //   == [InverseProperty("Department")]
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

        [InverseProperty("Department")]
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; } = new HashSet<DepartmetSubject>();

        [InverseProperty("department")]
        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

        [ForeignKey("InsManger")]
        [InverseProperty("deptManger")]
        public virtual Instructor Instructor { get; set; }
    }
}
