using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolWebSite.Infrastructure.Data;
using SchoolWebSite.Infrastructure.Generics;
using SchoolWebSite.Infrastructure.Repositories;

namespace SchoolWebSite.Infrastructure.Implemention
{
    public class SubjectRepository : GenericRepositoryAsync<Subjects>, ISubjectRepository
    {
        #region Fields
        private readonly DbSet<Subjects> _Subjects;
        #endregion

        #region Constructor
        public SubjectRepository(ApplictionDBContext dBContext) : base(dBContext) //in GenericRepositoryAsync Constructor
        {
            _Subjects = dBContext.Set<Subjects>();
        }
        #endregion

    }
}
