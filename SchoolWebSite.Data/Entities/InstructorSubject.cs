using SchoolProject.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWebSite.Data.Entities
{
    public class InstructorSubject
    {
        [Key]
        public int InsId { get; set; }
        [Key]
        public int SubId { get; set; }
        [ForeignKey(nameof(InsId))]
        [InverseProperty("InstructorSubjects")]
        public Instructor instructor { get; set; }
        [ForeignKey(nameof(SubId))]
        [InverseProperty("InstructorSubjects")]
        public Subjects subject { get; set; }
    }
}
