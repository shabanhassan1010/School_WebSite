using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolWebSite.Infrastructure.Configrations
{
    internal class DepartmentSubjectsConfigrations : IEntityTypeConfiguration<DepartmetSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmetSubject> builder)
        {

            builder.HasOne(DS => DS.Department)
                .WithMany(D => D.DepartmentSubjects)
                .HasForeignKey(DS => DS.DID);

            builder.HasOne(DS => DS.Subject)
                .WithMany(D => D.DepartmetsSubjects)
                .HasForeignKey(DS => DS.SubID);

            builder.HasKey(x => new { x.SubID, x.DID });

        }
    }
}
