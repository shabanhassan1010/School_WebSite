#region
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolWebSite.Data.Entities;
#endregion

namespace SchoolWebSite.Infrastructure.Data
{
    public class ApplictionDBContext : DbContext
    {
        #region Constructor
        public ApplictionDBContext()   // Default Constructor
        {

        }
        public ApplictionDBContext(DbContextOptions<ApplictionDBContext> options) : base(options) // Parameterized Constructor
        {

        }
        #endregion

        #region Tables
        public DbSet<Student> students { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Subjects> subjects { get; set; }
        public DbSet<DepartmetSubject> departmetSubjects { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }
        //public DbSet<Instructor> instructors { get; set; }
        //public DbSet<InstructorSubject> instructorSubjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmetSubject>()
                .HasKey(x => new { x.SubID, x.DID });

            modelBuilder.Entity<InstructorSubject>()
                .HasKey(x => new { x.SubId, x.InsId });

            modelBuilder.Entity<StudentSubject>()
               .HasKey(x => new { x.SubID, x.StudID });

            modelBuilder.Entity<Instructor>()
               .HasOne(x => x.Supervisor)
               .WithMany(x => x.Instructors)
               .HasForeignKey(x => x.SupervisorId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
              .HasOne(x => x.Instructor)
              .WithOne(x => x.deptManger)
              .HasForeignKey<Department>(x => x.InsManger)
              .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
