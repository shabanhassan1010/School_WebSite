using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolWebSite.Data.Entities;

namespace SchoolWebSite.Infrastructure.Configrations
{
    public class InstructorSubjectConfigrations : IEntityTypeConfiguration<InstructorSubject>
    {
        public void Configure(EntityTypeBuilder<InstructorSubject> builder)
        {
            builder.HasOne(i => i.instructor)
                .WithMany(IS => IS.InstructorSubjects)
                .HasForeignKey(IS => IS.InsId);

            builder.HasOne(i => i.subject)
            .WithMany(IS => IS.InstructorSubjects)
            .HasForeignKey(IS => IS.SubId);

            builder.HasKey(x => new { x.SubId, x.InsId });

        }
    }
}
