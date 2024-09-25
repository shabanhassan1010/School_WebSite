#region
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using System.Reflection;
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

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        #endregion
    }
}
