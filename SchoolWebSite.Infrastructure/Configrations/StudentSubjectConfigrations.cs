using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolWebSite.Infrastructure.Configrations
{
    public class StudentSubjectConfigrations : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.HasOne(s => s.Student)
                .WithMany(SI => SI.StudentSubjects)
                .HasForeignKey(SI => SI.StudID);

            builder.HasOne(s => s.Subject)
            .WithMany(SI => SI.StudentsSubjects)
            .HasForeignKey(SI => SI.SubID);

            builder.HasKey(x => new { x.SubID, x.StudID });

        }
    }
}
