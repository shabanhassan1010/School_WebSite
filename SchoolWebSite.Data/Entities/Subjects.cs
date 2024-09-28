using SchoolWebSite.Data.Commonds;
using SchoolWebSite.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Subjects : GeneralLocalizableEntity
    {
        public Subjects() //Can use Constructor Also and remove the definition of Collections
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmetsSubjects = new HashSet<DepartmetSubject>();
            InstructorSubjects = new HashSet<InstructorSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubID { get; set; }
        [StringLength(500)]
        public string SubjectNameAr { get; set; } = string.Empty;
        public string SubjectNameEn { get; set; } = string.Empty;
        public DateTime Period { get; set; }


        [InverseProperty("Subject")]
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }


        [InverseProperty("Subject")]
        public virtual ICollection<DepartmetSubject> DepartmetsSubjects { get; set; }


        [InverseProperty("subject")]
        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; }

    }
}
