using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolWebSite.Infrastructure.Configrations
{
    public class DepartmentConfigrations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.HasKey(x => x.DID);

            builder.Property(x => x.DNameEn).HasMaxLength(50);

            builder.HasMany(s => s.Students)
                 .WithOne(x => x.Department)
                 .HasForeignKey(x => x.DID)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Instructor)
               .WithOne(x => x.deptManger)
               .HasForeignKey<Department>(x => x.InsManger)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }

}
