﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolWebSite.Data.Entities;

namespace SchoolWebSite.Infrastructure.Configrations
{
    public class InstructorConfigrations : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasOne(x => x.Supervisor)
               .WithMany(x => x.Instructors)
               .HasForeignKey(x => x.SupervisorId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
