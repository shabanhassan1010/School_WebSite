using Microsoft.EntityFrameworkCore;
using SchoolWebSite.Data.Entities;
using SchoolWebSite.Infrastructure.Data;
using SchoolWebSite.Infrastructure.Generics;
using SchoolWebSite.Infrastructure.Repositories;

namespace SchoolWebSite.Infrastructure.Implemention
{
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {
        #region Fields
        private readonly DbSet<Instructor> _instructors;
        #endregion

        #region Constructor
        public InstructorRepository(ApplictionDBContext dBContext) : base(dBContext) //in GenericRepositoryAsync Constructor
        {
            _instructors = dBContext.Set<Instructor>();
        }
        #endregion
    }
}
