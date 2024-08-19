using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities
{
    public class Subjects
    {
        //public Subjects() Can use Constructor Also and remove the definition of Collections
        //{
        //    StudentsSubjects = new HashSet<StudentSubject>();
        //    DepartmetsSubjects = new HashSet<DepartmetSubject>();
        //}
        [Key]
        public int SubID { get; set; }
        [StringLength(500)]
        public string SubjectName { get; set; } = string.Empty;
        public DateTime Period { get; set; }
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; } = new HashSet<StudentSubject>();
        public virtual ICollection<DepartmetSubject> DepartmetsSubjects { get; set; } = new HashSet<DepartmetSubject>();
    }
}
