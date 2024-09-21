using SchoolProject.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWebSite.Data.Entities
{
    public class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsId { get; set; }
        public string INameAr { get; set; } = string.Empty;
        public string INameEn { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int? SupervisorId { get; set; }
        public decimal Salary { get; set; }
        public int? DID { get; set; }


        [ForeignKey(nameof(DID))]
        [InverseProperty("Instructors")]
        public Department department { get; set; }


        [InverseProperty("Instructor")]
        public Department deptManger { get; set; }


        [ForeignKey("SupervisorId")]
        [InverseProperty("Instructors")]
        public Instructor Supervisor { get; set; }


        [InverseProperty("Supervisor")]
        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();


        [InverseProperty("instructor")]
        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; } = new HashSet<InstructorSubject>();
    }
}
